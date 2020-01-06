using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EvalRule
{
    public static bool IsTrue(this object _this)
    {
        if (_this == null) return false;
        if (_this is bool b && b == false) return false;

        return true;
    }
}
