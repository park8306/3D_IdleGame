using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController Controller { get; private set; }

    public Animator Animator { get; private set; }
    private PlayerStateMachine stateMachine;

    public Health Health { get; set; }
    PlayerInfoUI playerInfoUI;

    // 임시적으로 필요한 데이터들 나중에 SO로 빼주면 됨
    public float speed = 5f;
    public float speedModifier;
    public float chasingSpeedModifier = 1f;
    public float attackRange = 2f;

    public int atk = 10;

    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        Animator = GetComponent<Animator>();

        speedModifier = chasingSpeedModifier;
        Health = GetComponent<Health>();
        playerInfoUI = FindObjectOfType<PlayerInfoUI>();

        stateMachine = new PlayerStateMachine(this);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
        Health.OnDie += OnDie;
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public void AttackMonster()
    {
        if(stateMachine.Target != null)
        {
            stateMachine.Target.TakeDamage(atk);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void OnDie()
    {
        Animator.SetTrigger("IsDie");
        enabled = false;
    }
}
