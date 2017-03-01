using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScie : MonoBehaviour {
    public float speed = 100f;
    
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * speed, 0, Space.World);
    }
}
