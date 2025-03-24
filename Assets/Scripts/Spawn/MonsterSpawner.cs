using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    // 플레이어와 가장 가까운 몬스터를 찾아냄
    public GameObject FindTarget(Vector3 playerPos)
    {
        GameObject nearMonster = null;
        int nearIndex = -1;
        float minDistance= float.MaxValue;

        for (int i = 0; i < spawnMonsters.Count; i++)
        {
            // 활성화가 안되어 있는 적은 죽은 적임
            if (!spawnMonsters[i].activeInHierarchy)
                break;

            float distance = (spawnMonsters[i].transform.position - playerPos).sqrMagnitude;
            if(distance < minDistance)
            {
                nearIndex = i;
                minDistance = distance;
            }
        }

        if (nearIndex != -1)
            return spawnMonsters[nearIndex];
        else
            return null;
    }
}
