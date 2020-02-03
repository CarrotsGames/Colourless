using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private const float yAngleMin = 0;
    private const float xAngleMax = 50;


    public Transform lookAt;
    public Transform camTransform;
    private Camera cam;
    public float distance = 10;
    private float currentX;
    private float currentY;
    private float sensitivityX = 4;
    private float sensitivityY = 1;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, yAngleMin, xAngleMax);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
