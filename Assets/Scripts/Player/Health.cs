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

    private float lastDamageTime; // ���������� ���ظ� ���� �ð�
    private float damageRate = 2f;     // ������ ���� ����

    private void Start()
    {
        health = maxHealth;
        isDie = false;
    }

    // �����̸� ������ �������� ���� ��
    public void TakeDelayDamage(int damage)
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
    public void TakeDamage(int damage)
    {
        if (health == 0) return;

        health = Mathf.Max(health - damage, 0);

        if (health == 0)
        {
            isDie = true;
            OnDie?.Invoke();
        }

        Debug.Log(health);
    }
}
