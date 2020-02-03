using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class VelocityMovement : MonoBehaviour
{

    public float speed;
    public float jumpVelocity;
    private float moveX;
    private float moveZ;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
       // Vector3 movement = new Vector3(moveX, 0.0f, moveZ).normalized;
        Vector3 movementX = Camera.main.transform.right * moveX;
        Vector3 movementZ = Camera.main.transform.forward * moveZ;
        Vector3 movement = movementX + movementZ;
        rb.velocity = movement * speed;

    }
    
}
