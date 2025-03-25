using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{
    public MonsterAttackState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // 애니메이션 재생
    }

    public override void Exit()
    {
        base.Exit();
        // 애니메이션 종료
    }

    public override void Update()
    {
        base.Update();

        // TODO : 플레이어가 죽으면 Idle로 전환
        //if(IsPlayerDead())
        //{
        //    stateMachine.ChangeState(stateMachine.IdleState);
        //}
    }
}
