using UnityEngine;
using UnityEngine.InputSystem;
public class Ship : MonoBehaviour
{
    private Vector3 _screenCenter = Vector3.zero;

    [SerializeField] private float speed = 100f;
    [SerializeField] private InputAction movment;
    
    private Vector3 _direction;
   
    private void Awake()
    {
        movment.performed += Move;
        movment.canceled += Move;
    }
  
    private void OnEnable()
    {
        movment.Enable();
    }
    
    private void Move(InputAction.CallbackContext context) => _direction = context.ReadValue<Vector3>();
    
    private void Update()
    {
        RotateAroundCenter();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    protected void RotateAroundCenter()
    {
        transform.RotateAround(_screenCenter, _direction, Time.deltaTime * this.speed);
    }
   
    private void OnDisable()
    {
        movment.Disable();
    }

    private void Shoot()
    {
        ShipShootCommand shoot = new ShipShootCommand();
        shoot.Execute();
    }
}
