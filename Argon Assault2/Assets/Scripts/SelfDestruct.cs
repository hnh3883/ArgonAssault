using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timeTillDestroy = 3f;
    // Start is called before the first frame update
    void Start()
    {
        // ��ƼŬ�� ��ũ��Ʈ�� �ٿ��� Ư�� �ð��� ������ ��ƼŬ�� ��������� ��
        Destroy(gameObject, timeTillDestroy);
    }

}
