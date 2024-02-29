using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamSetting : MonoBehaviour
{
    [SerializeField] Slider[] paramSlider;

    public void UpdateParam(int sliderID, int value)
    {
        float sliderValue = paramSlider[sliderID].value;
        float nextValue = Mathf.Clamp(sliderValue + value, paramSlider[sliderID].minValue, paramSlider[sliderID].maxValue);
        paramSlider[sliderID].value = nextValue;
    }
}
