using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Transactions;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;

    public MonsterSpawner monsterSpawner;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        monsterSpawner = GameObject.FindObjectOfType<MonsterSpawner>();
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
        if(stateMachine.Player.Health)

        Move();
    }

    private void Move()
    {
        // 가장 가까운 몬스터
        Transform monster = stateMachine.Target != null ? stateMachine.TargetTr : null;

        // 추적할 몬스터가 있으면
        if(monster != null)
        {
            // 가까운 몬스터의 방향을 알아냄
            Vector3 moveDirection = GetMovementDirection();
            // 몬스터로 이동
            Move(moveDirection);

            // 몬스터 방향으로 플레이어 회전
            Rotate(moveDirection);
        }
    }

    private void Move(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        stateMachine.Player.Controller.Move((direction * movementSpeed) * Time.deltaTime);
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 dir = (stateMachine.TargetTr.position - stateMachine.Player.transform.position);

        return dir;
    }

    private float GetMovementSpeed()
    {
        // 플레이어에서 스피드 가져오기
        return stateMachine.Player.speed * stateMachine.Player.speedModifier;
    }

    private void Rotate(Vector3 direction)
    {
        if(direction != Vector3.zero)
        {
            Transform playerTransform = stateMachine.Player.transform;
            // 몬스터를 향해 바라볼 회전 값
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            // Slerp를 통해 스무스하게 바라볼 수 이도록 함
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, Time.deltaTime);
        }
    }

    protected void StartAnimation(string animationParam)
    {
        // 애니메이션 재생
        stateMachine.Player.Animator.SetBool(animationParam, true);
    }
    protected void StopAnimation(string animationParam)
    {
        // 애니메이션 중단
        stateMachine.Player.Animator.SetBool(animationParam, false);
    }
    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        // 전환되고 있을 때 && 다음 애니메이션이 tag라면
        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        // 전환되고 있지 않을 때 && 현재 애니메이션이 tag라면
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0;
        }
    }
}
