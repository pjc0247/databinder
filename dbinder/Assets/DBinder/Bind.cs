using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bind : Observer
{
    public string property;

    protected BindRoot root;

    protected virtual void Awake()
    {
        root = GetComponentInParent<BindRoot>();
        root.Subscribe(this);
    }

    protected object GetValue()
    {
        if (property == "$self")
            return root.context;
        else
            return root.Get(property);
    }
}
