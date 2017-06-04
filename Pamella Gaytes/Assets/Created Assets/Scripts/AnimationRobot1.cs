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
            Vector3 direction = player.position - this.transform.position;
            direction.y = -0.5f;
            float angle = Vector3.Angle(direction, this.transform.forward);

            if (angle >= 5.0f)
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed);
            else
            {
                //if (!idleTempo)
                //{
                    timeTarget5 -= Time.deltaTime;
                    if (timeTarget5 <= 0)
                    {
                        randomized = rnd.Next(0, 3);
                        if (!attacking && (randomized == 0 || randomized == 1) && animator.GetBool("isIdle")) //Attack
                        {
                            if (randomized == 0)
                                Attack1();
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
                /*}
                else
                {
                    Idle();
                    if (timeTarget2 > 0)
                        timeTarget2 -= Time.deltaTime;
                    else
                    {
                        timeTarget2 = 2.0f;
                        idleTempo = false;
                    }
                }*/

            }
        }
    }

    public void Idle(){animator.SetBool("isIdle",true);animator.SetBool("isAttacking",false);animator.SetBool("typeAttack",false);animator.SetBool("isDead",false);}
    public void Attack1(){animator.SetBool("isIdle",false);animator.SetBool("isAttacking",true);animator.SetBool("typeAttack",false);animator.SetBool("isDead",false);}
    public void Attack2(){animator.SetBool("isIdle",false);animator.SetBool("isAttacking",true);animator.SetBool("typeAttack",true);animator.SetBool("isDead",false);}
    public void Dead(){animator.SetBool("isIdle",false);animator.SetBool("isAttacking",false);animator.SetBool("typeAttack",false);animator.SetBool("isDead",true);}

    /*WaitForSeconds(4.2f);
    Debug.Log("4.2");
    randomized = rnd.Next(0, 3);
    if ((randomized == 0 || randomized == 1) && animator.GetInteger("Life") > 0 && animator.GetBool("isIdle")) //isAttack
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isAttacking", true);
        if (randomized == 0)
            animator.SetBool("typeAttack", true);
        else
            animator.SetBool("typeAttack", false);
        WaitForSeconds(0.5f);
        Debug.Log("1");
    }

    if (animator.GetInteger("Life") > 0) //back to idle position
    {
        animator.SetBool("isIdle", true);
        animator.SetBool("isAttacking", false);
        animator.SetBool("typeAttack", false);
        WaitForSeconds(2.0f);
    }
    else // Life <= 0
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("typeAttack", false);
        animator.SetBool("isDead", true);
    }*/


}
