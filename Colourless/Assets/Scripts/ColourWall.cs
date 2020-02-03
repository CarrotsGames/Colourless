using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourWall : MonoBehaviour
{
    public GameObject Player;
    public string colour;
    public LayerMask mask;
    float dist;
    private void Start()
    {
        Player = GameObject.Find("Player");
    }
    private void Update()
    {
        //RaycastHit hit;
        //Vector3 fwd = transform.forward;
        //Debug.DrawRay(transform.position, fwd * 50, Color.green);
        //if (Physics.Raycast(transform.position,fwd, out hit))
        //{           
        //    if(hit.collider.name == transform.gameObject.tag)
        //    {
        //        hit.collider.isTrigger = true;
        //    }
        if(Player.tag == transform.gameObject.tag)
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }
        else
        {
            GetComponent<BoxCollider>().isTrigger = false;
        }

    }

}

