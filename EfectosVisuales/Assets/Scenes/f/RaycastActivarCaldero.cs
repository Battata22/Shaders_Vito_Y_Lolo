using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastActivarCaldero : MonoBehaviour
{

    [SerializeField] float rango;
    [SerializeField] List<Pociones> inventario;
    [SerializeField] TextMeshProUGUI textInventario;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            VolcarPocion();

            AgarrarPocion();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void ActualizarTexto()
    {
        if (inventario.Count <= 0)
        {
            textInventario.text = "";
            return;
        }
        else if (inventario.Count == 1)
        {
            textInventario.text = "Inventario: " + inventario[0].name;
        }
        else if (inventario.Count == 2)
        {
            textInventario.text = "Inventario: " + inventario[0].name + ", " + inventario[1].name;
        }
        else if (inventario.Count == 3)
        {
            textInventario.text = "Inventario: " + inventario[0].name + ", " + inventario[1].name + ", " + inventario[2].name;
        }
        else
        {
            textInventario.text = "Para cuanto queres agarrar hermano";
        }
    }

    void AgarrarPocion()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider.gameObject.GetComponent<Pociones>() != null)
            {
                inventario.Add(hit.collider.gameObject.GetComponent<Pociones>());
                hit.collider.gameObject.SetActive(false);
                ActualizarTexto();
            }
        }
    }

    void VolcarPocion()
    {
        if (inventario.Count > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit))
            {
                if (hit.collider.gameObject.GetComponent<ICaldero>() != null)
                {
                    if (inventario[0].pocionRoja)
                    {
                        hit.collider.gameObject.GetComponent<ICaldero>().ChangeMatRojo();
                        inventario.RemoveAt(0);
                        ActualizarTexto();
                    }
                    else if (inventario[0].pocionVerde)
                    {
                        hit.collider.gameObject.GetComponent<ICaldero>().ChangeMatVerde();
                        inventario.RemoveAt(0);
                        ActualizarTexto();
                    }                        
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Camera.main.transform.forward);
    }
}

public interface ICaldero
{
    public void ChangeMatVerde();
    public void ChangeMatRojo();

}
