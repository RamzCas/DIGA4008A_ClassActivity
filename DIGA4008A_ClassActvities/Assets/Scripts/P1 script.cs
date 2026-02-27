using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.Haptics;
//using UnityEngine.InputSystem.iOS;
using UnityEngine.InputSystem.XInput;
using UnityEngine.InputSystem.DualShock;

public class P1script : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float Movespeed = 5f;
    [SerializeField] private float Jumpstep = 1f;
    [SerializeField] private float Rotation = 100f;


    [Header("Shooting")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float projectileSpeed = 12;
    [SerializeField] private bool Shot;

    
    //private InputDevice InputDevice;
    private Vector2 lookinput;
    private Vector2 moveinput;
    [SerializeField] private float Timez;

    private Gamepad Gamepad;
    private PlayerInput PlayerControler;


    private void Awake()
    {
        PlayerControler= GetComponent<PlayerInput>();
    }
    void Update()
    {
        float yaw = lookinput.x * Rotation * Time.deltaTime;
        transform.Rotate(0f, yaw, 0f, Space.World);
        
        Vector3 move3 = new Vector3(moveinput.x, 0f, moveinput.y) * Movespeed * Time.deltaTime;
        transform.position += move3;

        if(Shot) 
        {
            //Debug.Log("bullet");
            Timez += Time.deltaTime;
           
        }

        if(Timez > 0.5f) 
        {
            Gamepad.SetMotorSpeeds(0.0f, 0.0f);
            Shot = false;
            Timez = 0f;
        }


       /* foreach(var device in PlayerControler.devices) 
        {
            Debug.Log("Current Device" + device.displayName);
        }*/
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

    public void OnShoot(InputAction.CallbackContext context) 
    {
        if(!context.performed) return;

        var proj = Instantiate(projectilePrefab, FirePoint.position, FirePoint.rotation);
        proj.GetComponent<Rigidbody>().linearVelocity = FirePoint.forward * projectileSpeed;
        Shot = true;
        Timez = 0f;
        //InputDevice = context.control.device;

        //Gamepad = Gamepad.current;
        var Controller = context.control.device;

        if (Controller is Gamepad pad) 
        {
            Gamepad = pad;

            if (pad is DualSenseGamepad)
            {
                //PS5 Controller
                Debug.Log(Gamepad.displayName);
                pad.SetMotorSpeeds(0.3f, 0.5f);
            }

            if (pad is XInputController)
            {
                //Xbox Controller
                Debug.Log(Gamepad.displayName);
                pad.SetMotorSpeeds(0.4f, 0.7f);
            }

            if (pad is DualShockGamepad)
            {
                //PS4 Controller
                Debug.Log(Gamepad.displayName);
                pad.SetMotorSpeeds(0.5f, 0.7f);
            }
        } 
    }
}

    

