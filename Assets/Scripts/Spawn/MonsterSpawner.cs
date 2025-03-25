using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // ���������� ������ ���͵�
    public MonsterSO[] stageSpawnMonsters;

    // �������� ���� ����Ʈ
    public Transform[] stageSpawnPoints;

    public List<GameObject> spawnMonsters = new List<GameObject>();
    public Transform stageMonsterParent;

    private void Start()
    {
        for (int i = 0; i < stageSpawnPoints.Length; i++)
        {
            GameObject monster = Instantiate(stageSpawnMonsters[i].spawnObj, stageSpawnPoints[i].position, Quaternion.Euler(new Vector3(0, 180, 0)), stageMonsterParent);
            monster.transform.localScale = Vector3.one * 1.5f;
            spawnMonsters.Add(monster);
        }
    }

    // �÷��̾�� ���� ����� ���͸� ã�Ƴ�
    public Transform FindTarget(Vector3 playerPos)
    {
        int nearIndex = -1;
        float minDistance= float.MaxValue;

        for (int i = 0; i < spawnMonsters.Count; i++)
        {
            // Ȱ��ȭ�� �ȵǾ� �ִ� ���� ���� ����
            if (!spawnMonsters[i].activeInHierarchy)
                continue;

            float distance = (spawnMonsters[i].transform.position - playerPos).sqrMagnitude;
            if(distance < minDistance)
            {
                nearIndex = i;
                minDistance = distance;
            }
        }

        if (nearIndex != -1)
            return spawnMonsters[nearIndex].transform;
        else
            return null;
    }
}
