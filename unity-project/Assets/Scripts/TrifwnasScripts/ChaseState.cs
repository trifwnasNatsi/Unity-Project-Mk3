using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChaseState : State
{
    [SerializeField] float doNotTransitionIfUnder = 2;

    public override bool ShouldTransitionIntoState(Observer observer, Transform target)
    {
        if (!base.ShouldTransitionIntoState(observer, target))
            return false;

        // Base is OK, do extra checks!
        if (Vector3.Distance(transform.position, target.position) < doNotTransitionIfUnder)
            return false;

        return true;
    }

    public override void _Update(Actuator actuator, Transform target)
    {
        actuator.LookAt_Frame(target, Time.deltaTime);
        actuator.MoveTowards_Frame(target, Time.deltaTime);
    }
}
