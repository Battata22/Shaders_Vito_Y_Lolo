using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesPlayer
{
    Proyectiles script;
    public ControlesPlayer(Proyectiles pepe)
    {
        script = pepe;
    }
    
    
    public void ArtificialUpdate()
    {
        DeteccionDeDisparo();
        CambioDeBolas();
        
    }

    void DeteccionDeDisparo()
    {
        if (Input.GetKeyDown(script.throwKey) && script.readyToThrow && script.totalThrows > 0)
        {
            script.Throw();
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
    }
}
