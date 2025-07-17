using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalderoBehaviour : MonoBehaviour, ICaldero
{
    [SerializeField] Material rojoColor, verdeColor, amarilloColor, violetaColor, aguaColor, rojoBurbuja, verdeBurbuja, amarilloBurbuja, azulBurbuja, violetaBurbuja, humoBlanco, humoRojo, humoVerde, humoAmarillo, humoVioleta;
    [SerializeField] Renderer aguarenderer, particulas, humito;
    [SerializeField] bool agua, rojo, verde, amarillo, violeta;
    [SerializeField] ParticleSystem humo;

    void Start()
    {
        var go = GetComponentsInChildren<Renderer>();
        foreach (var sel in go)
        {
            if (sel.gameObject.tag == "Agua")
            {
                aguarenderer = sel.GetComponent<Renderer>();
            }
        }

        var go1 = GetComponentsInChildren<Renderer>();
        foreach (var sel in go)
        {
            if (sel.gameObject.tag == "Particulas")
            {
                particulas = sel.GetComponent<Renderer>();
            }
        }
        //var go2 = GetComponentsInChildren<ParticleSystem>();
        //foreach (var sel in go)
        //{
        //    if (sel.gameObject.tag == "Humo")
        //    {
        //        humo = sel.GetComponent<ParticleSystem>();
        //    }
        //}
        //humito = humo.GetComponent<Renderer>();
        //print(humito);
        if (agua)
        {
            aguarenderer.material = aguaColor;
            particulas.material = azulBurbuja;
            humito.material = humoBlanco;
            //var colorLifeTime = humo.colorOverLifetime.color.color;
            //colorLifeTime = new ParticleSystem.MinMaxGradient(new ParticleSystem.MinMaxGradient(azulVector.x, azulVector.y, azulVector.z, azulVector.w));           
            //colorLifeTime = new Color(200, 200, 200, 25);
            // = new ParticleSystem.MinMaxGradient(new Color(azulVector.x,azulVector.y,azulVector.z,azulVector.w));
        }
        else if (rojo)
        {
            aguarenderer.material = rojoColor;
            humito.material = humoRojo;
            //var colorLifeTime = humo.colorOverLifetime.color;
            //colorLifeTime = new ParticleSystem.MinMaxGradient(new Color(236, 51, 64, 25));

        }
        else if (verde)
        {
            aguarenderer.material = verdeColor;
            humito.material = humoVerde;
            //var colorLifeTime = humo.colorOverLifetime.color;
            //colorLifeTime = new ParticleSystem.MinMaxGradient(new Color(4, 53, 0, 25));
        }
        else if (amarillo)
        {
            aguarenderer.material = amarilloColor;
            humito.material = humoAmarillo;
            //var colorLifeTime = humo.colorOverLifetime.color;
            //colorLifeTime = new ParticleSystem.MinMaxGradient(new Color(4, 53, 0, 25));
        }
        else if (violeta)
        {
            aguarenderer.material = violetaColor;
            humito.material = humoVioleta;
            //var colorLifeTime = humo.colorOverLifetime.color;
            //colorLifeTime = new ParticleSystem.MinMaxGradient(new Color(4, 53, 0, 25));
        }
    }
    
    public void ChangeMatRojo()
    {
        ResetBools();
        rojo = true;
        aguarenderer.material = rojoColor;
        particulas.material = rojoBurbuja;
        humito.material = humoRojo;
        //var colorLifeTime = humo.colorOverLifetime.color;
        //colorLifeTime = new ParticleSystem.MinMaxGradient(new Color(236, 51, 64, 25));
    }

    public void ChangeMatVerde()
    {
        ResetBools();
        verde = true;
        aguarenderer.material = verdeColor;
        particulas.material = verdeBurbuja;
        humito.material = humoVerde;

        //var colorLifeTime = humo.colorOverLifetime.color;
        //colorLifeTime = new ParticleSystem.MinMaxGradient(new Color(4, 53, 0, 25));
    }
    public void ChangeMatAmarillo()
    {
        ResetBools();
        amarillo = true;
        aguarenderer.material = amarilloColor;
        particulas.material = amarilloBurbuja;
        humito.material = humoAmarillo;

        //var colorLifeTime = humo.colorOverLifetime.color;
        //colorLifeTime = new ParticleSystem.MinMaxGradient(new Color(4, 53, 0, 25));
    }
    public void ChangeMatVioleta()
    {
        ResetBools();
        violeta = true;
        aguarenderer.material = violetaColor;
        particulas.material = violetaBurbuja;
        humito.material = humoVioleta;

        //var colorLifeTime = humo.colorOverLifetime.color;
        //colorLifeTime = new ParticleSystem.MinMaxGradient(new Color(4, 53, 0, 25));
    }

    public void ResetBools()
    {
        agua = false;
        rojo = false;
       verde = false;
       amarillo = false;
       violeta = false;

    }
    public void DetectMaterial()
    {
        if(verde == true)
        {
            PostProcessManager.instance.ActivarRegenHP();
            EntityManager.instance.player.FullLife();

        }
        if (amarillo == true)
        {
            PostProcessManager.instance.ActivarPCuraSlime();

        }
        if (rojo == true)
        {
            PostProcessManager.instance.ActivarPVida();
            EntityManager.instance.player.FullLife();

        }
        if (violeta == true)
        {
            PostProcessManager.instance.ActivarPMana();
            

        }

    }
}
