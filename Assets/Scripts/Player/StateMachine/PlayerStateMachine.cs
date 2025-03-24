using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }
    public GameObject Target { get; set; }

    // ���µ�
    // Idle
    // Chasing
    // Attack

    public PlayerStateMachine(Player player)
    {
        Player = player;
        Target = FindNearMonster().gameObject;
    }


    // �����̿� �ִ� ���͸� ã�� �Լ�
    public Transform FindNearMonster()
    {
        // �����̿� �ִ� ���͸� ã�Ƽ� ��ȯ, ���� �����ʿ� ���������� �´� �迭�� �޾ƿ� �Ÿ� ���� �� ���� ����� �༮�� ��ȯ

        // ���ٸ� null ��ȯ
        return null;
    }
}
