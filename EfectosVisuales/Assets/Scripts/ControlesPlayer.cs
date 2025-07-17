using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesPlayer
{
    Proyectiles script;
    Player playerScript;
    public static event Action disparar;
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
    }
    void DeteccionDeDisparo()
    {
        if (Input.GetKeyDown(script.throwKey) && script.readyToThrow && script.totalThrows > 0 && playerScript.mana > playerScript.manaCost)
        {
            //script.Throw();
            disparar();
        }
    }

    void CambioDeBolas()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            script.objectToThrow = script.balls[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            script.objectToThrow = script.balls[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            script.objectToThrow = script.balls[2];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            script.objectToThrow = script.balls[3];
        }
    }
}
