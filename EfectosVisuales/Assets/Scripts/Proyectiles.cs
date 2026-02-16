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

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    public bool readyToThrow;
    ControlesPlayer controlesScript;
    Player playerScript;

    private void Start()
    {
        readyToThrow = true;
        ControlesPlayer.disparar += Throw;
        playerScript = GetComponent<Player>();
        controlesScript = new ControlesPlayer(this);
        controlesScript.ArtificialStart();
    }

    private void Update()
    {
        controlesScript.ArtificialUpdate();
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
        //llamado de la funcion de mana
        playerScript.ManaCostMet();

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}