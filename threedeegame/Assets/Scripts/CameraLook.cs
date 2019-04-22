using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{ 
    void Update()
    {
        //get mouse input
        float horizontalSpeed = Input.GetAxis("Mouse X");
        float verticalSpeed = Input.GetAxis("Mouse Y");

        //rotate camera using input
        Camera.main.transform.Rotate(0f,horizontalSpeed,0f);
        Camera.main.transform.Rotate(-verticalSpeed,0f,0f);
        
        //lock the Z axis rotation 
        transform.eulerAngles= new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0f);
    }
}
