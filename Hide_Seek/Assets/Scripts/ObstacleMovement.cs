using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public Vector3 despawnPoint; // ���� ��ġ
    public float moveSpeed = 5f; // �̵� �ӵ�

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // ���������� ���� �̵�
        rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);

        // ���� ��ġ�� �����ϸ� �ı�
        if (Vector3.Distance(transform.position, despawnPoint) < 1f)
        {
            Destroy(gameObject);
        }
    }
}