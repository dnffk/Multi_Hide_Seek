using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Target; // 따라다닐 대상
    // 카메라 좌표 x, y, z
    public float posx = 0.0f;
    public float posy = 10.0f;
    public float posz = -10.0f;
    // 카메라가 따라다니는 속도
    public float CameraSpeed = 10.0f;
    // 따라다닐 대상 위치
    Vector3 TargetPos;

    void FixedUpdate()
    {
        // 카메라 위치 지정 ( 따라다닐 대상의 위치 + 원하는 위치 좌표 )
        TargetPos = new Vector3(Target.transform.position.x + posx, Target.transform.position.y + posy, Target.transform.position.z + posz);
        // 카메라가 부드럽게 움직이도록
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }
}