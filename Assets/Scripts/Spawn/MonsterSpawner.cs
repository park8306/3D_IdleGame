using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // 스테이지1에 스폰될 몬스터들
    public MonsterSO[] stage1SpawnMonsters;

    // 스테이지 1 스폰 포인트
    public Transform[] stage1SpawnPoints;

    public List<GameObject> spawnMonsters = new List<GameObject>();
    public Transform stage1MonsterParent;

    private void Start()
    {
        for (int i = 0; i < stage1SpawnPoints.Length; i++)
        {
            GameObject monster = Instantiate(stage1SpawnMonsters[i].spawnObj, stage1SpawnPoints[i].position, Quaternion.Euler(new Vector3(0, 180, 0)), stage1MonsterParent);
            monster.transform.localScale = Vector3.one * 1.5f;
            spawnMonsters.Add(monster);
        }
    }
}
