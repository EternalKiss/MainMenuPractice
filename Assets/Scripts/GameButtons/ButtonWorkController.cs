using UnityEngine;

public class ButtonWorkController : MonoBehaviour
{
    [SerializeField] private Button[] _buttonsClips;

    private void OnEnable()
    {
        ButtonInteract.InteractPressed += ButtonsPlay;
    }

    private void OnDisable()
    {
        ButtonInteract.InteractPressed -= ButtonsPlay;
    }

    private void ButtonsPlay(RaycastHit? hit)
    {
        foreach (var button in _buttonsClips)
        {
            if (hit.HasValue && hit.Value.transform == transform)
            {
                if (button.Clip != null && !button.Clip.isPlaying)
                {
                    button.Clip.Play();
                }
                else
                {
                    button.Clip.Stop();
                }
            }
        }
    }
}
