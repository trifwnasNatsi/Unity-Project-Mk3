using UnityEngine;

public class AttackState : State
{
    [SerializeField] private float cooldown = 2;
    float lastTimeUsed = float.NegativeInfinity;

    public override bool ShouldTransitionIntoState(Observer observer, Transform target)
    {
        if (!base.ShouldTransitionIntoState(observer, target))
            return false;

        // Base is OK, do extra checks!
        if (!isCooldownReady)
            return false;

        return true;
    }

    bool isCooldownReady => Time.time - lastTimeUsed >= cooldown;

    public override void _Update(Actuator actuator, Transform target)
    {
        // Can i Use it?
        if (!isCooldownReady)
            return;

        // Yes!
        actuator.Attack(target);
        lastTimeUsed = Time.time;
    }
}