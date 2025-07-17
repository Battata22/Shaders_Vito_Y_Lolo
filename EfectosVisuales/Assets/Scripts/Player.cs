using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : CharacterBase
{
    [SerializeField] List<GameObject> checkpoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] bool dead = false; //para checkpoints

    [Header("Sistema de Mana")]
    [SerializeField] public float mana;
    [SerializeField] float maxMana;
    [SerializeField] public float manaCost;
    [SerializeField] float manaRegen;

    [Header("Barras Canvas")]
    public Image healthBar;
    public Image manaBar;

    public int Damage { get { return damage; } }
    protected override void Start()
    {
        base.Start();
        EntityManager.instance.player = this;
        mana = maxMana;
        ControlesPlayer.disparar += ManaCost;
    }
    private void Update()
    {
        ManaSystem();
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

        //Canvas 
        healthBar.fillAmount = life / 100f;

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

        //Checkpoints purposes
        dead = false;

        GetDamage(0);

        //Canvas
        healthBar.fillAmount = life / 100f;
    }
    public void ManaSystem()
    {
        if (mana < maxMana && mana >= 0)
        {
            mana += manaRegen * Time.deltaTime;
        }
        else if(mana > maxMana)
        {
            mana = maxMana;
        }
        
        //Canvas
        manaBar.fillAmount = mana / 100f;
    }
    public void ManaCost()
    {
        mana -= manaCost;
        if (mana < 0)
        {
            mana = 0;
        }
        //Canvas
        manaBar.fillAmount = mana / 100f;
    }

    public void SumarMana(int suma)
    {
        mana += suma;
        if (mana >= 100)
        {
            mana = 100;
        }
    }
}







