using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }
    public GameObject Target { get; set; }

    // ╩Себ╣И
    // Idle
    public PlayerIdleState IdleState { get; }
    // Chasing
    public PlayerChasingState ChasingState { get; }
    // Attack
    public PlayerAttackState AttackState { get; }

    public PlayerStateMachine(Player player)
    {
        Player = player;

        IdleState = new PlayerIdleState(this);
        ChasingState = new PlayerChasingState(this);
        AttackState = new PlayerAttackState(this);
    }
}
