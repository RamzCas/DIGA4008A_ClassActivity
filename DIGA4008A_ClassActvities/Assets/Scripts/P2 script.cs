using UnityEngine;
using UnityEngine.InputSystem;

public class P2script : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float Movespeed = 5f;
    [SerializeField] private float Jumpstep = 1f;
    [SerializeField] private float Rotation = 100f;


    [Header("Shielding")]
    [SerializeField] private GameObject Shield;
    private bool isShielding;
  


    private Vector2 lookinput;
    private Vector2 moveinput;

    private Gamepad Gamepad;
    
    void Update()
    {
        float yaw = lookinput.x * Rotation * Time.deltaTime;
        transform.Rotate(0f, yaw, 0f, Space.World);

        Vector3 move3 = new Vector3(moveinput.x, 0f, moveinput.y) * Movespeed * Time.deltaTime;
        transform.position += move3;


        if (Shield.activeSelf)
        {
            Debug.Log("Shield");
            Gamepad.SetMotorSpeeds(0.1f, 0.3f);
        }

        if (!Shield.activeSelf)
        {
            Gamepad.SetMotorSpeeds(0.0f, 0.0f);
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveinput = context.ReadValue<Vector2>();

    }

    public void Onlook(InputAction.CallbackContext context)
    {
        lookinput = context.ReadValue<Vector2>();
    }

    public void onjump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        transform.position += Vector3.up * Jumpstep;
    }

    public void OnShield(InputAction.CallbackContext context) 
    {
        isShielding = context.ReadValueAsButton();
        Shield.SetActive(isShielding);
        Gamepad = Gamepad.current;

       
    }

    
}
