using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    // Diccionario

    [SerializeField] Image photoCanvas;
    [SerializeField] TextMeshProUGUI textoCanvas;
    [SerializeField] float duration;

    [SerializeField] string[] Dialogos;

    [SerializeField] Dictionary<int, string> _dicString = new Dictionary<int, string>();

    public static Tutorial instance;
    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        for (int i = 0; i < Dialogos.Length; i++)
        {
            _dicString.Add(int.Parse(Dialogos[i][0].ToString()), Dialogos[i].Substring(3)); 
        }
    }

    public void Execute(int TutoNumber, TutorialCollider script)
    {
        photoCanvas.enabled = true;
        textoCanvas.text = _dicString[TutoNumber];
        textoCanvas.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(ApagarTutorial(script));
    }

    IEnumerator ApagarTutorial(TutorialCollider script)
    {
        yield return new WaitForSeconds(duration);

        photoCanvas.enabled = false;
        textoCanvas.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        script.yaEsta = true;
    }

}
