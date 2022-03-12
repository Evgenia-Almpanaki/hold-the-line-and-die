using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderBehaviour : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    /// <summary>
    /// Updates slider value.
    /// </summary>
    /// <param name="value">The new value of the slider</param>
    public void UpdateSliderUI(float value)
    {
        slider.value = value;
    }
}
