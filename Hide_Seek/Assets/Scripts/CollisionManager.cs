using System.Collections;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameObject effectPrefab;      // �浹 �� ����� ����Ʈ ������
    public Transform spawnPoint;         // �÷��̾ �ٽ� ������ ��ġ
    public float respawnDelay = 5f;      // �ٽ� �����ϱ������ ��� �ð�

    private Renderer playerRenderer;     // �÷��̾��� Renderer
    private Collider playerCollider;     // �÷��̾��� Collider

    void Start()
    {
        // �÷��̾��� Renderer�� Collider ��������
        playerRenderer = GetComponent<Renderer>();
        playerCollider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� �±װ� "Collision"���� Ȯ��
        if (collision.gameObject.CompareTag("Collision"))
        {
            StartCoroutine(HandleRespawn());
        }
    }

    private IEnumerator HandleRespawn()
    {
        // ����Ʈ ����
        if (effectPrefab != null)
        {
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
        }

        // �÷��̾ �Ͻ������� ��Ȱ��ȭ
        playerRenderer.enabled = false;

        // ���
        yield return new WaitForSeconds(respawnDelay);

        // �÷��̾ ������ ��ġ�� �̵�
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;

        // �÷��̾� �ٽ� Ȱ��ȭ
        playerRenderer.enabled = true;
        playerCollider.enabled = true;
    }
}
