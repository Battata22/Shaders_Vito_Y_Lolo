using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            PostProcessManager.instance.ActivarLava();
            EntityManager.instance.player.GetDamage(25);
        } 
    }
}
