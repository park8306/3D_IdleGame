using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public StageSO stageData;
    public StageUI stageUI;

    private void Start()
    {
        stageUI = FindObjectOfType<StageUI>();
    }

    public void StageClear()
    {
        StageClearUI stageClearUI = stageUI.stageClearUI;

        stageClearUI.SetActive(true);
        stageClearUI.SetRewardText(stageData.rewardGold);
    }

    public void StageFail()
    {
        StageFailUI stageFailUI = stageUI.stageFailUI;

        stageFailUI.SetActive(true);
    }
}
