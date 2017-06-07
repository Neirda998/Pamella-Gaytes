using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LazerShooting1 : MonoBehaviour
{
    public float range;
    private LineRenderer line;
    public bool playerOnly = true;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.numPositions = 2;
    }

    private void Update()
    {
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, transform.right);
        if(Physics.Raycast(landingRay, out hit, range ))
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, hit.point);
            Collider collider = hit.collider;
            if (collider.gameObject.tag == "Player")
            {

            }
            else
            {
                line.SetPosition(0, transform.position);
                line.SetPosition(1, transform.position + (transform.right * range));
            }
        }
    }

}
