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
        // ���ھ� �ؽ�Ʈ ������ �ؽ�ƮUI�� ��������
        scoreText = GetComponent<TextMeshProUGUI>();
        // ó�� ���ھ� �ؽ�Ʈ�δ� "Start"��� ������ �Է�
        scoreText.text = "Start";
    }

    public void IncreaseScore(int amountToIncrease)
    {
        // Enemy ��ũ��Ʈ���� ���ڰ��� scorePerHit(����)�� �޾ƿͼ� ���ھ�忡 ���
        score += amountToIncrease;
        scoreText.text = score.ToString();
    }
}
