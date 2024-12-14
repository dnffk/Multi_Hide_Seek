using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    public float superJumpForce = 20f; // 슈퍼 점프 힘

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어와 충돌 감지
        if (other.CompareTag("Player"))
        {
            Debug.Log("충돌 감지");
            // 플레이어의 Rigidbody 가져오기
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            Debug.Log("Rigidbody 가져옴");
            if (playerRb != null)
            {
                Debug.Log("슈퍼점프 로직 시작");
                // 기존 속도를 초기화하고 점프 힘 추가
                Vector3 velocity = playerRb.velocity;
                velocity.y = 0; // 기존 Y축 속도 제거
                playerRb.velocity = velocity;
                playerRb.AddForce(Vector3.up * superJumpForce, ForceMode.Impulse);
            }
        }
    }
}