using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // ��������1�� ������ ���͵�
    public MonsterSO[] stage1SpawnMonsters;

    // �������� 1 ���� ����Ʈ
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

    // �÷��̾�� ���� ����� ���͸� ã�Ƴ�
    public GameObject FindTarget(Vector3 playerPos)
    {
        GameObject nearMonster = null;
        int nearIndex = -1;
        float minDistance= float.MaxValue;

        for (int i = 0; i < spawnMonsters.Count; i++)
        {
            // Ȱ��ȭ�� �ȵǾ� �ִ� ���� ���� ����
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
