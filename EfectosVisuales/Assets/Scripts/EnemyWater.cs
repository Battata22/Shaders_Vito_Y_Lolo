using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWater : CharacterBase, IEnemy
{
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
    }
}
