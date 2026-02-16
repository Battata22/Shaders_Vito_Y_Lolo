using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    // Evento

    public event Action Finished;
    public event Action RetryEvent;

    public static Finish instance;
    private void Awake()
    {
        instance = this;
    }

    public void Salir()
    {
        Application.Quit();
    }
    public void Retry()
    {

        RetryEvent?.Invoke();

        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Finished?.Invoke();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
