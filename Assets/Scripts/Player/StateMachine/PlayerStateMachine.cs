using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }
    public GameObject Target { get; set; }

    // ���µ�
    // Idle
    public PlayerIdleState IdleState { get; }
    // Chasing
    public PlayerChasingState ChasingState { get; }
    // Attack
    public PlayerAttackState AttackState { get; }

    public PlayerStateMachine(Player player)
    {
        Player = player;
        Target = FindNearMonster().gameObject;

        IdleState = new PlayerIdleState(this);
        ChasingState = new PlayerChasingState(this);
        AttackState = new PlayerAttackState(this);
    }


    // �����̿� �ִ� ���͸� ã�� �Լ�
    public Transform FindNearMonster()
    {
        // �����̿� �ִ� ���͸� ã�Ƽ� ��ȯ, ���� �����ʿ� ���������� �´� �迭�� �޾ƿ� �Ÿ� ���� �� ���� ����� �༮�� ��ȯ

        // ���ٸ� null ��ȯ
        return null;
    }
}
