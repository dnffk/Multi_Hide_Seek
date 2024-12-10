using System.Collections;
using UnityEngine;

public class ObjSpawn : MonoBehaviour
{
    public GameObject obstaclePrefab;   // 스폰할 장애물 프리팹
    public Transform spawnPoint;       // 스폰 위치
    public float spawnInterval = 12f;  // 스폰 간격
    public float despawnDelay = 10f;   // 장애물이 제거되기까지의 시간

    public GameObject spawnEffectPrefab;  // 생성 이펙트 프리팹
    public GameObject despawnEffectPrefab; // 제거 이펙트 프리팹

    private void Start()
    {
        // 일정 간격으로 스폰하는 코루틴 시작
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            // 생성 이펙트 출력
            if (spawnEffectPrefab != null)
            {
                GameObject spawnEffect = Instantiate(spawnEffectPrefab, spawnPoint.position, Quaternion.identity);
                Destroy(spawnEffect, 2f); // 2초 뒤 생성 이펙트 제거
            }

            // 장애물 생성
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);

            // 일정 시간이 지나면 장애물 제거 및 제거 이펙트 출력
            StartCoroutine(HandleDespawnWithEffect(obstacle));

            // 스폰 간격 대기
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator HandleDespawnWithEffect(GameObject obstacle)
    {
        // 일정 시간 대기
        yield return new WaitForSeconds(despawnDelay);

        // 제거 이펙트 출력
        if (despawnEffectPrefab != null)
        {
            GameObject despawnEffect = Instantiate(despawnEffectPrefab, obstacle.transform.position, Quaternion.identity);
            Destroy(despawnEffect, 2f); // 2초 뒤 제거 이펙트 삭제
        }

        // 장애물 제거
        Destroy(obstacle);
    }
}
