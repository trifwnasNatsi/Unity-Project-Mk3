using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void _Update(Actuator actuator, Transform target)
    {
        actuator.LookAt_Frame(target, Time.deltaTime);
    }
}
