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
        //get inputs
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        //calculate movement
        Vector3 movement = (transform.forward * vAxis + transform.right * hAxis) * moveSpeed * Time.deltaTime;
        //update position
        rb.MovePosition(transform.position + movement);
    }
}
