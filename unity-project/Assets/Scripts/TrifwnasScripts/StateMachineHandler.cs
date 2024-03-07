using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachineHandler : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Observer observer;
    [SerializeField] private Actuator actuator;

    private State[] states;
    
    private void Awake()
    {
        states = GetComponentsInChildren<State>();

        foreach (var state in states)
        {
            state.target = target;
        }
    }

    // Update is called once per frame
    public void _Update()
    {
        
        foreach (State state in states.OrderBy(x => x.priority))
            if (state.ShouldTransitionIntoState(observer, target))
            {
                state._Update(actuator, target);
                break;
            }
    }
}