using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class mouseCameraControls : MonoBehaviour
{
    public Vector2 rotationSpeed;
    float moveSpeed = 100f;
    GameObject manatee;
    float rotateSpeed = 1.75f;
    void Start()
    {
        // To match the mouse movement, the y rotation speed should be inverted
        rotationSpeed = new Vector2(rotationSpeed.x, -1 * rotationSpeed.y);

        //manatee = GameObject.Find("Geo_Manatee");
    }

    void Update()
    {       
        var horizontalRotation = rotationSpeed.x * new Vector3(0, Input.GetAxis("Mouse X"), 0);
        var verticalRotation = rotationSpeed.y * new Vector3(Input.GetAxis("Mouse Y"), 0, 0);
        this.transform.position += this.transform.forward * Time.fixedDeltaTime * moveSpeed;
        //manatee.gameObject.transform.position += this.transform.forward * Time.fixedDeltaTime* moveSpeed;

        transform.Rotate(horizontalRotation*rotateSpeed, Space.World); // Rotate around world y-axisz
        transform.Rotate(verticalRotation*rotateSpeed, Space.Self); // Rotate around camera's x-axis
        //manatee.gameObject.transform.Rotate(horizontalRotation*rotateSpeed, Space.World);
        //manatee.gameObject.transform.Rotate(verticalRotation*rotateSpeed, Space.Self);
        if(this.transform.position.y > 7)
        {
            //manatee.transform.position = new Vector3(manatee.transform.position.x, 7, manatee.transform.position.z);
            this.transform.position = new Vector3(this.transform.position.x, 7, this.transform.position.z);
        }
    }
}