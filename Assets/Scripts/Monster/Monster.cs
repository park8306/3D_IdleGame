using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Animator Animator { get; private set; }

    protected MonsterStateMachine stateMachine;

    public float attackRate = 2f;
    public float attackRange = 2f;

    public MonsterSO monsterData;

    protected void Awake()
    {
        Animator = GetComponent<Animator>();

        stateMachine = new MonsterStateMachine(this);
    }
    // Start is called before the first frame update
    protected void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    // Update is called once per frame
    protected void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
    }

    protected void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    protected void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void AttackPlayer()
    {
        if (stateMachine.Target != null)
        {
            stateMachine.Target.TakeDamage((int)stateMachine.Monster.monsterData.atk);
        }
    }
}
