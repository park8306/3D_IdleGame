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
        // 타겟을 찾기
        stateMachine.TargetTr = monsterSpawner.FindTarget(stateMachine.Player.transform.position);
        if(stateMachine.TargetTr)
            stateMachine.Target = stateMachine.TargetTr.GetComponent<IDamagable>();
        else
        {
            GameManager.Instance.StageClear();
            stateMachine.Target = null;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        // 타겟이 null이 아니라면 타겟을 추적
        if (stateMachine.TargetTr != null) stateMachine.ChangeState(stateMachine.ChasingState);
    }
}
