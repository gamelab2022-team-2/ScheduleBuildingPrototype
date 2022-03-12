using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawState : GameState
{
    public DrawState(GameStateMachine gsm) : base(gsm)
    {
    }
    
    // if condition -> next phase (Place State)
    public override void Tick()
    {

        if (CheckIfHandFull())
        {
            _stateMachine.ChangeState(_stateMachine.placePhase);
        }
        
    }
    
    public bool CheckIfHandFull(){}
    
    
}
