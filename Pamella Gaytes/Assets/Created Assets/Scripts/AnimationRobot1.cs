using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRobot1 : MonoBehaviour {
    
    public Transform player;
    public float rotationSpeed;
    static Animator animator;

    private System.Random rnd = new System.Random();
    private int randomized;
    private float timeTarget5;
    private float timeTarget05;
    private bool attacking;
    private bool idleTempo;

    void Start ()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isIdle", true);
        animator.SetBool("isAttacking", false);
        animator.SetBool("typeAttack", false);
        animator.SetBool("isDead", false);
        timeTarget5 = 5.0f;
        timeTarget05 = 0.5f;
        attacking = false;
        idleTempo = false;
    }
	
	void Update ()
    {
        if (animator.GetBool("isDead") || animator.GetInteger("Life") <= 0)
            Dead();
        else
        {
            Vector3 direction = player.position - transform.position;
            direction.y = -0.5f;
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle >= 5.0f)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed);
            else
            {
                timeTarget5 -= Time.deltaTime;
                if (timeTarget5 <= 0)
                {
                    randomized = rnd.Next(0, 3);
                    if (!attacking && (randomized == 0 || randomized == 1) && animator.GetBool("isIdle")) //Attack
                    {
                        if (randomized == 0)
                            Attack_Smash();
                        else
                            Attack2();
                        attacking = true;
                    }
                    else if (attacking && timeTarget05 > 0)
                        timeTarget05 -= Time.deltaTime;
                    else if (attacking && timeTarget05 <= 0)
                    {
                        attacking = false;
                        timeTarget5 = 5.0f;
                        timeTarget05 = 0.5f;
                        idleTempo = true;
                        Idle();
                    }
                }
            }
        }
    }

    public void Idle(){animator.SetBool("isIdle",true);animator.SetBool("isAttacking",false);animator.SetBool("typeAttack",false);animator.SetBool("isDead",false);}
    public void Attack_Smash(){animator.SetBool("isIdle",false);animator.SetBool("isAttacking",true);animator.SetBool("typeAttack",false);animator.SetBool("isDead",false);}
    public void Attack2(){animator.SetBool("isIdle",false);animator.SetBool("isAttacking",true);animator.SetBool("typeAttack",true);animator.SetBool("isDead",false);}
    public void Dead(){animator.SetBool("isIdle",false);animator.SetBool("isAttacking",false);animator.SetBool("typeAttack",false);animator.SetBool("isDead",true);}
    
}
