using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoid : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float acceleration = 3;

    Rigidbody rB;

    private void Awake()
    {
        rB = GetComponent<Rigidbody>();
        if (!rB)
            Debug.LogError("Assign a rigidbody!", gameObject);
    }

    private void FixedUpdate()
    {
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        Vector3 avoidDirection_Right = Vector3.Cross(directionToTarget, Vector3.up);
        Vector3 avoidDirection = Vector3.Lerp(directionToTarget, avoidDirection_Right, 0.5f);

        rB.AddForce(avoidDirection * acceleration * Time.fixedDeltaTime, ForceMode.Acceleration);
    }

}
