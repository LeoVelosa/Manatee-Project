using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManateeMovement : MonoBehaviour
{
    float speed = 6f;
    float lookSpeed = 6f;
    public Transform cam;
    void Start()
    {
        //cam = GetComponent<Transform>();
    }
    void Update()
    {

        //this.transform.position = ((right + forward) * speed);
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //movement = cam.TransformDirection(movement);
        //movement = Vector3.ProjectOnPlane(movement, Vector3.up);

        Vector3 camDirection = cam.forward;
        camDirection = Vector3.ProjectOnPlane(camDirection, Vector3.up);

        this.transform.forward += camDirection;
    }
}
