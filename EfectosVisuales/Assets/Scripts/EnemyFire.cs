using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : CharacterBase, IEnemy
{
    protected override void Start()
    {
        base.Start();
    }

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

}
