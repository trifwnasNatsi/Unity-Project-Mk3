using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actuator : MonoBehaviour
{
    //[SerializeField] private float attackUp = 2;
    //[SerializeField] private float attackExplosionForce = 15;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private bool debugMovement = true;
    //[SerializeField] private bool debugLook = true;
    [SerializeField] private int damagePerAttack;


    public void MoveTowards_Frame(Transform destination, float deltaTime)
    {
        
        Vector3 direction = (destination.position - transform.position).normalized;
        direction.y = 0;
        transform.Translate(direction * moveSpeed * deltaTime);

        if (debugMovement)
            Debug.Log("I am moving to ", destination);
    }

    public void LookAt_Frame(Transform destination, float deltaTime)
    {
        Vector3 pointToLookAt = destination.position;
        pointToLookAt.y = transform.position.y;

        transform.LookAt(pointToLookAt, Vector3.up);

        if (debugMovement)
            Debug.Log("I am looking at", destination);
    }

   /* public void Kick(Transform target)
    {
        // Do a basic push back
        Rigidbody rB = target.GetComponent<Rigidbody>();

        if (rB == null)
        {
            Debug.LogError("Assign a RB to target", target);
            return;
        }

        // Past this point we know RB exists
        Vector3 betweenPoint = Vector3.Lerp(transform.position, target.position, 0.5f);
        float distance = Vector3.Distance(transform.position, target.position);
        rB.AddExplosionForce(attackExplosionForce, betweenPoint, distance, attackUp, ForceMode.Impulse);

        Debug.Log("I just attacked!", target);
    }*/
    public void Attack(Transform target)
    {
        TargetHandler handler = target.GetComponent<TargetHandler>();
        handler.gotHit(damagePerAttack);
        //Debug.Log("I just attacked!", target);
        
    }
}
