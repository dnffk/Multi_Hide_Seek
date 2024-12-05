using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        // �̵� �ӵ�
    public float rotationSpeed = 720f; // ȸ�� �ӵ�
    public Camera mainCamera;          // ���� ī�޶�

    private Rigidbody rb;              // Rigidbody ������Ʈ
    private Vector3 moveDirection;     // �̵� ����

    void Start()
    {
        // Rigidbody �ʱ�ȭ
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // �̵� ó��
        MoveCharacter();

        // ĳ���� ȸ�� ó��
        RotateCharacter();
    }

    void MoveCharacter()
    {
        // ����Ű �Է� ó�� (WASD)
        float horizontal = Input.GetAxis("Horizontal"); // A/D �Ǵ� ��/��
        float vertical = Input.GetAxis("Vertical");     // W/S �Ǵ� ��/��

        // ���� �̵� ���� ��� (ĳ������ Forward�� Right�� ����)
        moveDirection = transform.forward * vertical + transform.right * horizontal;
        moveDirection.Normalize(); // ���� ���͸� ����ȭ

        // Rigidbody�� �̿��� �̵� ó��
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    void RotateCharacter()
    {
        // ���콺 ��ġ�� �������� ȸ�� ó��
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // ���콺�� ����Ű�� ��ġ�� ������� �浹�� ���
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // ���콺�� ����Ű�� �������� ĳ���� ȸ��
            Vector3 lookDirection = hit.point - transform.position;
            lookDirection.y = 0f; // y�� ����

            if (lookDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}