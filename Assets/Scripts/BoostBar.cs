using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxTurbo(int turbo)
    {
        slider.maxValue = turbo;
        slider.value = turbo;
    }

    public void SetTurbo(int turbo)
    {
        slider.value = turbo;
    }
    
}
