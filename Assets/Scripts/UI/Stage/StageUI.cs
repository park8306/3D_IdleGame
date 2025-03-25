using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUI : MonoBehaviour
{
    public StageClearUI stageClearUI;
    public StageFailUI stageFailUI;

    private void Start()
    {
        stageClearUI.SetActive(false);
        stageFailUI.SetActive(false);
    }
}
