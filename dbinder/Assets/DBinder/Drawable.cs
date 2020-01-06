using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Drawable : MonoBehaviour
{
    private Component target;

    private void Awake()
    {
        target = GetComponent<Graphic>();
        if (target != null) return;

        target = GetComponent<Renderer>();
        if (target != null) return;
    }

    public void SetEnabled(bool enable)
    {
        if (target == null) return;

        // this is mass
        if (target is MonoBehaviour mb)
            mb.enabled = enable;
        else if (target is Renderer r)
            r.enabled = enable;
    }
}
