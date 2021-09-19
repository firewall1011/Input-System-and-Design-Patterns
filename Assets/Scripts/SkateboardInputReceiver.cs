using UnityEngine;
using UnityEngine.InputSystem;

public class SkateboardInputReceiver : MonoBehaviour
{
    [SerializeField] private float detectionRange;
    
    private SkateboardController _activeSkateboard;
    private PlayerInput _playerInput;
    private CharacterController _playerController;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerController = GetComponent<CharacterController>();
    }

    public void OnMount(InputValue mountState)
    {
        if (!mountState.isPressed)
            return;
        
        var colliders = Physics.OverlapSphere(transform.position, detectionRange, LayerMask.GetMask("Vehicle"));

        foreach(var collision in colliders)
        {
            var parent = collision.transform.parent;
            if (parent != null && parent.TryGetComponent(out SkateboardController controller))
            {
                Mount(controller);
                break;
            }
        }
    }

    public void OnDismount(InputValue dismountState)
    {
        if (!dismountState.isPressed || _activeSkateboard is null)
            return;

        Dismount();
    }

    public void OnAccelerate(InputValue input)
    {
        if(_activeSkateboard is null)
            return;

        _activeSkateboard.SetAcceleration(input.Get<float>());
    }

    public void OnBreak(InputValue input)
    {
        if (_activeSkateboard is null)
            return;

        _activeSkateboard.Break(input.Get<float>());
    }

    public void OnTurn(InputValue input)
    {
        if (_activeSkateboard is null)
            return;

        _activeSkateboard.Turn(input.Get<float>());
    }

    public void Mount(SkateboardController controller)
    {
        _activeSkateboard = controller;
        transform.position = _activeSkateboard.transform.position + Vector3.one * 0.5f;
        transform.parent = _activeSkateboard.transform;

        _playerController.enabled = false;

        _playerInput.SwitchCurrentActionMap("Vehicle");
    }

    public void Dismount()
    {
        _activeSkateboard = null;
        transform.parent = null;
        
        _playerController.enabled = true;
        transform.position += Vector3.left * 2f;
        
        _playerInput.SwitchCurrentActionMap("Player");
    }
}
