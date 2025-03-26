using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }

            return instance;
        }
    }

    public event Action onStageClear;
    public event Action onStageFail;

    public StageManager stageManager;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this)
                Destroy(gameObject);
        }
    }

    public void Stage1Btn()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Stage2Btn()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Stage3Btn()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void SetStageHandle()
    {
        if (stageManager == null) return;
        onStageClear += stageManager.StageClear;
        onStageFail += stageManager.StageFail;
    }
    public void StageClear()
    {
        AddReward();
        onStageClear?.Invoke();
    }
    public void StageFail()
    {
        onStageFail?.Invoke();
    }

    public void AddReward()
    {
        if(stageManager != null)
        {
            int gold = PlayerPrefs.GetInt("Gold");
            gold += stageManager.stageData.rewardGold;
            PlayerPrefs.SetInt("Gold", gold);
            PlayerInfoUI playerinfoUI = FindObjectOfType<PlayerInfoUI>();
            if(playerinfoUI != null)
            {
                playerinfoUI.SetGoldText();
            }
        }
    }
}
