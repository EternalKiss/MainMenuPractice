using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    [SerializeField] private InputActionAsset _playerInput;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private CinemachineCamera _camera;
    [SerializeField] private ButtonInteract _buttonInteract;
    [SerializeField] private MenuOpen _menu;
    [SerializeField] private float _moveSpeed;

    private InputAction _interact;
    private InputAction _menuOpen;
    private Vector2 _move;


    private void OnEnable()
    {
        _playerInput.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        _playerInput.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        _interact = InputSystem.actions.FindAction("Interact");
        _menuOpen = InputSystem.actions.FindAction("Menu");
    }

    private void Update()
    {
        _characterController.Move((GetForward() * _move.y + GetRight() * _move.x) * Time.deltaTime * _moveSpeed);

        if( _interact.WasPressedThisFrame())
        {
            _buttonInteract.Interact();
        }

        if(_menuOpen.WasPressedThisFrame())
        {
            _menu.OpenMenu();
        }
    }

    private void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }

    private Vector3 GetForward()
    {
        Vector3 forward = _camera.transform.forward;
        forward.y = 0f;

        return forward.normalized;
    }

    private Vector3 GetRight()
    {
        Vector3 right = _camera.transform.right;
        right.y = 0f;

        return right.normalized;
    }
}
