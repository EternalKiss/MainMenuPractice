using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterVolume;
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
            if (_masterVolume != null)
            {
                return _masterVolume.name;
            }
            return "Нет имени";
        }
    }

    private void OnSliderValueChanged(float value)
    {
        ValueChanged?.Invoke(GroupName, value);
    }
}
