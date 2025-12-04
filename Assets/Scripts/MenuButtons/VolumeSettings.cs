using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public enum VolumeType
{
    MasterVolume,
    ButtonMusic,
    BackgroundMusic
}

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider[] _sliders;

    private Dictionary<Slider, string> _sliderMappings = new Dictionary<Slider, string>();
    private Dictionary<VolumeType, string> _mixerParameterNames = new Dictionary<VolumeType, string>
    {
        { VolumeType.MasterVolume, "MasterVolume" },
        { VolumeType.ButtonMusic, "ButtonMusic" },
        { VolumeType.BackgroundMusic, "BackgroundMusic" }
    };

    public AudioMixerGroup Mixer;

    private void Awake()
    {
        gameObject.SetActive(false);

        VolumeType[] volumeTypes = (VolumeType[])Enum.GetValues(typeof(VolumeType));

        if (_sliders.Length != volumeTypes.Length)
        {
            Debug.LogError("Количество слайдеров не соответствует количеству элементов в Enum VolumeType!");
            return;
        }

        for (int i = 0; i < _sliders.Length; i++)
        {
            VolumeType currentType = volumeTypes[i];
            string mixerParamName = _mixerParameterNames[currentType];

            _sliderMappings.Add(_sliders[i], mixerParamName);

            _sliders[i].onValueChanged.AddListener(value => ChangeVolume(mixerParamName, value));
        }
    }

    public void ChangeVolume(string mixerParameterName, float value)
    {
        float volume;

        if (value <= 0.0001f)
        {
            volume = -80f;
        }
        else
        {
            volume = Mathf.Log10(value) * 20f;
        }

        Mixer.audioMixer.SetFloat(mixerParameterName, volume);
        PlayerPrefs.SetFloat("Volume_" + mixerParameterName, value);
    }
}
