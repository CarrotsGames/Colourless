using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject RespawnPoint;


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("AAA");
        collision.transform.position = RespawnPoint.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.gameObject.GetComponent<Movement>().controller.enabled = false;
            Debug.Log("Teleport");
            other.transform.position = RespawnPoint.transform.position;
            other.gameObject.GetComponent<Movement>().controller.enabled = true;
        }

    }
}
