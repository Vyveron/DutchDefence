using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Aim : MonoBehaviour
{
    public Transform Target { get; private set; }
    public bool HasTarget { get; private set; }
    public UnityEvent onRefreshTarget = new UnityEvent();

    [SerializeField] protected AimHandler aimHandler;
    protected List<Transform> targets = new List<Transform>();


    protected virtual void Start()
    {
        aimHandler.onEnemyEntersRange.AddListener(AddTarget);
        aimHandler.onEnemyLeavesRange.AddListener(RemoveTarget);
    }
    protected void RefreshTarget()
    {
        if(targets.Count == 0)
        {
            Target = null;
            HasTarget = false;
            return;
        }

        Target = targets[0];

        onRefreshTarget.Invoke();
    }
    protected void RemoveTarget(Collider2D target)
    {
        if (target != null)
        {
            targets.Remove(target.transform);
        }
        RefreshTarget();
    }

    public virtual void AddTarget(Collider2D target)
    {
        targets.Add(target.transform);
        if(targets.Count == 1)
        {
            RefreshTarget();
        }

        HasTarget = true;
    }
}
