using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamSetting : MonoBehaviour
{
    [SerializeField] private SliderSetting[] sliderSettings;
    [SerializeField] private Sprite[] emoteSprites;
    [SerializeField] private Image emoteImage;
    private void Update()
    {
        PassiveDecrease();
        EmoteUpdate();
    }

    public void UpdateParam(int sliderID, int value)
    {
        float sliderValue = sliderSettings[sliderID].slider.value;
        float nextValue = Mathf.Clamp(sliderValue + value, sliderSettings[sliderID].slider.minValue, sliderSettings[sliderID].slider.maxValue);
        sliderSettings[sliderID].slider.value = nextValue;
    }

    private void PassiveDecrease()
    {
        for (int i = 0; i < sliderSettings.Length; i++)
        {
            float sliderValue = sliderSettings[i].slider.value;
            float nextValue = Mathf.Clamp(sliderValue - sliderSettings[i].decreasePerSecond * Time.deltaTime, sliderSettings[i].slider.minValue, sliderSettings[i].slider.maxValue);
            Debug.Log(sliderSettings[i].decreasePerSecond * Time.deltaTime);
            sliderSettings[i].slider.value = nextValue;
        }
    }

    private void EmoteUpdate() {
        float sliderValue = sliderSettings[3].slider.value;
        if (sliderValue > 75)
        {
            emoteImage.sprite = emoteSprites[0];
        }
        else if (sliderValue <= 75 && sliderValue > 50)
        {
            emoteImage.sprite = emoteSprites[1];
        }
        else if (sliderValue <= 50 && sliderValue > 25)
        {
            emoteImage.sprite = emoteSprites[2];
        }
        else if (sliderValue <= 25)
        {
            emoteImage.sprite = emoteSprites[3];
        }
    }
}

[System.Serializable]
public class SliderSetting
{
    public Slider slider;
    public float decreasePerSecond;
}
