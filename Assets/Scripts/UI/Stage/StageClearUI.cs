using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageClearUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rewardText;
    [SerializeField] private Button okBtn;

    private void Start()
    {
        okBtn.onClick.AddListener(OkBtn);
    }

    private void OkBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SetRewardText(int reward)
    {
        rewardText.text = reward.ToString();
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
