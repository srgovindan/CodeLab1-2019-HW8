using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// USAGE: put on your main camera
// INTENT: demo some camera control techniques,
// like simple mouse look / following a target
public class CameraDemo : MonoBehaviour
{
    void Update()
    {
        // simple mouse look
        
        // 1. get mouse input 
        float horizontalMouseSpeed = Input.GetAxis("Mouse X");
        float verticalMouseSpeed = Input.GetAxis("Mouse Y");
        Debug.Log(horizontalMouseSpeed);

        // 2. use mouse input to rotate camera
        // PITCH - x, YAW - y, ROLL - z 
        transform.Rotate(0f, horizontalMouseSpeed,0f);
        Camera.main.transform.Rotate(-verticalMouseSpeed,0f,0f);
        // 3. unroll the camera, we need to set its z to 0f, always
        //transform.eulerAngles.z = 0f //Unity won't let you do it like this! Because of a C# limitation
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0f);
        
        // 4. profit
    }
}
