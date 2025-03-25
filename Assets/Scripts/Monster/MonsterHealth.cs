using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public void TakeDamage(int damage);
    public bool IsDie();
}

public class MonsterHealth : MonoBehaviour, IDamagable
{
    public Monster Monster { get; private set; }

    public float maxHealth;
    public float health;

    public bool isDie;
    public event Action OnDie;

    private void Start()
    {
        Monster = GetComponent<Monster>();
        maxHealth = Monster.monsterData.hp;
        health = maxHealth;
        isDie = false;
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;

        health = Mathf.Max(health - damage, 0);

        if(health == 0)
        {
            isDie = true;
            OnDie?.Invoke();
            gameObject.SetActive(false);
        }
    }

    public bool IsDie()
    {
        return isDie;
    }
}
