using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathscript;

public class BindRoot : Observer
{
    public string key;
    public object context;

    private HashSet<Observer> observers = new HashSet<Observer>();

    protected virtual void Awake()
    {
    }
    private void Start()
    {
        Invalidate();
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
