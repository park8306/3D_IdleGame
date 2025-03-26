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

    private float lastDamageTime; // 마지막으로 피해를 입은 시간
    private float damageRate = 2f;     // 데미지 입을 간격

    private void Start()
    {
        playerInfoUI = FindObjectOfType<PlayerInfoUI>();
        HP = MaxHealth;
        isDie = false;
    }

    // 딜레이를 가지고 데미지를 입을 때
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
