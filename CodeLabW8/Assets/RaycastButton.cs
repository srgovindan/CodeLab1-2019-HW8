using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on an object (with a collider) to make it clickable
// INTENT: shoot raycast based on mouse cursor to detect any colliders
public class RaycastButton : MonoBehaviour
{
  
    void Update()
    {
        // Step 1: generate a "Ray" variable 
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Step 2: visualize the raycast
        Debug.DrawRay(myRay.origin,myRay.direction*1000f, Color.yellow);
        // Step 3: intialize a raycast hit variable 
        // "RaycastHit" is a type of variable that has more info about what it hit
        RaycastHit myRayHitInfo = new RaycastHit();

        if (Input.GetMouseButtonDown(0))
        {
            // Step 4: actually shoot raycast now!
            if (Physics.Raycast(myRay, out myRayHitInfo, 1000f))
            {
                // Step 5: do something with the raycast 
                Destroy(myRayHitInfo.collider.gameObject);
                Debug.Log("HIT");
            }
        }
    }
    
    
    // secret faster way to make a raycast button
    private void OnMouseDown()
    {
        Debug.Log("You clicked on me!");
    }
}
