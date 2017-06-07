using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour {

    private Transform target;
    public float range;

    public string playerTag = "Player";

    public float lockSpeed;
    public float fireRate = 1f;
    private float fireCountdown;

    public LineRenderer lineRenderer;
    
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }

    void UpdateTarget()
    {
        GameObject enemies = GameObject.FindGameObjectWithTag(playerTag);
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
    void Shoot()
    {

    }
}
