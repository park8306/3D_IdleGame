using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int health;
    public event Action OnDie;

    public bool isDie = false;

    private float lastDamageTime; // 마지막으로 피해를 입은 시간
    private float damageRate = 2f;     // 데미지 입을 간격

    private void Start()
    {
        health = maxHealth;
        isDie = false;
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;

        if (Time.time - lastDamageTime > damageRate)
        {
            lastDamageTime = Time.time;
        }
        else
            return;

        health = Mathf.Max(health - damage, 0);

        if(health == 0)
        {
            isDie = true;
            OnDie?.Invoke();
        }

        Debug.Log(health);
    }
}
