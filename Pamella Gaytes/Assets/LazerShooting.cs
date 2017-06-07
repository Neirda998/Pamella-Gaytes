using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerShooting : MonoBehaviour {
    public Transform shootPoint;
    public LineRenderer linerenderer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Laser()
    {
        linerenderer.SetPosition(0, shootPoint.position);
        linerenderer.SetPosition(1, target.position);
    }
}
