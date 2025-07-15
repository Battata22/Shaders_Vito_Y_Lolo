using UnityEngine;

public class PostProcessManager : MonoBehaviour
{
    public static PostProcessManager instance;
    public Material lowHp;
    public Material regenHp;
    public Material meQuemo;
    public Material crearPCuraSlime;
    public Material crearPVida;
    public Material crearPMana;
    public float waitTimer;
    public float timer;
    public bool efectoPrendido = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

    }
    void Start()
    {
        efectoPrendido=false;

        lowHp.SetFloat("_PrendidoLowHP", 0);

        regenHp.SetFloat("_PrendidoHPRegen", 0);

        meQuemo.SetFloat("_PrendidoQuemar", 0);

        crearPCuraSlime.SetFloat("_CrearPCuraSlime", 0);

        crearPVida.SetFloat("_CrearPVida", 0);

        crearPMana.SetFloat("_CrearPMana", 0);

    }


    void Update()
    {
        waitTimer += Time.deltaTime;
        if (waitTimer >= timer && efectoPrendido == true) 
        {
            efectoPrendido = false;

            regenHp.SetFloat("_PrendidoHPRegen", 0);

            meQuemo.SetFloat("_PrendidoQuemar", 0);
        }
        #region comentado
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    lowHp.SetFloat("_PrendidoLowHP", 1);
        //}
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    regenHp.SetFloat("_PrendidoHPRegen", 1);
        //}
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    meQuemo.SetFloat("_PrendidoQuemar", 1);
        //} 
        #endregion
    }

    public void ActivarPCuraSlime() 
    { 
        if(regenHp.GetFloat("_CrearPCuraSlime") == 0)
        {
            waitTimer = 0;
            regenHp.SetFloat("_CrearPCuraSlime", 1);
            efectoPrendido = true;
        }
    }

    public void ActivarPVida()
    {
        if (regenHp.GetFloat("_CrearPVida") == 0)
        {
            waitTimer = 0;
            regenHp.SetFloat("_CrearPVida", 1);
            efectoPrendido = true;
        }
    }

    public void ActivarPMana()
    {
        if (regenHp.GetFloat("_CrearPMana") == 0)
        {
            waitTimer = 0;
            regenHp.SetFloat("_CrearPMana", 1);
            efectoPrendido = true;
        }
    }


    public void ActivarRegenHP()
    {
        if (regenHp.GetFloat("_PrendidoHPRegen") == 0)
        {
            waitTimer = 0;
            regenHp.SetFloat("_PrendidoHPRegen", 1);
            efectoPrendido = true;
        }
    }

    public void ActivarLowHP()
    {
        if (lowHp.GetFloat("_PrendidoLowHP") == 0)
        { 
            lowHp.SetFloat("_PrendidoLowHP", 1);
        }
    }

    public void DesactivarLowHP()
    {
        if (lowHp.GetFloat("_PrendidoLowHP") == 1)
        {
            lowHp.SetFloat("_PrendidoLowHP", 0);
            
        }
    }
    public void ActivarFuego()
    {
        if (meQuemo.GetFloat("_PrendidoQuemar") == 0)
        {
            waitTimer = 0;
            meQuemo.SetFloat("_PrendidoQuemar", 1);
            efectoPrendido = true;
        }
    }




}
