using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    private CharacterController controller;
    public float speed;
    public float jumpVelocity;
    public float gravity;
    private Vector3 moveDir = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDir = Camera.main.transform.TransformDirection(moveDir);
            moveDir *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDir.y = jumpVelocity;
            }
        }
        else
        {
            moveDir.x = Input.GetAxis("Horizontal") * speed;
            moveDir.z = Input.GetAxis("Vertical") * speed;
            moveDir = transform.TransformDirection(moveDir);

        }

        moveDir.y -= gravity * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);
    
    }
}
