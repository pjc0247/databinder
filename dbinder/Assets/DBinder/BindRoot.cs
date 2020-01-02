using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathscript;

public class BindRoot : Observer
{
    public string key;

    public object context;
    public bool testobj = false;

    private HashSet<Observer> observers = new HashSet<Observer>();

    private void Awake()
    {
        context = new
        {
            ary = new int[] {1,2,3,4}
        };
    }
    private void Start()
    {
        Invalidate();
    }

    private void Update()
    {
        if (testobj == false) return;
        if (Input.GetKeyDown(KeyCode.F2))
        {
            var rd = new List<int>();
            for (int i=0;i<Random.RandomRange(0, 10); i++)
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

    public override void Invalidate()
    {
        var clone = new HashSet<Observer>(observers);
        foreach (var obs in clone)
            obs.Invalidate();
    }
    public object Get(string path)
    {
        return PScript.Eval(context, path);
    }

    public void Subscribe(Observer obs)
    {
        observers.Add(obs);
    }
    public void Unsubscribe(Observer obs)
    {
        observers.Remove(obs);
    }
}
