using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    public GameObject effectPrefab1;      // �浹 �� ����� ����Ʈ ������
    public GameObject effectPrefab2;      // �浹 �� ����� ����Ʈ ������
    public GameObject effectPrefab3;      // ��ǥ ������ ������ ��� ����Ʈ ������

    public Transform spawnPoint;         // �÷��̾ �ٽ� ������ ��ġ
    public float respawnDelay = 5f;      // �ٽ� �����ϱ������ ��� �ð�

    private Renderer playerRenderer;     // �÷��̾��� Renderer
    private Collider playerCollider;     // �÷��̾��� Collider

    void Start()
    {
        if (spawnPoint == null)
        {
            // �±׷� PlayerSpawnPoint �˻�
            GameObject spawnObject = GameObject.FindWithTag("SpawnPoint");
            if (spawnObject != null)
            {
                spawnPoint = spawnObject.transform;
            }
            else
            {
                Debug.LogError("�±� 'SpawnPoint'�� ���� ������Ʈ�� ã�� �� �����ϴ�! �±װ� �ùٸ��� �����Ǿ����� Ȯ���ϼ���.");
                return;
            }
        }

        // �÷��̾��� Renderer �� Collider ��������
        playerRenderer = GetComponent<Renderer>();
        playerCollider = GetComponent<Collider>();

        if (playerRenderer == null)
        {
            Debug.LogError("Renderer�� ã�� �� �����ϴ�! �� ��ũ��Ʈ�� ������ ������Ʈ�� ����Ǿ�� �մϴ�.");
        }

        if (playerCollider == null)
        {
            Debug.LogError("Collider�� ã�� �� �����ϴ�! �� ��ũ��Ʈ�� ������ ������Ʈ�� ����Ǿ�� �մϴ�.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� �±װ� "Collision"���� Ȯ��
        if (collision.gameObject.CompareTag("Collision"))
        {
            StartCoroutine(HandleRespawn());
        }

        // ��ǥ ������ ������ ���
        if (collision.gameObject.CompareTag("Goal"))
        {
            StartCoroutine(GoalManager());
        }
    }

    private IEnumerator HandleRespawn()
    {
        // spawnPoint�� ���� ��� ó�� �ߴ�
        if (spawnPoint == null)
        {
            Debug.LogError("�������� spawnPoint�� �������� �ʾҽ��ϴ�!");
            yield break;
        }

        // ����Ʈ ����
        if (effectPrefab1 != null)
        {
            Instantiate(effectPrefab1, transform.position, Quaternion.identity);
        }

        // �÷��̾� ��Ȱ��ȭ
        if (playerRenderer != null)
            playerRenderer.enabled = false;
        if (playerCollider != null)
            playerCollider.enabled = false;

        // ���
        yield return new WaitForSeconds(respawnDelay);

        // �÷��̾� ������
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;

        // �÷��̾� Ȱ��ȭ
        if (playerRenderer != null)
            playerRenderer.enabled = true;
        if (playerCollider != null)
            playerCollider.enabled = true;

        // ����Ʈ ����
        if (effectPrefab2 != null)
        {
            Instantiate(effectPrefab2, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator GoalManager()
    {
        // ��ǥ ���� �� ����Ʈ ����
        if (effectPrefab3 != null)
        {
            Instantiate(effectPrefab3, transform.position, Quaternion.identity);
        }

        // ��� ��� �� ���� ������ �̵�
        yield return new WaitForSeconds(2f); // ����Ʈ�� ���̵��� ��� ���

        // "EndingScene" ������ ��ȯ
        SceneManager.LoadScene("EndingScene");
    }
}
