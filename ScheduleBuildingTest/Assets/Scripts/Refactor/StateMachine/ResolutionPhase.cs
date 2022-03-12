using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionState : GameState
{
    public ResolutionState(GameStateMachine gsm) : base(gsm)
    {
    }
    
    // if condition -> next phase (Game Over)
    // if condition -> next phase (Discard State)
}
