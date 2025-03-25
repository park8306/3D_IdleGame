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

    public void MainGameStart()
    {
        SceneManager.LoadScene("SelectStageScene");
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
}
