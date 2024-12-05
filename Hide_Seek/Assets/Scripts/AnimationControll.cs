using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControll : MonoBehaviour
{
    // 오브젝트 활성화 함수
    public void ActivateObject()
    {
        gameObject.SetActive(true);
        Debug.Log("Object Activated");
    }

    // 오브젝트 비활성화 함수
    public void DeactivateObject()
    {
        gameObject.SetActive(false);
        Debug.Log("Object Deactivated");
    }
}