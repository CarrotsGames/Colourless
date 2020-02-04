using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "RedPaint":
                {
                    other.GetComponent<DisablePaint>().beginCooldown = true;
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    gameObject.tag = "Red";
                }
                break;
            case "BluePaint":
                {
                    other.GetComponent<DisablePaint>().beginCooldown = true;
                    gameObject.GetComponent<Renderer>().material.color = Color.blue;
                    gameObject.tag = "Blue";
                }
                break;
            case "GreenPaint":
                {
                    other.GetComponent<DisablePaint>().beginCooldown = true;
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    gameObject.tag = "Green";
                }
                break;
            case "YellowPaint":
                {
                    other.GetComponent<DisablePaint>().beginCooldown = true;
                    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    gameObject.tag = "Yellow";
                }
                break;
            case "WhitePaint":
                {
                    other.GetComponent<DisablePaint>().beginCooldown = true;
                    gameObject.GetComponent<Renderer>().material.color = Color.white;
                    gameObject.tag = "White";
                }
                break;
        }
    }
}
