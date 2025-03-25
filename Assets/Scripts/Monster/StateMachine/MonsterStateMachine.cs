using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateMachine : StateMachine
{
    public Monster Monster { get; }
    public Health Target { get; set; }

    public MonsterIdleState IdleState { get; set; }
    public MonsterBaseState AttackState { get; set; }

    public MonsterStateMachine(Monster monster)
    {
        Monster = monster;

        IdleState = new MonsterIdleState(this);
        AttackState = new MonsterAttackState(this);

        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }
}
