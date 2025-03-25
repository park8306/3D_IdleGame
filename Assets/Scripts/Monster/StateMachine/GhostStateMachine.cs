using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStateMachine : MonsterStateMachine
{
    public GhostStateMachine(Monster monster) : base(monster)
    {
        AttackState = new GhostAttackState(this);
    }
}
