using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    public Image hp;
    public TextMeshProUGUI hpText;

    public TextMeshProUGUI lv;
    public Image exp;

    public TextMeshProUGUI goldText;

    public Health playerHealth;

    private void Start()
    {
        playerHealth = FindObjectOfType<Health>();

        if (PlayerPrefs.HasKey("Gold"))
            SetGoldText();
        else
        {
            PlayerPrefs.SetInt("Gold", 0);
            goldText.text = "0";
        }

        ResetHP();
    }

    public void SetGoldText()
    {
        goldText.text = PlayerPrefs.GetInt("Gold").ToString();
    }

    public void ResetHP()
    {
        if (playerHealth == null) return;

        hp.fillAmount = 1;
        hpText.text = $"{playerHealth.MaxHealth} / {playerHealth.MaxHealth}";
    }

    public void UpdateHP()
    {
        if (playerHealth == null) return;

        hp.fillAmount = (float)playerHealth.HP / playerHealth.MaxHealth;
        hpText.text = $"{playerHealth.HP} / {playerHealth.MaxHealth}";
    }
}
