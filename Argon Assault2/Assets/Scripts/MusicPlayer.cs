using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        // 변수를 선언하여 음악을 대입해줌
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        // 음악이 여러개라면 지금 음악을 삭제해버리고 다음 음악으로 넘어감
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }

        // 아니라면 새로 씬로드를 해도 파괴하지 않도록 함
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
