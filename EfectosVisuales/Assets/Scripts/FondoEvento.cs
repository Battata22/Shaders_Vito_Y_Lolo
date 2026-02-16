using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FondoEvento : MonoBehaviour
{
    [SerializeField] Image ParaMeeeee;

    private void Start()
    {
        ParaMeeeee = GetComponent<Image>();

        Finish.instance.Finished += Activate;
        Finish.instance.RetryEvent += DeActivate;
    }

    void Activate()
    {
        ParaMeeeee.enabled = true;
    }

    void DeActivate()
    {
        ParaMeeeee.enabled = false;
    }
}
