using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaDeEvento : MonoBehaviour
{
    public static PruebaDeEvento instance;
    public event Action eventoTest;
    int muertes;
    void Start()
    {
        instance = this;
        eventoTest += A;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            eventoTest();
        }
    }

    private void A()
    {
        print("evento");
        print("Llevas: " + muertes);
    }
}
