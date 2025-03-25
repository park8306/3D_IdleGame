using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public string stageSceneName;
    public TextMeshProUGUI stageTitle;

    public void SelectStage1()
    {
        stageSceneName = "Stage1";
        stageTitle.text = stageSceneName;
    }
    public void SelectStage2()
    {
        stageSceneName = "Stage2";
        stageTitle.text = stageSceneName;
    }
    public void SelectStage3()
    {
        stageSceneName = "Stage3";
        stageTitle.text = stageSceneName;
    }

    public void GamePlayeBtn()
    {
        SceneManager.LoadScene(stageSceneName);
    }
}
