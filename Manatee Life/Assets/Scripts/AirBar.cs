using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirBar : MonoBehaviour
{
    public Slider AirBarSlider;
    public Air airLeft;

    void Start()
    {
        airLeft = GameObject.Find("Main Camera").GetComponent<Air>();
        AirBarSlider = this.GetComponent<Slider>();
        AirBarSlider.maxValue = airLeft.maxAir;
        AirBarSlider.value = airLeft.currentAir;
    }

    public void setAir(float airAmount)
    {
        AirBarSlider.value = airAmount;
    }
}
