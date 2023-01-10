using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("일반 설정값 세팅")]
    [Tooltip("How fast ship moves up and down based upon player input")]
    [SerializeField] float controlSpeed = 10f;
    [Tooltip("비행선이 얼마나 빠르게 좌, 우로 움직이는지")] [SerializeField] float xRange = 5f;
    [Tooltip("비행선이 얼마나 빠르게 위, 아래로 움직이는지")] [SerializeField] float yRange = 3f;


    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField] GameObject[] lasers ;

    [Header("Screen position based turning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Player input based turning")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow;
    float yThrow;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {
        // 피치에 영향을 주는 위치
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        // 피치에 영향을 주는 input값
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        // y축의 위치가 내려가면 x축의 각도도 내려가게끔 함
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        // 키보드에서 input값을 받음
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        // controlSpeed로 속도를 조정가능
        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        // rawXPos값을 -xRange ~ xRange까지 범위를 제한시킴
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        // y축도 x축과 코드 동일
        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        // 위치를 로컬좌표 기준으로 변경해줌 
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        // Fire1 인풋값을 받으면 SetLasersActive함수의 인자값을 바꿔라
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        // foreach문을 통해서 배열안의 것들을 반복시켜줌
        // 게임오브젝트 타입인 laser를 인자로 하고 그 안에서의 lasers를 반복
        foreach (GameObject laser in lasers)
        {
            //laser.SetActive(true);
            var emissionModule = laser.GetComponent<ParticleSystem>().emission; //emission은 방출되는 광원의 컬러와 강도를 제어
            emissionModule.enabled = isActive;
        }
    }
}
