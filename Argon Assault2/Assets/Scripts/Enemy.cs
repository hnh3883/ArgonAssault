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
        // ������ ���ھ�� ������ ���̾��Ű���� ���� ���ھ�带 ��Ī��Ų��.
        scoreBoard = FindObjectOfType<ScoreBoard>();

        // ��ƼŬ�� ��� �����Ǳ� ������ ��ƼŬ�� ����� parentGameobject ������ ����.
        parentGameobject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    void AddRigidbody()
    {
        // �ν����͸��� ���⼭ ������ٵ� ������  
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();

        // �߷��� ����
        rb.useGravity = false;
    }

    // ��ƼŬ �浹�� ������ �� �ִ� �Լ�
    // �������� Ÿ���� ��ƼŬ�̹Ƿ�, �� �Լ��� ���� �¾Ҵ����� �Ǵ�
    private void OnParticleCollision(GameObject other)
    {
        // �浹�� �Ѵٸ� �¾Ҵٴ� ��ƼŬ ����Ʈ�� ���
        ProcessHit();

        // life�� 1���� �۾����� ���� ������ �Ѵ�.
        if(hitPoints < 1)
        {
            KillEnemy();
        }
    }
    void ProcessHit()
    {   
        // �¾Ҵٸ� vfx ��� ��ƼŬ�� �����Ѵ�.
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        // ��ƼŬ�� ��ġ�� parentGameobject ��ġ�� ����
        vfx.transform.parent = parentGameobject.transform;
        // ���� ���� life�� ��ƹ���
        hitPoints --;

        //scoreBoard.IncreaseScore(scorePerHit);
        //�������� ����
    }
    void KillEnemy()
    {
        // �״´ٸ� ���ھ� ���忡 ������ ǥ���Ѵ�. 
        scoreBoard.IncreaseScore(scorePerHit); // �׿����� ����

        // �׾������� ��ƼŬ�� �����Ѵ�.
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        // ��ġ�� �θ� ������Ʈ�� ��ġ�̴�.
        fx.transform.parent = parentGameobject.transform;

        // �׾��ٸ� ���ӿ�����Ʈ�� �����Ѵ�.
        Destroy(gameObject);
    }

}
