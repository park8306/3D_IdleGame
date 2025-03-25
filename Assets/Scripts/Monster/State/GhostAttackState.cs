using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAttackState : MonsterBaseState
{
    public GhostAttackState(MonsterStateMachine stateMachine) : base(stateMachine)
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

        // TODO : 플레이어가 죽으면 Idle로
        // 플레이어가 죽지 않았다면 공격
        if (!stateMachine.Target.isDie)
        {
            stateMachine.Target.TakeDamage((int)stateMachine.Monster.monsterData.atk);
        }
        else
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
