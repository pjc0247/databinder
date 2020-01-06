using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Representable))]
public class OutBind : Bind
{
    private Representable representable;

    protected override void Awake()
    {
        base.Awake();

        representable = GetComponent<Representable>();
    }

    public override void Invalidate()
    {
        Debug.Log("Invalidate " + property);

        representable.SetText(GetValue()?.ToString() ?? "");
    }
}
