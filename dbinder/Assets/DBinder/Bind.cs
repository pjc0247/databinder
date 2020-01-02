using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Representable))]
public class Bind : Observer
{
    public string property;

    private BindRoot root;
    private Representable representable;

    private void Awake()
    {
        root = GetComponentInParent<BindRoot>();
        representable = GetComponent<Representable>();

        root.Subscribe(this);
    }

    public override void Invalidate()
    {
        Debug.Log("Invalidate " + property);

        if (property == "$self")
            representable.SetText(root.context.ToString());
        else
        {
            representable.SetText(root.Get(property).ToString());
        }
    }
}
