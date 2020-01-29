using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    float oldXPosition;
    float newXPosition;

    [Header("Head Vars")]
    public Transform headTransform;
    public float maxHeadRotation = 30;
    public float headRotationMultiplier;

    [Header("Arm Vars")]
    public LineRenderer leftArm;
    public LineRenderer rightArm;

    public Transform leftArmStartPosition;
    public Transform rightArmStartPosition;

    public Transform leftArmStopPosition;
    public Transform rightArmStopPosition;

    public Color armColor;

    [Header("Clothes")]
    public Clothes clothes;

    public SpriteRenderer hat;
    public SpriteRenderer shirt;
    public SpriteRenderer pants;

    private void Start()
    {
        SetHat();
        SetShirt();
        SetPants();

        newXPosition = transform.position.x;
        oldXPosition = newXPosition;
    }

    void Update()
    {
        newXPosition = transform.position.x;
        UpdateHeadTransform(oldXPosition, newXPosition, headRotationMultiplier, headTransform, maxHeadRotation);
        oldXPosition = newXPosition;

        UpdateArmLine(leftArm, leftArmStartPosition, leftArmStopPosition);

        UpdateArmLine(rightArm, rightArmStartPosition, rightArmStopPosition);
    }

    static void UpdateHeadTransform(float oldPos, float newPos, float rotationMultiplier, Transform headTransform, float maxRotation)
    {
        float movementVelocity = oldPos - newPos;
        float newZHeadRotation = movementVelocity * rotationMultiplier * 1000 * Time.deltaTime;

        if (newZHeadRotation != 0)
        {
            if (newZHeadRotation > maxRotation)
            {
                newZHeadRotation = maxRotation;
            }
            else if (newZHeadRotation < -maxRotation)
            {
                newZHeadRotation = -maxRotation;
            }
            //headTransform.localEulerAngles = new Vector3(0, 0, -newZHeadRotation);
            headTransform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(headTransform.localEulerAngles.z, -newZHeadRotation, 0.3f));
        }
        else
        {
            headTransform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(headTransform.localEulerAngles.z, 0, 0.03f));
        }
    }

    void UpdateArmLine(LineRenderer line, Transform startPosition, Transform stopPosition)
    {
        line.startColor = armColor;
        line.endColor = armColor;

        line.SetPosition(0, startPosition.position);
        line.SetPosition(1, stopPosition.position);
    }


    void SetHat()
    {
        int newHat = PlayerPrefs.GetInt("usedHat");

        hat.sprite = clothes.hats[newHat];
    }

    void SetShirt()
    {
        int newShirt = PlayerPrefs.GetInt("usedShirt");

        shirt.sprite = clothes.shirts[newShirt];
    }

    void SetPants()
    {

    }
}
