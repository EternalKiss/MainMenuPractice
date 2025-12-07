using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerGroup : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private Slider _slider;

    public event Action<string, float> ValueChanged;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnDestroy()
    {
        _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }

    public string GroupName
    {
        get
        {
            if (_mixerGroup != null)
            {
                return _mixerGroup.name;
            }
            return "Нет имени";
        }
    }

    private void OnSliderValueChanged(float value)
    {
        ValueChanged?.Invoke(GroupName, value);
    }
}
