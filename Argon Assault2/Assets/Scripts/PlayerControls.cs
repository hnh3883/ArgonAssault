using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("�Ϲ� ������ ����")]
    [Tooltip("How fast ship moves up and down based upon player input")]
    [SerializeField] float controlSpeed = 10f;
    [Tooltip("���༱�� �󸶳� ������ ��, ��� �����̴���")] [SerializeField] float xRange = 5f;
    [Tooltip("���༱�� �󸶳� ������ ��, �Ʒ��� �����̴���")] [SerializeField] float yRange = 3f;


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
        // ��ġ�� ������ �ִ� ��ġ
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        // ��ġ�� ������ �ִ� input��
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        // y���� ��ġ�� �������� x���� ������ �������Բ� ��
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        // Ű���忡�� input���� ����
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        // controlSpeed�� �ӵ��� ��������
        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        // rawXPos���� -xRange ~ xRange���� ������ ���ѽ�Ŵ
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        // y�൵ x��� �ڵ� ����
        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        // ��ġ�� ������ǥ �������� �������� 
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        // Fire1 ��ǲ���� ������ SetLasersActive�Լ��� ���ڰ��� �ٲ��
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
        // foreach���� ���ؼ� �迭���� �͵��� �ݺ�������
        // ���ӿ�����Ʈ Ÿ���� laser�� ���ڷ� �ϰ� �� �ȿ����� lasers�� �ݺ�
        foreach (GameObject laser in lasers)
        {
            //laser.SetActive(true);
            var emissionModule = laser.GetComponent<ParticleSystem>().emission; //emission�� ����Ǵ� ������ �÷��� ������ ����
            emissionModule.enabled = isActive;
        }
    }
}
