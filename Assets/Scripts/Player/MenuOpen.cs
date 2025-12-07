using UnityEngine;
using UnityEngine.UI;

public class MenuOpen : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private Button _closeButton;

    private bool _isOpen;

    private void Awake()
    {
        _closeButton.onClick.AddListener(Close);
    }

    private void OnDestroy()
    {
        _closeButton.onClick.RemoveListener(Close);
    }

    public void OpenMenu()
    {
        if (_isOpen != true)
        {
            _isOpen = true;
            _menu.SetActive(true);
        }
        else
        {
            return;
        }
    }

    public void Close()
    {
        _menu.SetActive(false);
        _isOpen = false;
    }
}
