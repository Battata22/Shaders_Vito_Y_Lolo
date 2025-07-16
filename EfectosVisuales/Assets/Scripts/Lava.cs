using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print("pito2");
        if (collision.gameObject.layer == 3)
        {
            print("pito");
            PostProcessManager.instance.ActivarFuego();
            
        } 

    }
}
