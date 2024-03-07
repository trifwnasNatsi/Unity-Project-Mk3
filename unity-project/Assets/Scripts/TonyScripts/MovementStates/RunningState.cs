using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : MovementBaseState
{
    public override void EnterState(MovementStateManager movementStateManager)
    {
        movementStateManager.anim.SetBool("Running", true);
    }

    public override void UpdateState(MovementStateManager movementStateManager)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) ExitState(movementStateManager, movementStateManager.Walking);
        else if(movementStateManager.direction.magnitude < 0.1f) ExitState(movementStateManager, movementStateManager.Idle);

        if (movementStateManager.vInput < 0) movementStateManager.moveSpeed = movementStateManager.runningBackSpeed;
        else movementStateManager.moveSpeed = movementStateManager.runningSpeed;
    }
    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Running", false);
        movement.SwitchState(state);
    }
}
