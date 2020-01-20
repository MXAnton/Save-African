using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    public LineRenderer leftArm;
    public LineRenderer rightArm;

    public Transform leftArmStartPosition;
    public Transform rightArmStartPosition;

    public Transform leftArmStopPosition;
    public Transform rightArmStopPosition;

    public Color armColor;

    void Update()
    {
        UpdateArmLine(leftArm, leftArmStartPosition, leftArmStopPosition);

        UpdateArmLine(rightArm, rightArmStartPosition, rightArmStopPosition);
    }

    void UpdateArmLine(LineRenderer line, Transform startPosition, Transform stopPosition)
    {
        line.startColor = armColor;
        line.endColor = armColor;

        line.SetPosition(0, startPosition.position);
        line.SetPosition(1, stopPosition.position);
    }
}
