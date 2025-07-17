using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : CharacterBase
{
    [SerializeField] List<GameObject> checkpoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] bool dead = false;
    public int Damage { get { return damage; } }
    protected override void Start()
    {
        base.Start();
        EntityManager.instance.player = this;
    }
    private void Update()
    {
        if (dead == true)
        {
            this.transform.position = vectorPoint;
            FullLife();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        vectorPoint = this.transform.position;
        Destroy(other.gameObject);
    }

    public void GetDamage(int damage)
    {
        life -= damage;

        if (life >= 50) 
        {
            PostProcessManager.instance.DesactivarLowHP();
        }
        else if(life < 50 && life > 0)
        {
            PostProcessManager.instance.ActivarLowHP();
        }
        else if(life <= 0)
        {
            dead = true;
            //SceneManager.LoadScene(0);
        }
    }

    public void FullLife()
    {
        life = maxlife;
        dead = false;
        GetDamage(0);
    }

}







