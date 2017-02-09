using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    public Slider oxygenSlider;
    public int maxOxygen;
    public int oxygenFallRate;

    void Start()
    {
        oxygenSlider.maxValue = maxOxygen;
        oxygenSlider.value = maxOxygen;
    }

    void Update()
    {
        //oxygen Controller
        if (oxygenSlider.value >= 0)
        {
            oxygenSlider.value -= Time.deltaTime / oxygenFallRate;
        }
        else if(oxygenSlider.value <= 0)
        {
            oxygenSlider.value = 0;
        }
        else if(oxygenSlider.value >= maxOxygen)
        {
            oxygenSlider.value = maxOxygen;
        }
    }
}


