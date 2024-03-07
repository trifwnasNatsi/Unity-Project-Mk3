using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : MovementBaseState
{
    public override void EnterState(MovementStateManager movementStateManager)
    {
        movementStateManager.anim.SetBool("Walking", true);
    }

    public override void UpdateState(MovementStateManager movementStateManager)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movementStateManager, movementStateManager.Running);
        else if (movementStateManager.direction.magnitude < 0.1f) ExitState(movementStateManager, movementStateManager.Idle);

        if (movementStateManager.vInput < 0) movementStateManager.moveSpeed = movementStateManager.walkingBackSpeed;
        else movementStateManager.moveSpeed = movementStateManager.walkingSpeed;
    }

    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Walking", false);
        movement.SwitchState(state);
    }
}
