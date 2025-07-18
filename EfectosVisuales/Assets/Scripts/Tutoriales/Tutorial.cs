using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Image tutorial1, t2, t3;
    [SerializeField] bool tuto1, tuto2, tuto3;
    [SerializeField] TextMeshProUGUI texto1, texto2, texto3;
    [SerializeField] float duration;
    private bool yaEsta = false;

    private void Start()
    {
       yaEsta = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && !yaEsta)
        {
            if(tuto1)
            {
                tutorial1.enabled = true;
                texto1.enabled = true;
            }
            else if(tuto2)
            {
               t2.enabled = true;
                texto2.enabled = true;
            }
            else if(tuto3)
            {
               t3.enabled = true;
                texto3.enabled = true;
            }
        
            Cursor.lockState = CursorLockMode.Locked;

            Invoke("ApagarTutorial", duration);
        }


    }

    private void ApagarTutorial()
    {
        if (tuto1)
        {
            tutorial1.enabled = false;
            texto1.enabled = false;
        }
        else if (tuto2)
        {
            t2.enabled = false;
            texto2.enabled = false;
        }
        else if (tuto3)
        {
            t3.enabled = false;
            texto3.enabled = false;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yaEsta = true;
    }
}
