using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] 
    public void Salir()
    {
        Application.Quit();
    }
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == EntityManager.instance.player)
        {

        }
    }
}
