using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BotonesFinish : MonoBehaviour
{
    [SerializeField] Image ParaMeeeee;
    [SerializeField] Button boton;
    [SerializeField] TextMeshProUGUI _text;

    private void Start()
    {
        ParaMeeeee = GetComponent<Image>();
        boton = GetComponent<Button>();
        _text = GetComponentInChildren<TextMeshProUGUI>();

        print(Finish.instance.gameObject.name);

        Finish.instance.Finished += Activate;
        Finish.instance.RetryEvent += DeActivate;
    }

    void Activate()
    {
        ParaMeeeee.enabled = true;
        boton.enabled = true;
        _text.enabled = true;
    }

    void DeActivate()
    {
        ParaMeeeee.enabled = false;
        boton.enabled = false;
        _text.enabled = false;
    }
}
