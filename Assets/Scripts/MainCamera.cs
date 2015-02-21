using UnityEngine;
using UniRx;
using System;

[RequireComponent(typeof(Camera))]
public sealed class MainCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _centerObject;

    private Subject<Scaling> _scalingStream;

    private CompositeDisposable _subscribers;

    public void OnScale(Scaling scaling)
    {
        _scalingStream.OnNext(scaling);
    }

    // Use this for initialization
    private void Start()
    {
        Camera camera = GetComponent<Camera>();

        _scalingStream = new Subject<Scaling>();
        _subscribers = new CompositeDisposable();

        float firstOrthographicSize = camera.orthographicSize;

        IObservable<float> scaleVariationRateStream =
            _scalingStream
                .Select(scaling => scaling.Scale)
                .StartWith(1f)
                .Buffer(2, 1)
                .Select(scaleHistory =>
                    scaleHistory[1] / scaleHistory[0]);

        IDisposable scalingSubscriber = _scalingStream
            .Zip(
                scaleVariationRateStream,
                (scaling, scaleVariationRate) =>
                    new
                    {
                        Center = scaling.Center,
                        Scale = scaling.Scale,
                        ScaleVariationRate = scaleVariationRate
                    })
            .Subscribe(current =>
            {
                Vector2 centerPosition = camera
                        .ScreenToWorldPoint(current.Center);

                _centerObject.transform.position = centerPosition;

                camera.orthographicSize =
                    firstOrthographicSize / current.Scale;

                Vector2 centerTranslate =
                   (centerPosition -
                            (Vector2)transform.position) *
                        (current.ScaleVariationRate - 1);

                transform.position += (Vector3)centerTranslate;
            });

        _subscribers.Add(_scalingStream);
        _subscribers.Add(scalingSubscriber);
    }

    private void OnDestroy()
    {
        _subscribers.Dispose();
    }
}
