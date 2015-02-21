using UnityEngine;
using UnityEngine.Events;
using UniRx;
using System;
using System.Linq;

public sealed class PinchGesture : MonoBehaviour
{
    [SerializeField]
    private ScaleEvent _scaleEvent;

    private CompositeDisposable _subscribers;

    private static float GetMaxLength(Touch[] touches)
    {
        float maxLength = 0;

        for (var i = 0; i < touches.Length - 1; i++)
        {
            for (var j = i + 1; j < touches.Length; j++)
            {
                maxLength = Mathf.Max(
                    maxLength,
                    Vector2.Distance(
                        touches[i].position,
                        touches[j].position));
            }
        }

        return maxLength;
    }

    private static Vector2 GetCenter(Touch[] touches)
    {
        return touches
            .Select(touch => touch.position)
            .Aggregate(
                Vector2.zero,
                (previous, current) => previous + current) /
            touches.Length;
    }

    private void OnEnable()
    {
        _subscribers = new CompositeDisposable();

        IConnectableObservable<Touch[]> touchStream =
            Observable.EveryUpdate()
                .Select(_ => Input.touches)
                .Publish();

        IObservable<Vector2> centerStream = touchStream
            .Buffer(2, 1)
            .Where(touches => touches[0].Length <= 1 &&
                2 <= touches[1].Length)
            .Select(touches => GetCenter(touches[1]));
       
        IObservable<float> scaleStream = touchStream
            .Buffer(2, 1)
            .Where(touches =>
                touches.All(touch => 2 <= touch.Length))
            .Select(touches =>
                GetMaxLength(touches[1]) /
                    GetMaxLength(touches[0]))
            .Scan(1f, (scale, rate) => scale * rate)
            .Skip(1);

        IDisposable scalingSubscriber = centerStream
            .CombineLatest(
                scaleStream,
                (center, scale) => new Scaling(center, scale))
            .Subscribe(_scaleEvent.Invoke);

        _subscribers.Add(touchStream.Connect());
        _subscribers.Add(scalingSubscriber);
    }

    private void OnDisable()
    {
        _subscribers.Dispose();
    }

    [Serializable]
    private sealed class ScaleEvent : UnityEvent<Scaling>
    {
    }
}
