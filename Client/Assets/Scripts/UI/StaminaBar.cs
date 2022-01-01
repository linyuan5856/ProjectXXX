using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        //slider.wholeNumbers = true;
    }

    public void SetMaxStramina(float maxStamina)
    {
        slider.maxValue = maxStamina;
        slider.value = maxStamina;
    }
    public void SetCurrentStamina(float currentStamina)
    {
        slider.value = currentStamina;
        //Debug.Log(slider.value);
    }
}
