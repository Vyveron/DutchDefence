using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class AimHandler : MonoBehaviour
{
    public AttackTowerProfileHandler profileHandler;
    public InComeEvent onEnemyEntersRange = new InComeEvent();
    public InComeEvent onEnemyLeavesRange = new InComeEvent();
    public float Range { get { return col.radius; } set { col.radius = value; } }

    protected CircleCollider2D col;


    private void Start()
    {
        col = GetComponent<CircleCollider2D>();
        Range = profileHandler.data.range;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        onEnemyEntersRange.Invoke(collision);
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        onEnemyLeavesRange.Invoke(collision);
    }

    public class InComeEvent : UnityEvent<Collider2D> { }
}
