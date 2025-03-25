using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MonsterBaseState : IState
{
    protected MonsterStateMachine stateMachine;

    public MonsterBaseState(MonsterStateMachine stateMachine)
    {
        this.stateMachine = stateMachine; 
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void Update()
    {
    }
    protected void StartAnimation(string animationParam)
    {
        // 애니메이션 재생
        stateMachine.Monster.Animator.SetBool(animationParam, true);
    }
    protected void StopAnimation(string animationParam)
    {
        // 애니메이션 중단
        stateMachine.Monster.Animator.SetBool(animationParam, false);
    }
}
