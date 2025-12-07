using UnityEngine;
using UnityEngine.UI;

public class ButtonPlayMusic : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _clip;

    private void OnEnable()
    {
        _button.onClick.AddListener(StartMusic);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartMusic);
    }

    public void StartMusic()
    {
        if (_clip != null && !_clip.isPlaying)
        {
            _clip.Play();
        }
        else
        {
            _clip.Stop();
        }
    }
}
