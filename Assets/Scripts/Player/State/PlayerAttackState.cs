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
        // ���Ͱ� �׾��ٸ� Idle ���·� ��ȯ
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
