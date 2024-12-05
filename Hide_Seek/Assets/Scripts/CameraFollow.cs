using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Target; // ����ٴ� ���
    // ī�޶� ��ǥ x, y, z
    public float posx = 0.0f;
    public float posy = 10.0f;
    public float posz = -10.0f;
    // ī�޶� ����ٴϴ� �ӵ�
    public float CameraSpeed = 10.0f;
    // ����ٴ� ��� ��ġ
    Vector3 TargetPos;

    void FixedUpdate()
    {
        // ī�޶� ��ġ ���� ( ����ٴ� ����� ��ġ + ���ϴ� ��ġ ��ǥ )
        TargetPos = new Vector3(Target.transform.position.x + posx, Target.transform.position.y + posy, Target.transform.position.z + posz);
        // ī�޶� �ε巴�� �����̵���
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }
}