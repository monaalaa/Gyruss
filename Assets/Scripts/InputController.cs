using UnityEngine;

public class InputController : MonoBehaviour
{
    public PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }
    public Vector3 GetMovementVector()
    {
        return playerInputActions.Player.Movement.ReadValue<Vector3>();
    }
}
