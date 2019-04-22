using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed;
    void Update()
    {
        //get mouse input
        float horizontalSpeed = Input.GetAxis("Mouse X") * rotationSpeed;
        float verticalSpeed = Input.GetAxis("Mouse Y") * rotationSpeed;

        //rotate camera using input
        player.transform.Rotate(0f,horizontalSpeed,0f);
        player.transform.Rotate(-verticalSpeed,0f,0f);
        
        //lock the Z axis rotation 
        player.transform.eulerAngles= new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0f);
    }
}
