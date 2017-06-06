
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    static Animator animator;

    public float health;
    private float time2Death = 15.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        animator.SetBool("isDead", false);
        animator.SetBool("takeDamage", true);
        if (health <= 0f)
            Die();
    }

    void Die()
    {
        time2Death -= Time.deltaTime;
        animator.SetBool("isDead", true);
        if (time2Death <= 0)
        {
            Destroy(gameObject);
            if (gameObject.GetComponent<AnimationZombie>().isSpecial)
            {
                addLetter();
            }
            
        }
    }

    private void addLetter()
    {

    }

        
}
