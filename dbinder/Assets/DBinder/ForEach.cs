using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForEach : BindRoot
{
    public string property;

    [HideInInspector]
    public bool isClone = false;

    private ForEach original;
    private BindRoot root;

    private List<GameObject> clones = new List<GameObject>();

    protected override void Awake()
    {
        base.Awake();

        root = transform.parent.GetComponentInParent<BindRoot>();
        root.Subscribe(this);
    }
    private void Start()
    {
        if (isClone)
            root.Unsubscribe(this);
        else
            gameObject.SetActive(false);
    }

    public override void Invalidate()
    {
        if (isClone)
        {
            base.Invalidate();
            return;
        }

        DestroyAllClones();

        var value = root.Get(property);
        var iter = value as IEnumerable;
        if (iter == null) return;
        foreach (var v in iter)
        {
            var c = Instantiate(gameObject, transform.parent);
            var fe = c.GetComponent<ForEach>();
            fe.isClone = true;
            fe.original = this;
            fe.context = v;
            c.SetActive(true);
            fe.Invalidate();

            clones.Add(c);
        }
    }
    private void DestroyAllClones()
    {
        foreach (var c in clones)
            Destroy(c);
    }
}
