using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    public GameObject effectPrefab1;      // 충돌 시 출력할 이펙트 프리팹
    public GameObject effectPrefab2;      // 충돌 시 출력할 이펙트 프리팹
    public GameObject effectPrefab3;      // 목표 지점에 도달할 경우 이펙트 프리팹

    public Transform spawnPoint;         // 플레이어가 다시 시작할 위치
    public float respawnDelay = 5f;      // 다시 시작하기까지의 대기 시간

    private Renderer playerRenderer;     // 플레이어의 Renderer
    private Collider playerCollider;     // 플레이어의 Collider

    void Start()
    {
        if (spawnPoint == null)
        {
            // 태그로 PlayerSpawnPoint 검색
            GameObject spawnObject = GameObject.FindWithTag("SpawnPoint");
            if (spawnObject != null)
            {
                spawnPoint = spawnObject.transform;
            }
            else
            {
                Debug.LogError("태그 'SpawnPoint'를 가진 오브젝트를 찾을 수 없습니다! 태그가 올바르게 설정되었는지 확인하세요.");
                return;
            }
        }

        // 플레이어의 Renderer 및 Collider 가져오기
        playerRenderer = GetComponent<Renderer>();
        playerCollider = GetComponent<Collider>();

        if (playerRenderer == null)
        {
            Debug.LogError("Renderer를 찾을 수 없습니다! 이 스크립트는 적절한 오브젝트에 연결되어야 합니다.");
        }

        if (playerCollider == null)
        {
            Debug.LogError("Collider를 찾을 수 없습니다! 이 스크립트는 적절한 오브젝트에 연결되어야 합니다.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 태그가 "Collision"인지 확인
        if (collision.gameObject.CompareTag("Collision"))
        {
            StartCoroutine(HandleRespawn());
        }

        // 목표 지점에 도달한 경우
        if (collision.gameObject.CompareTag("Goal"))
        {
            StartCoroutine(GoalManager());
        }
    }

    private IEnumerator HandleRespawn()
    {
        // spawnPoint가 없는 경우 처리 중단
        if (spawnPoint == null)
        {
            Debug.LogError("리스폰할 spawnPoint가 설정되지 않았습니다!");
            yield break;
        }

        // 이펙트 생성
        if (effectPrefab1 != null)
        {
            Instantiate(effectPrefab1, transform.position, Quaternion.identity);
        }

        // 플레이어 비활성화
        if (playerRenderer != null)
            playerRenderer.enabled = false;
        if (playerCollider != null)
            playerCollider.enabled = false;

        // 대기
        yield return new WaitForSeconds(respawnDelay);

        // 플레이어 리스폰
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;

        // 플레이어 활성화
        if (playerRenderer != null)
            playerRenderer.enabled = true;
        if (playerCollider != null)
            playerCollider.enabled = true;

        // 이펙트 생성
        if (effectPrefab2 != null)
        {
            Instantiate(effectPrefab2, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator GoalManager()
    {
        // 목표 도달 시 이펙트 생성
        if (effectPrefab3 != null)
        {
            Instantiate(effectPrefab3, transform.position, Quaternion.identity);
        }

        // 잠시 대기 후 엔딩 씬으로 이동
        yield return new WaitForSeconds(2f); // 이펙트가 보이도록 잠시 대기

        // "EndingScene" 씬으로 전환
        SceneManager.LoadScene("EndingScene");
    }
}
