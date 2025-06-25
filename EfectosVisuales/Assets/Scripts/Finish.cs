using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject fondo, boton01, boton02;
    
    public void Salir()
    {
        Application.Quit();
    }
    public void Retry()
    {
        fondo.SetActive(false);
        boton01.SetActive(false);
        boton02.SetActive(false);
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            fondo.SetActive(true);
            boton01.SetActive(true);
            boton02.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
