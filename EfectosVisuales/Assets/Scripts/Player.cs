using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase
{
    public int Damage { get { return damage; } }
    protected override void Start()
    {
        base.Start();
        EntityManager.instance.player = this;
    }

}







