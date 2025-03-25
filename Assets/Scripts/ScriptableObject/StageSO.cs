using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage", menuName = "Create/Stage")]
public class StageSO : ScriptableObject
{
    public string stageName;
    public int rewardGold;
    public int rewardExp;
}
