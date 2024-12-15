using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class TitleSceneManager : MonoBehaviour
{
    // ��ŸƮ ��ư�� ������ �� ȣ��Ǵ� �Լ�
    public void OnStartButtonClicked()
    {
        // �κ� ������ �̵�
        SceneManager.LoadScene("LobbyScene");

        // Photon ��Ʈ��ũ ���� ����
        PhotonNetwork.ConnectUsingSettings();
    }
}