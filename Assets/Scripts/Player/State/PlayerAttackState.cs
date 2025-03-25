using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation("IsAttack");
    }
    public override void Exit()
    {
        base.Enter();
        StopAnimation("IsAttack");
    }

    public override void Update()
    {
        base.Update();
        // 몬스터가 죽었다면 Idle 상태로 전환
        if (IsMonsterDead())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }


    private bool IsMonsterDead()
    {
        return stateMachine.Target.IsDie();
    }
}
