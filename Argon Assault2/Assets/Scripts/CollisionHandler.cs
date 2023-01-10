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
        // �����Ⱑ �ε����ٸ� �Ʒ� �޼ҵ带 ����
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        // �浹��ƼŬ ȿ�� ���� 
        crashVFX.Play();

        GetComponent<MeshRenderer>().enabled = false;  // �Ⱥ��̰Բ� ��
        GetComponent<PlayerControls>().enabled = false;  // ��Ʈ�� �� �� ������
        GetComponent<BoxCollider>().enabled = false;  // �ڽ� �ݶ��̴��� ���� 
        Invoke("ReloadLevel", loadDelay);  // ������ �ð��� ���� �� ���� �ٽ� ����
    }
    void ReloadLevel()
    {
        // �浹�� �Ͼ�ٸ� ���� ���� ����ؼ� �ٽ� ����
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
