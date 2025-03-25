using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChasingState : PlayerBaseState
{
    public PlayerChasingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        // 속도 조정
        stateMachine.Player.speedModifier = stateMachine.Player.chasingSpeedModifier;
        base.Enter();
        StartAnimation("IsChasing");
    }
    public override void Exit()
    {
        base.Enter();
        StopAnimation("IsChasing");
    }

    public override void Update()
    {
        base.Update();
        
        // 몬스터가 공격범위 안에 있다면 Attack
        if(IsInAttackRange())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }
    }

    private bool IsInAttackRange()
    {
        float distanceSqr = (stateMachine.TargetTr.position - stateMachine.Player.transform.position).sqrMagnitude;

        // 공격 범위를 지정해줘야 함
        return distanceSqr <= stateMachine.Player.attackRange * stateMachine.Player.attackRange;
    }
}
