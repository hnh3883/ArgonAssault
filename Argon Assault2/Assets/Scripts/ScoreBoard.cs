using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour
{
    int score;
    TextMeshProUGUI scoreText;

    void Start()
    {
        // 스코어 텍스트 변수에 텍스트UI를 선언해줌
        scoreText = GetComponent<TextMeshProUGUI>();
        // 처음 스코어 텍스트로는 "Start"라는 문구를 입력
        scoreText.text = "Start";
    }

    public void IncreaseScore(int amountToIncrease)
    {
        // Enemy 스크립트에서 인자값을 scorePerHit(점수)로 받아와서 스코어보드에 출력
        score += amountToIncrease;
        scoreText.text = score.ToString();
    }
}
