using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on a thing that looks at stuff (ideally a camera)
// INTENT: this will make the thing look at a thing, forever.
public class CameraLookFollow : MonoBehaviour
{
    public Transform lookTarget;//what should I look at ; assign in Inspector
    // Update is called once per frame
    void Update()
    {
        //technique 1: use "LookAt"... very simple, very basic
        //transform.LookAt(lookTarget);
        
        //technique 2: use quarternions to make the thing look at the other thing
        Vector3 forward = lookTarget.position - transform.position; //line from A to B = B-A
        //calculate quarternion based on the forward vector
        Quaternion targetRotation = Quaternion.LookRotation(forward);
        //change rotation based on quarternions
        
        //MECHANICAL FEEL, LIKE A SECURITY CAMERA
        //rotate towards the object at a rate of 5 degrees per second
        //transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,30f*Time.deltaTime);
        
        //MORE ORGANIC FEEL, eases in and out/ dampens / accelerates
        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,5f*Time.deltaTime);
    }
}
