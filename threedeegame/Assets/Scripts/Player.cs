using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        if (Input.GetMouseButtonDown(0))
        {
            Interact();
        }
    }

    void Move()
    {
        //get inputs
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        //calculate movement
        Vector3 movement = (transform.forward * vAxis + transform.right * hAxis) * moveSpeed * Time.deltaTime;
        //update position
        rb.MovePosition(transform.position + movement);
    }

    void Interact()
    {
        //generate a ray
        Ray myRay = new Ray(transform.position, transform.forward);
        //debug draw the ray
        Debug.DrawRay(myRay.origin, myRay.direction * 3f, Color.yellow);
        //init a raycasthit var
        RaycastHit myRayCastHit = new RaycastHit();
        //raycast!
        if (Physics.Raycast(myRay, out myRayCastHit, 3f))
        {
            //get tag of raycast hit obj
            string objTag = myRayCastHit.collider.gameObject.tag;
            
            //do stuff with the raycast - calls the appropriate function from the laundry manager
            if (objTag == "Laundry")
            {
                Debug.Log("Got laundry.");
                LaundryManager.LM.GotLaundry(myRayCastHit.collider.gameObject);
            } 
            else if (objTag == "Washer")
            {
                Debug.Log("Got washer.");
                LaundryManager.LM.GotWasher();
            }
            else if (objTag == "Dryer")
            {
                Debug.Log("Got dryer.");
                LaundryManager.LM.GotDryer();
            }
            else if (objTag=="Coffee")
            {
                Debug.Log("Got coffee?");
                LaundryManager.LM.UpdateDialogueUI(3);
            }
            else if (objTag=="Sushi")
            {
                Debug.Log("Got sushi!");
                LaundryManager.LM.UpdateDialogueUI(1);
            }
            else if (objTag=="Inari")
            {
                Debug.Log("Got Inari?!");
                LaundryManager.LM.UpdateDialogueUI(2);
            }
        }
    }
}
