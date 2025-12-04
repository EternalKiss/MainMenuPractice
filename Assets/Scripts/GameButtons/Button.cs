using UnityEngine;

public class Button : MonoBehaviour
{
    public AudioSource Clip;

    private void OnEnable()
    {
        ButtonInteract.InteractPressed += PlayMusic;
    }

    private void OnDisable()
    {
        ButtonInteract.InteractPressed -= PlayMusic;
    }

    public void PlayMusic(RaycastHit? hit)
    {
        if (hit.HasValue && hit.Value.transform == transform)
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
}
