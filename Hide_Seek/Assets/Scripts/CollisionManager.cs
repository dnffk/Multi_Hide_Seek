using System.Collections;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameObject effectPrefab;      // 충돌 시 출력할 이펙트 프리팹
    public Transform spawnPoint;         // 플레이어가 다시 시작할 위치
    public float respawnDelay = 5f;      // 다시 시작하기까지의 대기 시간

    private Renderer playerRenderer;     // 플레이어의 Renderer
    private Collider playerCollider;     // 플레이어의 Collider

    void Start()
    {
        // 플레이어의 Renderer와 Collider 가져오기
        playerRenderer = GetComponent<Renderer>();
        playerCollider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 태그가 "Collision"인지 확인
        if (collision.gameObject.CompareTag("Collision"))
        {
            StartCoroutine(HandleRespawn());
        }
    }

    private IEnumerator HandleRespawn()
    {
        // 이펙트 생성
        if (effectPrefab != null)
        {
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
        }

        // 플레이어를 일시적으로 비활성화
        playerRenderer.enabled = false;

        // 대기
        yield return new WaitForSeconds(respawnDelay);

        // 플레이어를 리스폰 위치로 이동
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;

        // 플레이어 다시 활성화
        playerRenderer.enabled = true;
        playerCollider.enabled = true;
    }
}
