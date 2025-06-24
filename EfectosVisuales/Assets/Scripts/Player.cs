using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : CharacterBase
{
    public int Damage { get { return damage; } }
    protected override void Start()
    {
        base.Start();
        EntityManager.instance.player = this;
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
            SceneManager.LoadScene(0);
        }
    }

    public void FullLife()
    {
        life = maxlife;
        GetDamage(0);
    }

}







