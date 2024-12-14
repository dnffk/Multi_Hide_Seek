using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    public float superJumpForce = 20f; // ���� ���� ��

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� �浹 ����
        if (other.CompareTag("Player"))
        {
            Debug.Log("�浹 ����");
            // �÷��̾��� Rigidbody ��������
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            Debug.Log("Rigidbody ������");
            if (playerRb != null)
            {
                Debug.Log("�������� ���� ����");
                // ���� �ӵ��� �ʱ�ȭ�ϰ� ���� �� �߰�
                Vector3 velocity = playerRb.velocity;
                velocity.y = 0; // ���� Y�� �ӵ� ����
                playerRb.velocity = velocity;
                playerRb.AddForce(Vector3.up * superJumpForce, ForceMode.Impulse);
            }
        }
    }
}