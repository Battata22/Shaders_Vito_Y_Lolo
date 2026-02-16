using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesPlayer
{
    // Struct & Evento

    Proyectiles script;
    Player playerScript;
    public static event Action disparar;
    StructBolas[] StructBolas;
    public ControlesPlayer(Proyectiles pepe)
    {
        script = pepe;
    }
    public void ArtificialUpdate()
    {
        DeteccionDeDisparo();
        CambioDeBolas();        
    }
    public void ArtificialStart()
    {
        playerScript = EntityManager.instance.player;

        StructBolas = new StructBolas[script.balls.Length];

        SetStructBolas();
    }

    void SetStructBolas()
    {
        for (int i = 0; i < StructBolas.Length; i++)
        {
            StructBolas[i].Set(script.balls[i]);

            if (i == 0)
            {
                StructBolas[i].ActivationKey = KeyCode.Alpha1;
            }
            else if (i == 1)
            {
                StructBolas[i].ActivationKey = KeyCode.Alpha2;
            }
            else if (i == 2)
            {
                StructBolas[i].ActivationKey = KeyCode.Alpha3;
            }
            else if (i == 3)
            {
                StructBolas[i].ActivationKey = KeyCode.Alpha4;
            }
        }
    }

    void DeteccionDeDisparo()
    {
        if (Input.GetKeyDown(script.throwKey) && script.readyToThrow && script.totalThrows > 0 && playerScript.Mana > playerScript.manaCost)
        {
            disparar();
        }
    }

    void CambioDeBolas()
    {

        for (int i = 0; i < StructBolas.Length; i++)
        {
            if (Input.GetKeyDown(StructBolas[i].ActivationKey))
            {
                script.objectToThrow = StructBolas[i].Bola;
            }
        }

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    script.objectToThrow = script.balls[0];
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    script.objectToThrow = script.balls[1];
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    script.objectToThrow = script.balls[2];
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    script.objectToThrow = script.balls[3];
        //}
    }
}
