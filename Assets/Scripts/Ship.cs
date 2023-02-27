using UnityEngine;
using UnityEngine.InputSystem;
public class Ship : MonoBehaviour
{
    [SerializeField] InputController inputController;
    [SerializeField] private float speed = 100f;

    private Vector3 _screenCenter = Vector3.zero;
    private Vector3 _direction;

    private void Start()
    {
        inputController.playerInputActions.Player.Shoot.performed += Shoot_performed;
    }

    private void Update()
    {
        RotateAroundCenter();
        //Shoot();
    }

    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Actions.LoseLife?.Invoke();
        }
    }

    protected void RotateAroundCenter()
    {
        _direction = inputController.GetMovementVector();
        transform.RotateAround(_screenCenter, _direction, Time.deltaTime * this.speed);
    }

    private void Shoot()
    {
        ShipShootCommand shoot = new ShipShootCommand();
        shoot.Execute();
    }

    private void OnDisable()
    {
        inputController.playerInputActions.Player.Shoot.performed -= Shoot_performed;
    }
}
