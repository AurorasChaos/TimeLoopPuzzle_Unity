using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool Recording = false;
    Rigidbody rb;
    TotalTransform totalTransform;

    [SerializeField] private float JumpHeight;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private New_Clone_Handler_Script CHS;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!Recording) //If recording is currently Off, when the button is pressed.
            {
                Recording = true;
                Debug.Log("Turned on recording");
                totalTransform = new TotalTransform();
            } 
            else //If recording if currently ON, when the button is pressed
            {
                Recording = false;
                Debug.Log("Turned off recording");
                CHS.AddNewClone(totalTransform);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * MoveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.forward * MoveSpeed * -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * MoveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(transform.right * MoveSpeed * -1);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (rb.velocity.y == 0) { rb.AddForce(transform.up * JumpHeight); }
        }

        if (rb.velocity.magnitude > 10f) { rb.velocity = rb.velocity.normalized * 10f; }

        if (Recording)
        {
            totalTransform.AddNewPosition(transform.position);
            totalTransform.AddNewRotation(transform.rotation);
        }
    }
}
