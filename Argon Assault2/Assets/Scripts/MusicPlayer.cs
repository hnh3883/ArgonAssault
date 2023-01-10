using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        // ������ �����Ͽ� ������ ��������
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        // ������ ��������� ���� ������ �����ع����� ���� �������� �Ѿ
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }

        // �ƴ϶�� ���� ���ε带 �ص� �ı����� �ʵ��� ��
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
