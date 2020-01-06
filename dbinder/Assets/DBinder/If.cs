using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class If : Bind
{
    public override void Invalidate()
    {
        var obj = GetValue();

        if (obj.IsTrue())
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
