using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationZombie : MonoBehaviour {

    static Animator animator;
    public float attackRange;
    public float viewDistance;
    public GameObject[] players;
    NavMeshAgent agent;
    private float init_speed;
    public bool isSpecial;

    public float timeBtwAttack;
    public float time2Despawn = 10.0f;
    private float init_time;

    Transform min;


    void Start ()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isDead", false);
        animator.SetBool("isWalking", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("takeDamage", false);
        
        agent = GetComponent<NavMeshAgent>();
        init_speed = agent.speed;
        init_time = timeBtwAttack;
    }
	

	void Update ()
    {
        if (players.GetLength(0) == 0)
            players = GameObject.FindGameObjectsWithTag("Player");


        if (animator.GetBool("isDead"))
        {
            Death();
            time2Despawn -= Time.deltaTime;
            if (time2Despawn <= 0)
                Destroy(gameObject);
        }
        else
        {
            min = GameObject.FindGameObjectWithTag("Player").transform;
            if (isOnVision(min))
                Mouv(min);
            else
                Idle();
        }
	}

    private void Mouv(Transform target)
    {
        agent.SetDestination(target.position);
        Vector3 direction = target.position - transform.position;
        direction.y = 0.0f;
        float angle = Vector3.Angle(direction, transform.forward);

        if (Vector3.Distance(direction, transform.position) > attackRange)
        {
            if (angle > 0)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f); 
            else
            {
                Walk();
                agent.speed = init_speed;
            }
        }
        else
        {
            agent.speed = 0;
            timeBtwAttack -= Time.deltaTime;
            if (timeBtwAttack <= 0)
            {
                Attack();
                timeBtwAttack = init_time;
            }
            else
            {
                Idle();
            }
        }
    }

    private bool isOnVision(Transform target)
    {
        bool isonvision = false;
        Vector3 direction = target.position - transform.position;
        direction.y = 0.0f;
        float angle = Vector3.Angle(direction, transform.forward);
        if (angle >= 45 || Vector3.Distance(transform.position, direction) > viewDistance)
            isonvision = false;
        else
            isonvision = true;
        return isonvision;
    }
    
    private void Idle(){animator.SetBool("isDead",false);animator.SetBool("isWalking",false);animator.SetBool("isAttacking",false);animator.SetBool("takeDamage", false);}
    private void Attack(){animator.SetBool("isDead",false);animator.SetBool("isWalking",false);animator.SetBool("isAttacking",true);animator.SetBool("takeDamage", false);}
    private void Walk(){animator.SetBool("isDead",false); animator.SetBool("isWalking",true); animator.SetBool("isAttacking",false); animator.SetBool("takeDamage",false);}
    private void Damaged(){animator.SetBool("isDead",false);animator.SetBool("takeDamage",true);}
    private void Death(){animator.SetBool("isDead",true);}
}
