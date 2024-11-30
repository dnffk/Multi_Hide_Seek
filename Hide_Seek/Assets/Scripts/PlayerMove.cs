using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 5f; // 기본 이동 속도
    public float moveSpeed = 5f; // 걷기 속도
    public float runSpeed = 10f; // 뛰기 속도

    void Update()
    {
        // Shift 키를 눌렀을 때 달리기 속도 적용
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = runSpeed;
        }
        else
        {
            Speed = moveSpeed;
        }

        // 입력값 받아오기
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 이동 방향 계산
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * Speed * Time.deltaTime;

        // 이동 적용
        transform.position += movement;
    }
}
