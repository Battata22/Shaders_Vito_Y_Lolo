using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyBase : CharacterBase, IEnemy
{
    [SerializeField] protected EnemyType type;
    public static event Action meMuero;
    public void TakeDamage(int damage)
    {
        if (life - damage >= 0)
        {
            life -= damage;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected override void Start()
    {
        base.Start();
    }

    protected virtual void OnDestroy()
    {
        meMuero();
    }
}

public enum EnemyType
{
    Water, Fire, Rock 
}

