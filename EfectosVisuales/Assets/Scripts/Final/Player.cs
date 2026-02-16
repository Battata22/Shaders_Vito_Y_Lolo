using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : CharacterBase
{
    // Get & Set

    [SerializeField] List<GameObject> checkpoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] bool dead = false; //para checkpoints
    //[SerializeField] float rotacionInicio;

    [Header("Sistema de Mana")]
    [SerializeField] float mana;
    public float Mana {  get { return mana; } private set { mana = value; } }
    [SerializeField] float maxMana;
    public float MaxMana { get { return maxMana; } private set { maxMana = value; } }

    [SerializeField] public float manaCost;
    public float ManaCost { get { return manaCost; } private set { manaCost = value; } }

    [SerializeField] float manaRegen;
    public float ManaRegen { get { return manaRegen; } private set { manaRegen = value; } }


    [Header("Barras Canvas")]
    public Image healthBar;
    public Image manaBar;

    public int Damage { get { return damage; } private set { damage = value; } }


    protected override void Start()
    {
        base.Start();
        EntityManager.instance.player = this;
        mana = maxMana;
        ControlesPlayer.disparar += ManaCostMet;

        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Cursor.lockState = CursorLockMode.None;

            Cursor.visible = true;
        }

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
        if(other.gameObject.layer != 9)
        {
            Destroy(other.gameObject);
        }
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
    public void ManaCostMet()
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







