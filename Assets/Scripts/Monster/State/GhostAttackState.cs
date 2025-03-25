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

        // TODO : �÷��̾ ������ Idle��
        // �÷��̾ ���� �ʾҴٸ� ����
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
