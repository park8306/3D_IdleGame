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

    private void Start()
    {
        if (PlayerPrefs.HasKey("Gold"))
            SetGoldText();
        else
        {
            PlayerPrefs.SetInt("Gold", 0);
            goldText.text = "0";
        }
    }

    public void SetGoldText()
    {
        goldText.text = PlayerPrefs.GetInt("Gold").ToString();
    }
}
