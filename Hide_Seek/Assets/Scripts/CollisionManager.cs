using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�浹Ȯ��");
        if (other.gameObject.CompareTag("Hide"))
        {
            Debug.Log("�浹 ������");
            Destroy(gameObject);
            Debug.Log("�浹 �� ����");
        }
    }
}
