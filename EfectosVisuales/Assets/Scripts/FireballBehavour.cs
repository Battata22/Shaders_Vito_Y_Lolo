using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Que se destruya la bola y que haga daño
public class FireballBehavour : BaseBall
{
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }

    protected override void Start()
    {
       base.Start();
    }

}
