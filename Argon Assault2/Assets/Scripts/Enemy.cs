using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;

    [SerializeField] int scorePerHit = 15 ;
    [SerializeField] int hitPoints = 4;

    ScoreBoard scoreBoard;
    GameObject parentGameobject;

    void Start()
    {
        // 선언한 스코어보드 변수에 하이어라키에서 만든 스코어보드를 매칭시킨다.
        scoreBoard = FindObjectOfType<ScoreBoard>();

        // 파티클이 계속 생성되기 때문에 파티클을 담아줄 parentGameobject 변수를 선언.
        parentGameobject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    void AddRigidbody()
    {
        // 인스펙터말고 여기서 리지드바디를 지정함  
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();

        // 중력은 없앰
        rb.useGravity = false;
    }

    // 파티클 충돌을 감지할 수 있는 함수
    // 레이저의 타입이 파티클이므로, 이 함수를 통해 맞았는지를 판단
    private void OnParticleCollision(GameObject other)
    {
        // 충돌을 한다면 맞았다는 파티클 이펙트를 출력
        ProcessHit();

        // life가 1보다 작아지면 죽은 것으로 한다.
        if(hitPoints < 1)
        {
            KillEnemy();
        }
    }
    void ProcessHit()
    {   
        // 맞았다면 vfx 라는 파티클을 생성한다.
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        // 파티클의 위치는 parentGameobject 위치로 지정
        vfx.transform.parent = parentGameobject.transform;
        // 맞을 수록 life를 깎아버림
        hitPoints --;

        //scoreBoard.IncreaseScore(scorePerHit);
        //맞췄을때 점수
    }
    void KillEnemy()
    {
        // 죽는다면 스코어 보드에 점수를 표기한다. 
        scoreBoard.IncreaseScore(scorePerHit); // 죽였을때 점수

        // 죽었을때의 파티클을 생성한다.
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        // 위치는 부모 오브젝트의 위치이다.
        fx.transform.parent = parentGameobject.transform;

        // 죽었다면 게임오브젝트를 삭제한다.
        Destroy(gameObject);
    }

}
