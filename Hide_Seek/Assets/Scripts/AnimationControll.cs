using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControll : MonoBehaviour
{
    // ������Ʈ Ȱ��ȭ �Լ�
    public void ActivateObject()
    {
        gameObject.SetActive(true);
        Debug.Log("Object Activated");
    }

    // ������Ʈ ��Ȱ��ȭ �Լ�
    public void DeactivateObject()
    {
        gameObject.SetActive(false);
        Debug.Log("Object Deactivated");
    }
}