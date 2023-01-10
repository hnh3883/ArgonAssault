using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timeTillDestroy = 3f;
    // Start is called before the first frame update
    void Start()
    {
        // 파티클에 스크립트를 붙여서 특정 시간이 지나면 파티클이 사라지도록 함
        Destroy(gameObject, timeTillDestroy);
    }

}
