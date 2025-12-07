using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private MixerGroup[] _masterVolume;
    [SerializeField] private Toggle _toggle;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        for (int i = 0; i < _masterVolume.Length; i++)
        {
            _masterVolume[i].ValueChanged += ChangeVolume;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _masterVolume.Length; i++)
        {
            _masterVolume[i].ValueChanged -= ChangeVolume;
        }
    }

    public void ChangeVolume(string groupName, float value)
    {
        if (_toggle.isOn)
        {
            return;
        }
        else
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

            _mixer.audioMixer.SetFloat(groupName, volume);
        }
    }
}
