using System.Collections;
using UnityEngine;

public class ObjSpawn : MonoBehaviour
{
    public GameObject obstaclePrefab;   // ������ ��ֹ� ������
    public Transform spawnPoint;       // ���� ��ġ
    public float spawnInterval = 12f;  // ���� ����
    public float despawnDelay = 10f;   // ��ֹ��� ���ŵǱ������ �ð�

    public GameObject spawnEffectPrefab;  // ���� ����Ʈ ������
    public GameObject despawnEffectPrefab; // ���� ����Ʈ ������

    private void Start()
    {
        // ���� �������� �����ϴ� �ڷ�ƾ ����
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            // ���� ����Ʈ ���
            if (spawnEffectPrefab != null)
            {
                GameObject spawnEffect = Instantiate(spawnEffectPrefab, spawnPoint.position, Quaternion.identity);
                Destroy(spawnEffect, 2f); // 2�� �� ���� ����Ʈ ����
            }

            // ��ֹ� ����
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);

            // ���� �ð��� ������ ��ֹ� ���� �� ���� ����Ʈ ���
            StartCoroutine(HandleDespawnWithEffect(obstacle));

            // ���� ���� ���
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator HandleDespawnWithEffect(GameObject obstacle)
    {
        // ���� �ð� ���
        yield return new WaitForSeconds(despawnDelay);

        // ���� ����Ʈ ���
        if (despawnEffectPrefab != null)
        {
            GameObject despawnEffect = Instantiate(despawnEffectPrefab, obstacle.transform.position, Quaternion.identity);
            Destroy(despawnEffect, 2f); // 2�� �� ���� ����Ʈ ����
        }

        // ��ֹ� ����
        Destroy(obstacle);
    }
}
