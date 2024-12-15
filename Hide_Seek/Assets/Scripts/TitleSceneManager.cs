using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class TitleSceneManager : MonoBehaviour
{
    // 스타트 버튼을 눌렀을 때 호출되는 함수
    public void OnStartButtonClicked()
    {
        // 로비 씬으로 이동
        SceneManager.LoadScene("LobbyScene");

        // Photon 네트워크 연결 시작
        PhotonNetwork.ConnectUsingSettings();
    }
}