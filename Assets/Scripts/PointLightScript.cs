using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightScript : MonoBehaviour
{
    Light glowLight;
    float lightInt;
    public float minInt = 3f, maxInt = 5f;

    void Start()
    {
        glowLight = GetComponent<Light>();
    }

    void Update()
    {
        lightInt = Random.Range(minInt, maxInt);
        glowLight.intensity = lightInt;
    }
}
