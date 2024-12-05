using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        // 이동 속도
    public float rotationSpeed = 720f; // 회전 속도
    public Camera mainCamera;          // 메인 카메라

    private Rigidbody rb;              // Rigidbody 컴포넌트
    private Vector3 moveDirection;     // 이동 방향

    void Start()
    {
        // Rigidbody 초기화
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 이동 처리
        MoveCharacter();

        // 캐릭터 회전 처리
        RotateCharacter();
    }

    void MoveCharacter()
    {
        // 방향키 입력 처리 (WASD)
        float horizontal = Input.GetAxis("Horizontal"); // A/D 또는 ←/→
        float vertical = Input.GetAxis("Vertical");     // W/S 또는 ↑/↓

        // 로컬 이동 방향 계산 (캐릭터의 Forward와 Right를 기준)
        moveDirection = transform.forward * vertical + transform.right * horizontal;
        moveDirection.Normalize(); // 방향 벡터를 정규화

        // Rigidbody를 이용한 이동 처리
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    void RotateCharacter()
    {
        // 마우스 위치를 기준으로 회전 처리
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // 마우스가 가리키는 위치를 지면과의 충돌로 계산
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // 마우스가 가리키는 방향으로 캐릭터 회전
            Vector3 lookDirection = hit.point - transform.position;
            lookDirection.y = 0f; // y축 고정

            if (lookDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}