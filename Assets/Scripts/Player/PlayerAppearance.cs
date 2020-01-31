using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    float oldXPosition;
    float newXPosition;

    [Header("Head Vars")]
    public Transform headTransform;
    public float maxHeadRotation = 50;
    public float headRotationMultiplier = 50;

    [Header("Arm Vars")]
    public LineRenderer leftArm;
    public LineRenderer rightArm;

    public Transform leftArmStartPosition;
    public Transform rightArmStartPosition;

    public Transform leftArmStopPosition;
    public Transform rightArmStopPosition;

    public Color armColor;

    [Header("Legs Vars")]
    public Transform legsTransform;
    public float maxLegsRotation = 20;
    public float legsRotationMultiplier = -15;

    [Header("Clothes")]
    public Clothes clothes;

    public GameObject hatParent;
    public GameObject shirtParent;
    public GameObject pantsParent;

    public Vector2 hatPosition;
    public Vector2 shirtPosition;
    public Vector2 pantsPosition;

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
        UpdateTransform(headTransform, oldXPosition, newXPosition, headRotationMultiplier, maxHeadRotation);
        UpdateTransform(legsTransform, oldXPosition, newXPosition, legsRotationMultiplier, maxLegsRotation);
        oldXPosition = newXPosition;

        UpdateArmLine(leftArm, leftArmStartPosition, leftArmStopPosition);

        UpdateArmLine(rightArm, rightArmStartPosition, rightArmStopPosition);
    }

    static void UpdateTransform(Transform updateTransform, float oldPos, float newPos, float rotationMultiplier, float maxRotation)
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
            updateTransform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(updateTransform.localEulerAngles.z, -newZHeadRotation, 0.3f));
        }
        else
        {
            updateTransform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(updateTransform.localEulerAngles.z, 0, 0.03f));
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

        GameObject newHatObject = Instantiate(clothes.hats[newHat], hatParent.transform.position, Quaternion.identity, hatParent.transform);
        newHatObject.transform.localPosition = hatPosition;
    }

    void SetShirt()
    {
        int newShirt = PlayerPrefs.GetInt("usedShirt");

        GameObject newShirtObject = Instantiate(clothes.shirts[newShirt], shirtParent.transform.position, Quaternion.identity, shirtParent.transform);
        newShirtObject.transform.localPosition = shirtPosition;
    }

    void SetPants()
    {
        int newPants = PlayerPrefs.GetInt("usedPants");

        GameObject newPantsObject = Instantiate(clothes.pants[newPants], pantsParent.transform.position, Quaternion.identity, pantsParent.transform);
        newPantsObject.transform.localPosition = pantsPosition;
    }
}
