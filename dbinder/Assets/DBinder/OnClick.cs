using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnClick : InBind,
    IPointerClickHandler
{
    public string method;

    protected override void Awake()
    {
        base.Awake();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SendMessageUpwards(method, GetValue());
    }
}
