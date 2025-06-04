using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalderoBehaviour : MonoBehaviour, ICaldero
{
    // Start is called before the first frame update
    void Start()
    {
        mio = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Material rojo, violeta, verde, agua;
    public Renderer mio;
    public void ChangeMat()
    {
        mio.material = rojo;
    }
}
