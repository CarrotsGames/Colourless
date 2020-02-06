using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public string website;
    private void OnTriggerEnter(Collider other)
    {
        Application.Quit();
        Application.OpenURL(website);

    }
}
