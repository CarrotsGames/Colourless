using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourWall : MonoBehaviour
{
    public string colour;
    public LayerMask mask;
    float dist;
    private void Update()
    {
        Vector3 fwd = transform.forward;
        Debug.DrawRay(transform.position, fwd * 50, Color.green);
        if (Physics.Raycast(transform.position,fwd,10))
        {
            Debug.Log("A");
        }
    }
}
