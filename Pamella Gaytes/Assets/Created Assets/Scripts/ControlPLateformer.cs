using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlateformer : MonoBehaviour {

    public float speed = 0.20f;
    public float jump = 4.01f;

	// Use this for initialization
	void Start () {
        print("Start");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dp = new Vector3();
        if (Input.GetKey(KeyCode.Q))
        {
            dp.x -= speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dp.x += speed;
        }

        transform.position += dp;
	}
}
