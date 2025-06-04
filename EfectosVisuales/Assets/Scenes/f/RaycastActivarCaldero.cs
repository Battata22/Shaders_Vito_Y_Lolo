using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastActivarCaldero : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DarPocion();
        }
    }

    void DarPocion()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Camera.main.ViewportToScreenPoint(transform.position), out hit))
        {
            if (hit.collider.gameObject.GetComponent<ICaldero>() != null)
            {
                hit.collider.gameObject.GetComponent<ICaldero>().ChangeMat();
            }
        }

    }

    private void OnDrawGizmos()
    {
        Physics.Raycast(transform.position, Camera.main.ViewportToScreenPoint(transform.position));
    }
}

public interface ICaldero
{
    public void ChangeMat();
}
