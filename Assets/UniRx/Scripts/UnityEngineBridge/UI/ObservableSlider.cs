﻿// for uGUI(from 4.6)
#if !(UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5)

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UniRx.UI
{
    [AddComponentMenu("ObservableUI/Slider", 34)]
    public class ObservableSlider : Slider
    {
#region UIBehaviour

        Subject<Unit> awake;

        protected override void Awake()
        {
            base.Awake();
            if (awake != null) awake.OnNext(Unit.Default);
        }

        public IObservable<Unit> AwakeAsObservable()
        {
            return awake ?? (awake = new Subject<Unit>());
        }

        Subject<Unit> onBeforeTransformParentChanged;

        protected override void OnBeforeTransformParentChanged()
        {
            base.Awake();
            if (onBeforeTransformParentChanged != null) onBeforeTransformParentChanged.OnNext(Unit.Default);
        }

        public IObservable<Unit> OnBeforeTransformParentChangedAsObservable()
        {
            return onBeforeTransformParentChanged ?? (onBeforeTransformParentChanged = new Subject<Unit>());
        }

        Subject<Unit> onCanvasGroupChanged;

        protected override void OnCanvasGroupChanged()
        {
            base.Awake();
            if (onCanvasGroupChanged != null) onCanvasGroupChanged.OnNext(Unit.Default);
        }

        public IObservable<Unit> OnCanvasGroupChangedAsObservable()
        {
            return onCanvasGroupChanged ?? (onCanvasGroupChanged = new Subject<Unit>());
        }

        Subject<Unit> onDestroy;

        protected override void OnDestroy()
        {
            base.Awake();
            if (onDestroy != null) onDestroy.OnNext(Unit.Default);
        }

        public IObservable<Unit> OnDestroyAsObservable()
        {
            return onDestroy ?? (onDestroy = new Subject<Unit>());
        }

        Subject<Unit> onDidApplyAnimationProperties;

        protected override void OnDidApplyAnimationProperties()
        {
            base.Awake();
            if (onDidApplyAnimationProperties != null) onDidApplyAnimationProperties.OnNext(Unit.Default);
        }

        public IObservable<Unit> OnDidApplyAnimationPropertiesAsObservable()
        {
            return onDidApplyAnimationProperties ?? (onDidApplyAnimationProperties = new Subject<Unit>());
        }

        Subject<Unit> onDisable;

        protected override void OnDisable()
        {
            base.Awake();
            if (onDisable != null) onDisable.OnNext(Unit.Default);
        }

        public IObservable<Unit> OnDisableAsObservable()
        {
            return onDisable ?? (onDisable = new Subject<Unit>());
        }

        Subject<Unit> onEnable;

        protected override void OnEnable()
        {
            base.Awake();
            if (onEnable != null) onEnable.OnNext(Unit.Default);
        }

        public IObservable<Unit> OnEnableAsObservable()
        {
            return onEnable ?? (onEnable = new Subject<Unit>());
        }

        Subject<Unit> onRectTransformDimensionsChange;

        protected override void OnRectTransformDimensionsChange()
        {
            base.Awake();
            if (onRectTransformDimensionsChange != null) onRectTransformDimensionsChange.OnNext(Unit.Default);
        }

        public IObservable<Unit> OnRectTransformDimensionsChangeAsObservable()
        {
            return onRectTransformDimensionsChange ?? (onRectTransformDimensionsChange = new Subject<Unit>());
        }

        Subject<Unit> onTransformParentChanged;

        protected override void OnTransformParentChanged()
        {
            base.Awake();
            if (onTransformParentChanged != null) onTransformParentChanged.OnNext(Unit.Default);
        }

        public IObservable<Unit> OnTransformParentChangedAsObservable()
        {
            return onTransformParentChanged ?? (onTransformParentChanged = new Subject<Unit>());
        }

#if UNITY_EDITOR

        Subject<Unit> onValidate;

        protected override void OnValidate()
        {
            base.Awake();
            if (onValidate != null) onValidate.OnNext(Unit.Default);
        }

        public IObservable<Unit> OnValidateAsObservable()
        {
            return onValidate ?? (onValidate = new Subject<Unit>());
        }

        Subject<Unit> reset;

        protected override void Reset()
        {
            base.Awake();
            if (reset != null) reset.OnNext(Unit.Default);
        }

        public IObservable<Unit> ResetAsObservable()
        {
            return reset ?? (reset = new Subject<Unit>());
        }

#endif

        Subject<Unit> start;

        protected override void Start()
        {
            base.Awake();
            if (start != null) start.OnNext(Unit.Default);
        }

        public IObservable<Unit> StartAsObservable()
        {
            return start ?? (start = new Subject<Unit>());
        }

#endregion

#region IDSelect

        Subject<BaseEventData> onDeselect;

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);
            if (onDeselect != null) onDeselect.OnNext(eventData);
        }

        public IObservable<BaseEventData> OnDeselectAsObservable()
        {
            return onDeselect ?? (onDeselect = new Subject<BaseEventData>());
        }

#endregion

#region IMoveHandler

        Subject<AxisEventData> onMove;

        public override void OnMove(AxisEventData eventData)
        {
            base.OnMove(eventData);
            if (onMove != null) onMove.OnNext(eventData);
        }

        public IObservable<AxisEventData> OnMoveAsObservable()
        {
            return onMove ?? (onMove = new Subject<AxisEventData>());
        }

#endregion

#region IPointerDownHandler

        Subject<PointerEventData> onPointerDown;

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            if (onPointerDown != null) onPointerDown.OnNext(eventData);
        }

        public IObservable<PointerEventData> OnPointerDownAsObservable()
        {
            return onPointerDown ?? (onPointerDown = new Subject<PointerEventData>());
        }

#endregion

#region IPointerEnterHandler

        Subject<PointerEventData> onPointerEnter;

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            if (onPointerEnter != null) onPointerEnter.OnNext(eventData);
        }

        public IObservable<PointerEventData> OnPointerEnterAsObservable()
        {
            return onPointerEnter ?? (onPointerEnter = new Subject<PointerEventData>());
        }

#endregion

#region IPointerExitHandler

        Subject<PointerEventData> onPointerExit;

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            if (onPointerExit != null) onPointerExit.OnNext(eventData);
        }

        public IObservable<PointerEventData> OnPointerExitAsObservable()
        {
            return onPointerExit ?? (onPointerExit = new Subject<PointerEventData>());
        }

#endregion

#region IPointerUpHandler

        Subject<PointerEventData> onPointerUp;

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            if (onPointerUp != null) onPointerUp.OnNext(eventData);
        }

        public IObservable<PointerEventData> OnPointerUpAsObservable()
        {
            return onPointerUp ?? (onPointerUp = new Subject<PointerEventData>());
        }

#endregion

#region ISelect

        Subject<BaseEventData> onSelect;

        public override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);
            if (onSelect != null) onSelect.OnNext(eventData);
        }

        public IObservable<BaseEventData> OnSelectAsObservable()
        {
            return onSelect ?? (onSelect = new Subject<BaseEventData>());
        }

#endregion

#region IInitializePotentialDragHandler

        Subject<PointerEventData> onInitializePotentialDrag;

        public override void OnInitializePotentialDrag(PointerEventData eventData)
        {
            base.OnInitializePotentialDrag(eventData);
            if (onInitializePotentialDrag != null) onInitializePotentialDrag.OnNext(eventData);
        }

        public IObservable<PointerEventData> OnInitializePotentialDragAsObservable()
        {
            return onInitializePotentialDrag ?? (onInitializePotentialDrag = new Subject<PointerEventData>());
        }

#endregion

#region IDragHandler

        Subject<PointerEventData> onDrag;

        public override void OnDrag(PointerEventData eventData)
        {
            base.OnDrag(eventData);
            if (onDrag != null) onDrag.OnNext(eventData);
        }

        public IObservable<PointerEventData> OnDragAsObservable()
        {
            return onDrag ?? (onDrag = new Subject<PointerEventData>());
        }

#endregion
    }
}

#endif