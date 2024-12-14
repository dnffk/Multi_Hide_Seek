using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform cameraTransform;               // ī�޶� Transform
    public CharacterController characterController; // ĳ���� ��Ʈ�ѷ�

    public float moveSpeed = 10f;                   // �̵� �ӵ�
    public float jumpSpeed = 5f;                   // ���� �ӵ�
    public float gravity = -20f;                    // �߷�
    public float sensitivity = 500f;               // ���콺 �ΰ���

    private float yVelocity = 0;                    // Y�� �ӵ�
    private float rotationY = 0f;                  // Y�� ȸ�� (�¿�)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // ���콺 Ŀ�� ���
    }

    void Update()
    {
        HandleMovement(); // �̵� ó��
        HandleMouseLook(); // ���콺 ȸ�� ó��
    }

    void HandleMovement()
    {
        // �̵� �Է� �ޱ�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // ���� ���� ��� (ī�޶��� Forward�� Right ����)
        Vector3 moveDirection = cameraTransform.forward * v + cameraTransform.right * h;
        moveDirection.y = 0; // Y�� ���� (���� �̵���)
        moveDirection *= moveSpeed;

        // ���� �� �߷� ó��
        //if (characterController.isGrounded)
        //{
        //    yVelocity = 0; // �ٴڿ� ���� �� Y�� �ӵ� �ʱ�ȭ
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        yVelocity = jumpSpeed;
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            yVelocity = jumpSpeed;
        }

        yVelocity += gravity * Time.deltaTime; // �߷� ����
        moveDirection.y = yVelocity; // Y�� �ӵ� ����

        // ���� �̵� ����
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        // ���콺 �Է� �ޱ� (�¿� ȸ���� ó��)
        float mouseMoveX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        // Y�� ȸ��: �÷��̾� �¿� ȸ��
        rotationY += mouseMoveX;

        // �÷��̾��� Y�� ȸ�� ����
        transform.eulerAngles = new Vector3(0, rotationY, 0);
    }
}
