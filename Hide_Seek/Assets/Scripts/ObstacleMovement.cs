using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public Vector3 despawnPoint; // 제거 위치
    public float moveSpeed = 5f; // 이동 속도

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // 내리막길을 따라 이동
        rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);

        // 제거 위치에 도달하면 파괴
        if (Vector3.Distance(transform.position, despawnPoint) < 1f)
        {
            Destroy(gameObject);
        }
    }
}