using System.Collections;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameObject effectPrefab1;      // �浹 �� ����� ����Ʈ ������
    public GameObject effectPrefab2;      // �浹 �� ����� ����Ʈ ������
    public Transform spawnPoint;         // �÷��̾ �ٽ� ������ ��ġ
    public float respawnDelay = 5f;      // �ٽ� �����ϱ������ ��� �ð�
    public float superJumpForce = 50f;   // ���� ���� ��

    private Renderer playerRenderer;     // �÷��̾��� Renderer
    private Collider playerCollider;     // �÷��̾��� Collider
    private Rigidbody playerRigidbody;

    void Start()
    {
        // �÷��̾��� ������Ʈ ��������
        playerRenderer = GetComponent<Renderer>();
        playerCollider = GetComponent<Collider>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� �±װ� "Collision"���� Ȯ��
        if (collision.gameObject.CompareTag("Collision"))
        {
            StartCoroutine(HandleRespawn());
        }

        // �浹�� ������Ʈ�� �±װ� "SuperJump"���� Ȯ��
        if (collision.gameObject.CompareTag("SuperJump"))
        {
            Debug.Log("�������� �浹 ����");
            StartCoroutine(SuperJump());
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("SuperJump"))
    //    {
    //        Debug.Log("���� ���� ���� ����!");
    //        StartCoroutine(SuperJump());
    //    }
    //}

    private IEnumerator HandleRespawn()
    {
        // ����Ʈ ����
        if (effectPrefab1 != null)
        {
            Instantiate(effectPrefab1, transform.position, Quaternion.identity);
        }

        // �÷��̾� ��Ȱ��ȭ
        playerRenderer.enabled = false;
        playerCollider.enabled = false;

        // ���
        yield return new WaitForSeconds(respawnDelay);

        // �÷��̾� ������
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;

        // �÷��̾� Ȱ��ȭ
        playerRenderer.enabled = true;
        playerCollider.enabled = true;

        if (effectPrefab2 != null)
        {
            Instantiate(effectPrefab2, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator SuperJump()
    {
        //float jumpHeight = 8f;  // ���� ����
        //float jumpDuration = 0.6f;  // ���� ���� �ð�
        //float elapsedTime = 0f;

        //Vector3 startPosition = transform.position;
        //Vector3 targetPosition = startPosition + Vector3.up * jumpHeight;

        //// ���� �ִϸ��̼� ����
        //while (elapsedTime < jumpDuration)
        //{
        //    transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / jumpDuration);
        //    elapsedTime += Time.deltaTime;
        //    yield return null;
        //}

        //// �����ϰ� ��ġ ����
        //transform.position = targetPosition;
        //Debug.Log("Super Jump Activated without Rigidbody!");

        if (playerRigidbody != null)
        {
            // ���� �������� ���� �� ����
            playerRigidbody.AddForce(Vector3.up * superJumpForce, ForceMode.Impulse);

            // ������ ȿ�� ��� (����)
            Debug.Log("Super Jump Activated!");
        }
        yield return null;
    }
}