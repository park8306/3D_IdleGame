using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Create/Monster")]
public class MonsterSO : ScriptableObject
{
    public string name;
    public float atk;
    public float hp;
    public GameObject spawnObj;
}
