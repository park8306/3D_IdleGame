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
        base.Enter();
        // �ִϸ��̼� ���
    }

    public override void Exit()
    {
        base.Exit();
        // �ִϸ��̼� ����
    }
}
