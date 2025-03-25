using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

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
