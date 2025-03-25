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
        // �ӵ� ����
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
        
        // ���Ͱ� ���ݹ��� �ȿ� �ִٸ� Attack
        if(IsInAttackRange())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }
    }

    private bool IsInAttackRange()
    {
        float distanceSqr = (stateMachine.TargetTr.position - stateMachine.Player.transform.position).sqrMagnitude;

        // ���� ������ ��������� ��
        return distanceSqr <= stateMachine.Player.attackRange * stateMachine.Player.attackRange;
    }
}
