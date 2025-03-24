using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Player.speedModifier = 0f;
        base.Enter();
        // ≈∏∞Ÿ¿ª √£±‚
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateMachine.Target != null) stateMachine.ChangeState(stateMachine.ChasingState);
    }
}
