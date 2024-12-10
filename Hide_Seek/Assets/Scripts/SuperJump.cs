using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    public float superJumpForce = 20f; // 슈퍼 점프 힘
    public Animator springAnimator;   // 스프링 애니메이터

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어와 충돌 감지
        if (other.CompareTag("Player"))
        {
            // 플레이어의 Rigidbody 가져오기
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                // 기존 속도를 초기화하고 점프 힘 추가
                Vector3 velocity = playerRb.velocity;
                velocity.y = 0; // 기존 Y축 속도 제거
                playerRb.velocity = velocity;
                playerRb.AddForce(Vector3.up * superJumpForce, ForceMode.Impulse);

                // 스프링 애니메이션 재생
                if (springAnimator != null)
                {
                    springAnimator.SetTrigger("Bounce");
                }
            }
        }
    }
}