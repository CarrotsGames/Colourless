using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [HideInInspector]
    public CharacterController controller;
    public float speed;
    public float jumpVelocity;
    public float gravity;
    [SerializeField]
    private float slopeForce;
    [SerializeField]
    private float slopeRayLength;
    float currentX;
    Vector3 rotate;
    private Vector3 moveDir = Vector3.zero;
    [SerializeField]
    private bool jumping;
 
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
        PlayerMovement();
         
    }

    void PlayerMovement()
    {
        if (controller.isGrounded)
        {

            moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
            moveDir = Camera.main.transform.TransformDirection(moveDir);
            moveDir.y = 0;
            moveDir.Normalize();
            moveDir *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDir.y = jumpVelocity;
            }
            jumping = true;

        }
        else
        {

            moveDir.x = Input.GetAxisRaw("Horizontal") * speed;
            moveDir.z = Input.GetAxisRaw("Vertical") * speed;


            moveDir = transform.TransformDirection(moveDir);
            jumping = false;

        }
        if (OnSlope())
        {
            controller.Move(Vector3.down * controller.height / 2 * slopeForce * Time.deltaTime);
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
    private bool OnSlope()
    {
        if(jumping)
        {
        return false;
        }
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit,controller.height / 2 * slopeRayLength))
        {
            Debug.Log("Before slope");

            if (hit.normal != Vector3.up)
            {
                Debug.Log("SLOPE");
                return true;
            }
        }
        return false;
    }
}
