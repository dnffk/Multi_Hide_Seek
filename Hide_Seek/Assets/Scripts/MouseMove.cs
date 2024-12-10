using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float sensitivity = 500f;      // 마우스 민감도
    public Transform cameraTransform;     // 카메라 Transform 참조
    private float rotationX = 0f;         // X축 회전 (카메라 위아래)
    private float rotationY = 0f;         // Y축 회전 (플레이어 좌우)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 잠금
    }

    void Update()
    {
        // 마우스 입력 받기
        float mouseMoveX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseMoveY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Y축 회전: 플레이어 전체가 좌우로 회전
        rotationY += mouseMoveX;

        // X축 회전: 카메라 위아래로 회전 (각도 제한)
        rotationX -= mouseMoveY;
        rotationX = Mathf.Clamp(rotationX, -30f, 35f);

        // 플레이어 Y축 회전 적용
        transform.eulerAngles = new Vector3(0, rotationY, 0);

        // 카메라 X축 회전 적용
        cameraTransform.localEulerAngles = new Vector3(rotationX, 0, 0);
    }
}
