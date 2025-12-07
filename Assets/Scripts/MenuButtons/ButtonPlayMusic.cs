using UnityEngine;
using UnityEngine.UI;

public class ButtonPlayMusic : MonoBehaviour
{
    [SerializeField] private Button _button;

    public AudioSource Clip;

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
        if (Clip != null && !Clip.isPlaying)
        {
            Clip.Play();
        }
        else
        {
            Clip.Stop();
        }
    }
}
