using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FlameBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxFlame(float flame)
    {
        slider.maxValue = flame;
        slider.value = flame;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetFlame(float flame)
    {
        slider.value = flame;
    }



}
