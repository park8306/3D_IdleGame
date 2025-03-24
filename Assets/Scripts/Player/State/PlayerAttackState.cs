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
        // ���Ͱ� �׾��� ������ ���Ͱ� �ִٸ� Chasing ���·� ��ȯ
        // ���Ͱ� �׾��� ������ ���Ͱ� ���ٸ� Idle ���·� ��ȯ
        if(IsMonsterDead())
        {
            if(IsOtherMonster())
            {
                stateMachine.ChangeState(stateMachine.ChasingState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }
    }


    // TODO : ���Ͱ� �׾����� Ȯ��
    private bool IsMonsterDead()
    {
        //return stateMachine.Target.IsDead();
        return false;
    }

    // TODO : ������ ���Ͱ� �ִ��� Ȯ��
    private bool IsOtherMonster()
    {
        return false;
    }
}
