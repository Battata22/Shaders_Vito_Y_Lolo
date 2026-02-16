using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCollider : MonoBehaviour
{
    [SerializeField] int _tutoNumber;
    public bool yaEsta;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && !yaEsta)
        {
            Tutorial.instance.Execute(_tutoNumber, this);
        }
    }
}
