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
    float currentX;
    Vector3 rotate;
    private Vector3 moveDir = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentX += Input.GetAxis("Mouse X");

        RotatePlayer();
        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDir = Camera.main.transform.TransformDirection(moveDir);
            moveDir.y = 0;
            moveDir.Normalize();
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

    void RotatePlayer()
    {

        //Rotation
        rotate.x = transform.position.x - Camera.main.transform.position.x;
        rotate.z = transform.position.z - Camera.main.transform.position.z;
        Vector3 Forward = new Vector3(rotate.x, 0.0f, rotate.z);
        Vector3 NewDirection = Vector3.RotateTowards(transform.forward, Forward, 7 * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(NewDirection);
    }
}
