/************************************************************
    文件: CreateUIScript.cs
    作者: 那位先生
    邮箱: 1279544114@qq.com
    日期: 2019/12/31 13:57:20
    功能: UI事件监听
*************************************************************/
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class UIEventListener : EventTrigger
    {
        public delegate void UIListenerDelegate(GameObject go);
        public delegate void UIEventListenerDelegate(GameObject go, object obj);
        public UIListenerDelegate onClick { get; private set; }
        public UIEventListenerDelegate onEventClick { get; private set; }

        public UIListenerDelegate onClickDown { get; private set; }
        public UIEventListenerDelegate onEventClickDown { get; private set; }

        public UIListenerDelegate onClickUp { get; private set; }
        public UIEventListenerDelegate onEventClickUp { get; private set; }

        public UIListenerDelegate onDrag { get; private set; }
        public UIEventListenerDelegate onEventDrag { get; private set; }

        public UIListenerDelegate onPointerEnter { get; private set; }
        public UIEventListenerDelegate onEventPointerEnter { get; private set; }

        public UIListenerDelegate onPointerExit { get; private set; }
        public UIEventListenerDelegate onEventPointerExit { get; private set; }

        public UIListenerDelegate onBeginDrag { get; private set; }
        public UIEventListenerDelegate onEventBeginDrag { get; private set; }

        public UIListenerDelegate onEndDrag { get; private set; }
        public UIEventListenerDelegate onEventEndDrag { get; private set; }

        private object EventObj = null;

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            if (onClick != null) onClick(gameObject);
            if (onEventClick != null) onEventClick(gameObject, EventObj);

        }
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            if (onClickDown != null) onClickDown(gameObject);
            if (onEventClickDown != null) onEventClickDown(gameObject, EventObj);

        }
        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            if (onClickUp != null) onClickUp(gameObject);
            if (onEventClickUp != null) onEventClickUp(gameObject, EventObj);

        }
        public override void OnDrag(PointerEventData eventData)
        {
            base.OnDrag(eventData);
            if (onDrag != null) onDrag(gameObject);
            if (onEventDrag != null) onEventDrag(gameObject, EventObj);

        }
        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            if (onPointerEnter != null) onPointerEnter(gameObject);
            if (onEventPointerEnter != null) onEventPointerEnter(gameObject, EventObj);
        }
        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            if (onPointerExit != null) onPointerExit(gameObject);
            if (onEventPointerExit != null) onEventPointerExit(gameObject, EventObj);
        }
        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
            if (onBeginDrag != null) onBeginDrag(gameObject);
            if (onEventBeginDrag != null) onEventBeginDrag(gameObject, EventObj);
        }
        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
            if (onEndDrag != null) onEndDrag(gameObject);
            if (onEventEndDrag != null) onEventEndDrag(gameObject, EventObj);
        }

        /// <summary>
        /// 注册UI监听事件
        /// </summary>
        /// <param name="uIEventType">注册的UI事件类型</param>
        /// <param name="go">注册的监听对象</param>
        /// <param name="eventHandle">注册的事件</param>
        public static void RegistListener(UIEventType uIEventType, GameObject go, UIListenerDelegate eventHandle)
        {
            var listener = go.GetComponent<UIEventListener>();
            if (listener == null) listener = go.gameObject.AddComponent<UIEventListener>();
            switch (uIEventType)
            {
                case UIEventType.Click:
                    listener.onClick = eventHandle;
                    break;
                case UIEventType.ClickDown:
                    listener.onClickDown = eventHandle;
                    break;
                case UIEventType.ClickUp:
                    listener.onClickUp = eventHandle;
                    break;
                case UIEventType.BeginDrag:
                    listener.onBeginDrag = eventHandle;
                    break;
                case UIEventType.Darg:
                    listener.onDrag = eventHandle;
                    break;
                case UIEventType.EndDrag:
                    listener.onEndDrag = eventHandle;
                    break;
                case UIEventType.PointEnter:
                    listener.onPointerEnter = eventHandle;
                    break;
                case UIEventType.PointExit:
                    listener.onPointerExit = eventHandle;
                    break;
            }
        }
        /// <summary>
        /// 注册UI监听事件
        /// </summary>
        /// <param name="uIEventType">注册的UI事件类型</param>
        /// <param name="go">注册的监听对象</param>
        /// <param name="obj">传入的参数</param>
        /// <param name="eventHandle">注册的事件</param>
        public static void RegistListener(UIEventType uIEventType, GameObject go, object obj, UIEventListenerDelegate eventHandle)
        {
            var listener = go.GetComponent<UIEventListener>();
            if (listener == null) listener = go.gameObject.AddComponent<UIEventListener>();
            listener.EventObj = obj;
            switch (uIEventType)
            {
                case UIEventType.Click:
                    listener.onEventClick = eventHandle;
                    break;
                case UIEventType.ClickDown:
                    listener.onEventClickDown = eventHandle;
                    break;
                case UIEventType.ClickUp:
                    listener.onEventClickUp = eventHandle;
                    break;
                case UIEventType.BeginDrag:
                    listener.onEventBeginDrag = eventHandle;
                    break;
                case UIEventType.Darg:
                    listener.onEventDrag = eventHandle;
                    break;
                case UIEventType.EndDrag:
                    listener.onEventEndDrag = eventHandle;
                    break;
                case UIEventType.PointEnter:
                    listener.onEventPointerEnter = eventHandle;
                    break;
                case UIEventType.PointExit:
                    listener.onEventPointerExit = eventHandle;
                    break;
            }
        }
        /// <summary>
        /// 移除UI监听事件
        /// </summary>
        /// <param name="Go">移除监听的对象</param>
        public static void RemoveListener(GameObject Go)
        {
            var listener = Go.GetComponent<UIEventListener>();
            if (listener == null) return;
            listener.onClick = null;
            listener.onEventClick = null;
        }
    }

    /// <summary>
    /// UI事件监听类型
    /// </summary>
    public enum UIEventType
    {
        /// <summary>
        /// 点击事件
        /// </summary>
        Click = 1001,

        /// <summary>
        /// 点击按下事件
        /// </summary>
        ClickDown,

        /// <summary>
        /// 点击抬起事件
        /// </summary>
        ClickUp,

        /// <summary>
        /// 拖拽事件
        /// </summary>
        Darg,

        /// <summary>
        /// 开始拖拽事件
        /// </summary>
        BeginDrag,

        /// <summary>
        /// 结束拖拽事件
        /// </summary>
        EndDrag,

        /// <summary>
        /// 鼠标进入事件
        /// </summary>
        PointEnter,

        /// <summary>
        /// 鼠标移出事件
        /// </summary>
        PointExit
    }
}
