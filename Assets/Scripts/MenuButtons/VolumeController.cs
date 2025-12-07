using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private MasterVolume _masterVolume;
    [SerializeField] private ButtonMusic _buttonMusic;
    [SerializeField] private BackgroundMusic _backgroundMusic;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _masterVolume.ValueChanged += ChangeVolume;
        _backgroundMusic.ValueChanged += ChangeVolume;
        _buttonMusic.ValueChanged += ChangeVolume;
    }

    private void OnDisable()
    {
        _masterVolume.ValueChanged -= ChangeVolume;
        _backgroundMusic.ValueChanged -= ChangeVolume;
        _buttonMusic.ValueChanged -= ChangeVolume;
    }

    public void ChangeVolume(string groupName, float value)
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
