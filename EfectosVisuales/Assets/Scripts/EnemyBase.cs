using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBase : CharacterBase, IEnemy
{
    [SerializeField] protected EnemyType type;
    Animator animator;
    public NavMeshAgent enemyAgent;
    public Collider colliderEnemy;

    public float timer = 2;
    [Header("Base variables")]
    [SerializeField] protected int enemyDmg;
    [SerializeField] protected float enemySpeed;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float cooldownAttack;
    [SerializeField] protected float timerAttack = 0f;

    [Header("Objects a asignar")]
    [SerializeField] protected Transform playerTarget;
    [SerializeField] float radio, radio2, radio3;

    [SerializeField] LayerMask playerLayer;
    Vector3 dir;

    public static event Action meMuero;

    //private Transform targetTransform;
    
    public void TakeDamage(int damage)
    {
        if (life - damage >= 0)
        {
            life -= damage;
        }
        else
        {
            animator.SetBool("IsDead", true);
            enemyAgent.speed = 0;
            colliderEnemy.enabled = false;
            timer -= Time.deltaTime;
            if (timer <=0)
            {            
                Destroy(gameObject);  
            }          
        }
    }

    protected override void Start()
    {
        base.Start();
        enemyAgent = GetComponent<NavMeshAgent>();       
        animator = GetComponent<Animator>();
        colliderEnemy = GetComponent<Collider>();
    }
    protected void Update()
    {
        animator.SetBool("IsWalking", false);
        LookForPlayer();
        Animation();
    }
    protected virtual void OnDestroy()
    {
        meMuero();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
        Gizmos.DrawWireSphere(transform.position, radio2);
        Gizmos.DrawWireSphere(transform.position, radio3);
    }

    protected void LookForPlayer()
    {
        var cosas = Physics.OverlapSphere(transform.position, radio, playerLayer);
        foreach (var c in cosas)
        {
            enemyAgent.SetDestination(EntityManager.instance.player.transform.position);  
        }
    }
    protected void Animation()
    {
        var range = Physics.OverlapSphere(transform.position, radio2, playerLayer);
        foreach(var c in range)
        {
            animator.SetBool("IsWalking", true);
        }
        var rangeAttack = Physics.OverlapSphere(transform.position, radio3, playerLayer);
        foreach (var c in rangeAttack)
        {
            animator.SetTrigger("IsNearby");
        }
    }
}

public enum EnemyType
{
    Water, Fire, Rock 
}

