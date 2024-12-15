using UnityEngine;
using Photon.Pun;

public class MatchManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab; // 플레이어 프리팹
    public Transform spawnPoint;    // 스폰 위치

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
                    Debug.LogError("PlayerSpawnPoint를 찾을 수 없습니다!");
                    return;
                }
            }

            // 플레이어 생성
            Vector3 spawnPosition = spawnPoint.position;
            Quaternion spawnRotation = spawnPoint.rotation;
            GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, spawnRotation);

            // 로컬 플레이어 카메라 처리
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
