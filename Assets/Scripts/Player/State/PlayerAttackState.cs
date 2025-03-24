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
        // 몬스터가 죽었고 추적할 몬스터가 있다면 Chasing 상태로 전환
        // 몬스터가 죽었고 추적할 몬스터가 없다면 Idle 상태로 전환
        if(IsMonsterDead())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }


    // TODO : 몬스터가 죽었는지 확인
    private bool IsMonsterDead()
    {
        //return stateMachine.Target.IsDead();
        return false;
    }
}
