using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "RedPaint":
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    gameObject.tag = "Red";
                }
                break;
            case "BluePaint":
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.blue;
                    gameObject.tag = "Blue";
                }
                break;
            case "GreenPaint":
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    gameObject.tag = "Green";
                }
                break;
            case "YellowPaint":
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    gameObject.tag = "Yellow";
                }
                break;
            case "WhitePaint":
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.white;
                    gameObject.tag = "White";
                }
                break;
        }
    }
}
