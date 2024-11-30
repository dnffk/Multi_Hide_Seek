using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 5f; // �⺻ �̵� �ӵ�
    public float moveSpeed = 5f; // �ȱ� �ӵ�
    public float runSpeed = 10f; // �ٱ� �ӵ�

    void Update()
    {
        // Shift Ű�� ������ �� �޸��� �ӵ� ����
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = runSpeed;
        }
        else
        {
            Speed = moveSpeed;
        }

        // �Է°� �޾ƿ���
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �̵� ���� ���
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * Speed * Time.deltaTime;

        // �̵� ����
        transform.position += movement;
    }
}
