using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;

    void OnTriggerEnter(Collider other)
    {
        // 전투기가 부딪혔다면 아래 메소드를 실행
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        // 충돌파티클 효과 실행 
        crashVFX.Play();

        GetComponent<MeshRenderer>().enabled = false;  // 안보이게끔 함
        GetComponent<PlayerControls>().enabled = false;  // 컨트롤 할 수 없게함
        GetComponent<BoxCollider>().enabled = false;  // 박스 콜라이더를 없앰 
        Invoke("ReloadLevel", loadDelay);  // 딜레이 시간이 지난 후 씬을 다시 시작
    }
    void ReloadLevel()
    {
        // 충돌이 일어났다면 현재 씬을 계속해서 다시 시작
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
