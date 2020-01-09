using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Attacking : MonoBehaviour
{
    [HideInInspector] public float _damage;
    [HideInInspector] public float _attackRate;
    public UnityEvent onAttack = new UnityEvent();

    protected abstract void Attack();
}
