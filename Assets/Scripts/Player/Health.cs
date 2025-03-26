using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Health : MonoBehaviour
{
    PlayerInfoUI playerInfoUI;
    public int MaxHealth { get; private set; } = 100;
    public int HP { get; set; }
    public event Action OnDie;

    public bool isDie = false;

    private float lastDamageTime; // ���������� ���ظ� ���� �ð�
    private float damageRate = 2f;     // ������ ���� ����

    private void Start()
    {
        playerInfoUI = FindObjectOfType<PlayerInfoUI>();
        HP = MaxHealth;
        isDie = false;
    }

    // �����̸� ������ �������� ���� ��
    public void TakeDelayDamage(int damage)
    {
        if (HP == 0) return;

        if (Time.time - lastDamageTime > damageRate)
        {
            lastDamageTime = Time.time;
        }
        else
            return;

        HP = Mathf.Max(HP - damage, 0);
        playerInfoUI.UpdateHP();

        if(HP == 0)
        {
            isDie = true;
            OnDie?.Invoke();
        }
    }
    public void TakeDamage(int damage)
    {
        if (HP == 0) return;

        HP = Mathf.Max(HP - damage, 0);
        playerInfoUI.UpdateHP();

        if (HP == 0)
        {
            isDie = true;
            OnDie?.Invoke();
        }
    }
}
