using System.Collections;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameObject effectPrefab1;      // 충돌 시 출력할 이펙트 프리팹
    public GameObject effectPrefab2;      // 충돌 시 출력할 이펙트 프리팹
    public Transform spawnPoint;         // 플레이어가 다시 시작할 위치
    public float respawnDelay = 5f;      // 다시 시작하기까지의 대기 시간
    public float superJumpForce = 50f;   // 슈퍼 점프 힘

    private Renderer playerRenderer;     // 플레이어의 Renderer
    private Collider playerCollider;     // 플레이어의 Collider
    private Rigidbody playerRigidbody;

    void Start()
    {
        // 플레이어의 컴포넌트 가져오기
        playerRenderer = GetComponent<Renderer>();
        playerCollider = GetComponent<Collider>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 태그가 "Collision"인지 확인
        if (collision.gameObject.CompareTag("Collision"))
        {
            StartCoroutine(HandleRespawn());
        }

        // 충돌한 오브젝트의 태그가 "SuperJump"인지 확인
        if (collision.gameObject.CompareTag("SuperJump"))
        {
            Debug.Log("슈퍼점프 충돌 감지");
            StartCoroutine(SuperJump());
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("SuperJump"))
    //    {
    //        Debug.Log("슈퍼 점프 발판 감지!");
    //        StartCoroutine(SuperJump());
    //    }
    //}

    private IEnumerator HandleRespawn()
    {
        // 이펙트 생성
        if (effectPrefab1 != null)
        {
            Instantiate(effectPrefab1, transform.position, Quaternion.identity);
        }

        // 플레이어 비활성화
        playerRenderer.enabled = false;
        playerCollider.enabled = false;

        // 대기
        yield return new WaitForSeconds(respawnDelay);

        // 플레이어 리스폰
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;

        // 플레이어 활성화
        playerRenderer.enabled = true;
        playerCollider.enabled = true;

        if (effectPrefab2 != null)
        {
            Instantiate(effectPrefab2, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator SuperJump()
    {
        //float jumpHeight = 8f;  // 점프 높이
        //float jumpDuration = 0.6f;  // 점프 지속 시간
        //float elapsedTime = 0f;

        //Vector3 startPosition = transform.position;
        //Vector3 targetPosition = startPosition + Vector3.up * jumpHeight;

        //// 점프 애니메이션 수행
        //while (elapsedTime < jumpDuration)
        //{
        //    transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / jumpDuration);
        //    elapsedTime += Time.deltaTime;
        //    yield return null;
        //}

        //// 안전하게 위치 설정
        //transform.position = targetPosition;
        //Debug.Log("Super Jump Activated without Rigidbody!");

        if (playerRigidbody != null)
        {
            // 수직 방향으로 점프 힘 적용
            playerRigidbody.AddForce(Vector3.up * superJumpForce, ForceMode.Impulse);

            // 간단한 효과 출력 (선택)
            Debug.Log("Super Jump Activated!");
        }
        yield return null;
    }
}