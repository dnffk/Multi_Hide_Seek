using UnityEngine;
using Photon.Pun;

public class MatchManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab; // �÷��̾� ������
    public Transform spawnPoint;    // ���� ��ġ

    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (spawnPoint == null)
            {
                GameObject spawnObject = GameObject.Find("PlayerSpawnPoint");
                if (spawnObject != null)
                {
                    spawnPoint = spawnObject.transform;
                }
                else
                {
                    Debug.LogError("PlayerSpawnPoint�� ã�� �� �����ϴ�!");
                    return;
                }
            }

            // �÷��̾� ����
            Vector3 spawnPosition = spawnPoint.position;
            Quaternion spawnRotation = spawnPoint.rotation;
            GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, spawnRotation);

            // ���� �÷��̾� ī�޶� ó��
            PhotonView photonView = player.GetComponent<PhotonView>();
            if (photonView.IsMine)
            {
                Camera mainCamera = Camera.main;
                if (mainCamera != null)
                {
                    mainCamera.transform.SetParent(player.transform);
                    mainCamera.transform.localPosition = new Vector3(0, 2f, -5f);
                    mainCamera.transform.localRotation = Quaternion.Euler(10, 0, 0);
                }
            }
        }
    }
}
