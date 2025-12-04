using UnityEngine;

public class MenuOpen : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private bool _isOpen;

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
