using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSine : MonoBehaviour {
    Light forgeLight;
    public float speed = .2f;
    public float maxIntensity = 3;
    public float minIntensity = 1;

    void Start()
    {
        forgeLight = GetComponent<Light>();
    }
    void Update()
    {
        forgeLight.intensity = Mathf.PingPong(Time.time * speed, maxIntensity - 1) + 2;
    }
}
