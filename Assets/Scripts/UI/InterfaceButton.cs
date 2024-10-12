using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IClickable : IPointerDownHandler, IPointerUpHandler
{
    public abstract void OnPointerDown(PointerEventData eventData);

    public abstract void OnPointerUp(PointerEventData eventData);
}
