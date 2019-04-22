using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
        if (Input.GetMouseButton(0))
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
        Debug.DrawRay(myRay.origin,myRay.direction*1000f,Color.yellow);
        //init a raycasthit var
        RaycastHit myRayCastHit = new RaycastHit();
        //raycast!
        if (Physics.Raycast(myRay, out myRayCastHit, 1000f))
        {
            //do stuff with the raycast
            
        }

    }
}
