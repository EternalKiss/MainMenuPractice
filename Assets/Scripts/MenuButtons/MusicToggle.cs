using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private MixerGroup _group;
    [SerializeField] private Toggle _toggle;

    private void Awake()
    {
        if (_toggle != null)
        {
            _toggle.onValueChanged.AddListener(delegate { ToggleMusic(); });
        }
    }

    private void OnDestroy()
    {
        if (_toggle != null)
        {
            _toggle.onValueChanged.RemoveListener(delegate { ToggleMusic(); });
        }
    }

    public void ToggleMusic()
    {
        float targetVolumeInDb;

        if (_toggle.isOn)
        {
            targetVolumeInDb = -80f;
        }
        else
        {
            targetVolumeInDb = 0f;
        }

        _mixer.audioMixer.SetFloat(_group.GroupName, targetVolumeInDb);
    }
}
