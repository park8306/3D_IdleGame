using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Monster
{
    private new void Awake()
    {
        base.Awake();
        stateMachine = new GhostStateMachine(this);
    }
}
