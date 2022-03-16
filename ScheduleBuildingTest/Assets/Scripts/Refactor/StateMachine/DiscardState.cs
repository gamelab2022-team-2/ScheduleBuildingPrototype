using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardState : GameState
{
    
    public DiscardState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }
    
    // if condition -> next phase (Game Over)
    // if condition -> next phase (Event Phase)

}
