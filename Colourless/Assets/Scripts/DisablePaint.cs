﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePaint : MonoBehaviour
{
    public bool beginCooldown;
    public float coolDownTimer;
    private float coolDownStore;
    private void Start()
    {
        beginCooldown = false;
        coolDownStore = coolDownTimer;
    }
    // Update is called once per frame
    void Update()
    {
        if(beginCooldown)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
            coolDownTimer -= Time.deltaTime;
            if(coolDownTimer < 0)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
                gameObject.GetComponent<SkinnedMeshRenderer>().enabled = true;
                beginCooldown = false;
                coolDownTimer = coolDownStore;
            }
        }
    }
    
}
