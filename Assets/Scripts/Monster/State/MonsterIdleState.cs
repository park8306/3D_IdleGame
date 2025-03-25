using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIdleState : MonsterBaseState
{
    public MonsterIdleState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(IsInAttackRange())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }
    }

    private bool IsInAttackRange()
    {
        if (stateMachine.Target == null) return false;
        float distanceSqr = (stateMachine.Target.transform.position - stateMachine.Monster.transform.position).sqrMagnitude;

        // 공격 범위를 지정해줘야 함
        return distanceSqr <= stateMachine.Monster.attackRange * stateMachine.Monster.attackRange;
    }
}
