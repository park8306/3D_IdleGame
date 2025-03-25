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
        // �ִϸ��̼� ���
        StartAnimation("IsAttack");
    }

    public override void Exit()
    {
        base.Exit();
        // �ִϸ��̼� ����
        StopAnimation("IsAttack");
    }

    public override void Update()
    {
        base.Update();

        if(stateMachine.Target.isDie)
        {
            stateMachine.Target = null;
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
