using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : MovementBaseState
{
    public override void EnterState(MovementStateManager movementStateManager)
    {
        
    }

    public override void UpdateState(MovementStateManager movementStateManager)
    {
        if (movementStateManager.direction.magnitude > 0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementStateManager.SwitchState(movementStateManager.Running);
            } else
            {
                movementStateManager.SwitchState(movementStateManager.Walking);
            }
        }
    }

}
