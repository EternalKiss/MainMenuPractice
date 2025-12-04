using System;
using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    private float _distance = 20f;

    public static event Action<RaycastHit?> InteractPressed;

    public void Interact()
    {
        Vector3 rayOrigin = _mainCamera.transform.position;

        Vector3 rayDirection = _mainCamera.transform.forward;

        Ray ray = new Ray(rayOrigin, rayDirection);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _distance))
        {
            InteractPressed?.Invoke(hit);
        }
        else
        {
            InteractPressed?.Invoke(null);
        }
    }
}
