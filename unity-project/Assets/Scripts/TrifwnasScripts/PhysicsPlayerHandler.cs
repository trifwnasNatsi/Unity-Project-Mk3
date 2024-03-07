using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPlayerHandler : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    Rigidbody myRB;
    [SerializeField] private float gravityMulti = 10;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...

        // Move translation along the object's z-axis
        myRB.AddForce(transform.forward * translation, ForceMode.Acceleration);
        myRB.AddForce(Physics.gravity * (gravityMulti - 1), ForceMode.Acceleration);

        // Rotate around our y-axis
        myRB.AddTorque(Vector3.up * rotation, ForceMode.Acceleration);
    }
}
