using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBall : MonoBehaviour
{
    [SerializeField] protected Player playerScript;
    [SerializeField] protected int mult;


    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.collider != EntityManager.instance.player.GetComponent<Collider>())
        {
            if (collision.gameObject.GetComponent<IEnemy>() != null)
            {
                collision.gameObject.GetComponent<IEnemy>().TakeDamage(playerScript.Damage * mult);
            }
            Destroy(gameObject);
        }
    }

    protected virtual void Start()
    {
        playerScript = EntityManager.instance.player;
    }
}
