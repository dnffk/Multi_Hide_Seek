using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform cameraTransform;               // 카메라 Transform
    public CharacterController characterController; // 캐릭터 컨트롤러

    public float moveSpeed = 10f;                   // 이동 속도
    public float jumpSpeed = 5f;                   // 점프 속도
    public float gravity = -20f;                    // 중력
    public float sensitivity = 500f;               // 마우스 민감도

    private float yVelocity = 0;                    // Y축 속도
    private float rotationY = 0f;                  // Y축 회전 (좌우)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 잠금
    }

    void Update()
    {
        HandleMovement(); // 이동 처리
        HandleMouseLook(); // 마우스 회전 처리
    }

    void HandleMovement()
    {
        // 이동 입력 받기
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 방향 벡터 계산 (카메라의 Forward와 Right 기준)
        Vector3 moveDirection = cameraTransform.forward * v + cameraTransform.right * h;
        moveDirection.y = 0; // Y축 제거 (수평 이동만)
        moveDirection *= moveSpeed;

        // 점프 및 중력 처리
        //if (characterController.isGrounded)
        //{
        //    yVelocity = 0; // 바닥에 있을 때 Y축 속도 초기화
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        yVelocity = jumpSpeed;
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            yVelocity = jumpSpeed;
        }

        yVelocity += gravity * Time.deltaTime; // 중력 적용
        moveDirection.y = yVelocity; // Y축 속도 적용

        // 최종 이동 적용
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        // 마우스 입력 받기 (좌우 회전만 처리)
        float mouseMoveX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        // Y축 회전: 플레이어 좌우 회전
        rotationY += mouseMoveX;

        // 플레이어의 Y축 회전 적용
        transform.eulerAngles = new Vector3(0, rotationY, 0);
    }
}
