using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    public float superJumpForce = 20f; // ���� ���� ��
    public Animator springAnimator;   // ������ �ִϸ�����

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� �浹 ����
        if (other.CompareTag("Player"))
        {
            // �÷��̾��� Rigidbody ��������
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                // ���� �ӵ��� �ʱ�ȭ�ϰ� ���� �� �߰�
                Vector3 velocity = playerRb.velocity;
                velocity.y = 0; // ���� Y�� �ӵ� ����
                playerRb.velocity = velocity;
                playerRb.AddForce(Vector3.up * superJumpForce, ForceMode.Impulse);

                // ������ �ִϸ��̼� ���
                if (springAnimator != null)
                {
                    springAnimator.SetTrigger("Bounce");
                }
            }
        }
    }
}