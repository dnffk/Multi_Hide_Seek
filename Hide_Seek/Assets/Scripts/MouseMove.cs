using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float sensitivity = 500f;      // ���콺 �ΰ���
    public Transform cameraTransform;     // ī�޶� Transform ����
    private float rotationX = 0f;         // X�� ȸ�� (ī�޶� ���Ʒ�)
    private float rotationY = 0f;         // Y�� ȸ�� (�÷��̾� �¿�)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // ���콺 Ŀ�� ���
    }

    void Update()
    {
        // ���콺 �Է� �ޱ�
        float mouseMoveX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseMoveY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Y�� ȸ��: �÷��̾� ��ü�� �¿�� ȸ��
        rotationY += mouseMoveX;

        // X�� ȸ��: ī�޶� ���Ʒ��� ȸ�� (���� ����)
        rotationX -= mouseMoveY;
        rotationX = Mathf.Clamp(rotationX, -30f, 35f);

        // �÷��̾� Y�� ȸ�� ����
        transform.eulerAngles = new Vector3(0, rotationY, 0);

        // ī�޶� X�� ȸ�� ����
        cameraTransform.localEulerAngles = new Vector3(rotationX, 0, 0);
    }
}
