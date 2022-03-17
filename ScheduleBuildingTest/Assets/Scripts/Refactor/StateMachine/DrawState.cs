using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawState : GameState
{
    public DrawState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }
    
    // if condition -> next phase (Place State)
    public override void Tick()
    {
        
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Draw();
        // player hand should now have 5 cards -> next phase
        _stateMachine.ChangeState(_stateMachine.placePhase);
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public void Draw()
    {
        _player.DrawFromDeck();
    }
    

}
