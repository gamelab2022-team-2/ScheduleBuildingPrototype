using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameState
{
    public virtual void Tick(){}
    public virtual void OnStateEnter(){}
    public virtual void OnStateExit(){}
}
