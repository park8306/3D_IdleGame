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
        // ���� ����� ����
        Transform monster = stateMachine.Target != null ? stateMachine.TargetTr : null;

        // ������ ���Ͱ� ������
        if(monster != null)
        {
            // ����� ������ ������ �˾Ƴ�
            Vector3 moveDirection = GetMovementDirection();
            // ���ͷ� �̵�
            Move(moveDirection);

            // ���� �������� �÷��̾� ȸ��
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
        // �÷��̾�� ���ǵ� ��������
        return stateMachine.Player.speed * stateMachine.Player.speedModifier;
    }

    private void Rotate(Vector3 direction)
    {
        if(direction != Vector3.zero)
        {
            Transform playerTransform = stateMachine.Player.transform;
            // ���͸� ���� �ٶ� ȸ�� ��
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            // Slerp�� ���� �������ϰ� �ٶ� �� �̵��� ��
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, Time.deltaTime);
        }
    }

    protected void StartAnimation(string animationParam)
    {
        // �ִϸ��̼� ���
        stateMachine.Player.Animator.SetBool(animationParam, true);
    }
    protected void StopAnimation(string animationParam)
    {
        // �ִϸ��̼� �ߴ�
        stateMachine.Player.Animator.SetBool(animationParam, false);
    }
    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        // ��ȯ�ǰ� ���� �� && ���� �ִϸ��̼��� tag���
        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        // ��ȯ�ǰ� ���� ���� �� && ���� �ִϸ��̼��� tag���
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
