using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private StateMachineHandler stateMachine;
    // Start is called before the first frame update

    [SerializeField] private bool runStateMachine = true;
    //[SerializeField] float health, maxHealth = 3f;
    private bool isEnemyActive;

    public bool isActive()
    {
        return isEnemyActive;
    }

    public void Update()
    {
        if (runStateMachine)
            stateMachine._Update();
    }

}