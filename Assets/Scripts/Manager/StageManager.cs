using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public StageSO stageData;
    public StageUI stageUI;

    private void Start()
    {
        stageUI = FindObjectOfType<StageUI>();

        GameManager.Instance.stageManager = this;
        GameManager.Instance.SetStageHandle();
    }

    public void StageClear()
    {
        StageClearUI stageClearUI = GameManager.Instance.stageManager.stageUI.stageClearUI;

        stageClearUI.SetActive(true);
        stageClearUI.SetRewardText(GameManager.Instance.stageManager.stageData.rewardGold);
    }

    public void StageFail()
    {
        StageFailUI stageFailUI = GameManager.Instance.stageManager.stageUI.stageFailUI;

        stageFailUI.SetActive(true);
    }

    public void MainGameStart()
    {
        SceneManager.LoadScene("SelectStageScene");
        GameManager.Instance.stageManager = null;
    }
}
