using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }
    public GameObject Target { get; set; }

    // 상태들
    // Idle
    // Chasing
    // Attack

    public PlayerStateMachine(Player player)
    {
        Player = player;
        Target = FindNearMonster().gameObject;
    }


    // 가까이에 있는 몬스터를 찾는 함수
    public Transform FindNearMonster()
    {
        // 가까이에 있는 몬스터를 찾아서 반환, 몬스터 스포너에 스테이지에 맞는 배열을 받아와 거리 측정 후 가장 가까운 녀석을 반환

        // 없다면 null 반환
        return null;
    }
}
