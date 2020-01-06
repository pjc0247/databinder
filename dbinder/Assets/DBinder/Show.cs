using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Drawable))]
public class Show : Bind
{
    private Drawable drawable;

    protected override void Awake()
    {
        base.Awake();

        drawable = GetComponent<Drawable>();
    }

    public override void Invalidate()
    {
        var obj = GetValue();

        if (obj.IsTrue())
            drawable.SetEnabled(true);
        else
            drawable.SetEnabled(false);
    }
}
