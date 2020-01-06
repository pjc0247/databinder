using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockupRoot : BindRoot
{
    protected override void Awake()
    {
        base.Awake();

        context = new
        {
            ary = new int[] { 1, 2, 3, 4 }
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            var rd = new List<int>();
            for (int i = 0; i < Random.RandomRange(0, 10); i++)
            {
                rd.Add(i);
            }
            Debug.Log(rd.Count);
            context = new
            {
                ary = rd.ToArray()
            };
            Invalidate();
        }
    }
}
