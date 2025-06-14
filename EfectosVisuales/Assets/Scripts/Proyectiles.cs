using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics.Tracing;
using System;

public class Proyectiles : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public BaseBall objectToThrow;
    public BaseBall[] balls;
    //public event Action Evento;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    public bool readyToThrow;
    ControlesPlayer controlesScript;

    private void Start()
    {
        readyToThrow = true;
        //Evento += Throw;
        //PruebaDeEvento.instance.eventoTest += Throw;
        controlesScript = new ControlesPlayer(this);
    }

    private void Update()
    {
        controlesScript.ArtificialUpdate();

        //if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        //{
        //    //Evento();
        //    Throw();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    objectToThrow = balls[0];
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha2)) 
        //{ 
        //    objectToThrow = balls[1]; 
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    objectToThrow = balls[2];
        //}



    }

    public void Throw()
    {
        readyToThrow = false;

        //instancia objeto a tirar
        var projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        //rigidbody
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        //calcular direccion
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        } 

        //Fuerza añadida
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}