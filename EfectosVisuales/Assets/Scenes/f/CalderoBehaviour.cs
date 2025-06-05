using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalderoBehaviour : MonoBehaviour, ICaldero
{
    [SerializeField] Material rojoColor, verdeColor, aguaColor;
    [SerializeField] Renderer aguarenderer;
    [SerializeField] bool agua, rojo, verde;

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

        if (agua)
        {
            aguarenderer.material = aguaColor;
        }
        else if (rojo)
        {
            aguarenderer.material = rojoColor;
        }
        else if (verde)
        {
            aguarenderer.material = verdeColor;
        }
    }

    public void ChangeMatRojo()
    {
        aguarenderer.material = rojoColor;
    }

    public void ChangeMatVerde()
    {
        aguarenderer.material = verdeColor;
    }
}
