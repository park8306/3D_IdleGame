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
    }

    public override void Exit()
    {
        base.Exit();
        // �ִϸ��̼� ����
    }

    public override void Update()
    {
        base.Update();

        // TODO : �÷��̾ ������ Idle�� ��ȯ
        //if(IsPlayerDead())
        //{
        //    stateMachine.ChangeState(stateMachine.IdleState);
        //}
    }
}
