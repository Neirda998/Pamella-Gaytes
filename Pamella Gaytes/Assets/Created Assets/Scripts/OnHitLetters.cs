using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitLetters : MonoBehaviour
{

    public char actual_letter;
    public GameObject model;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            if (model.gameObject.activeInHierarchy == false)
            {
                model.gameObject.SetActive(true);
            }
        }
    }
}

