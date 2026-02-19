using UnityEngine;
using UnityEngine.InputSystem;

public class TwoPlayersOneKeyboard : MonoBehaviour
{
    [Header("Actions(Drag from your Input Action assest)")]
    [SerializeField] private InputActionReference p1Move;
    [SerializeField] private InputActionReference p2Move;

    [SerializeField] private InputActionReference p1Jump;
    [SerializeField] private InputActionReference p2Jump;


    [Header("Players")]
    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;

    //[SerializeField] private GameObject Gb1;
    //[SerializeField] private GameObject Gb2;

    [SerializeField] private Rigidbody Rb1;
    [SerializeField] private Rigidbody Rb2;

    [SerializeField] private float speed = 5;
    [SerializeField] private float JumpHight = 10;

    private void OnEnable()
    {
        p1Move.action.Enable();
        p2Move.action.Enable();
        p1Jump.action.Enable();
        p1Jump.action.performed += Jump;
        p2Jump.action.Enable();
        p2Jump.action.performed += Jump2;
    }


    private void OnDisable()
    {
        p1Move.action.Disable();
        p2Move.action.Disable();
        p1Jump.action.Disable();
        p2Jump.action.Disable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        var m1 = p1Move.action.ReadValue<Vector2>();
        var m2 = p2Move.action.ReadValue<Vector2>();

        if (P1) P1.position += new Vector3(m1.x, 0f, m1.y) * speed * Time.deltaTime;
        if (P2) P2.position += new Vector3(m2.x, 0f, m2.y) * speed * Time.deltaTime;
        
    }

    public void Jump(InputAction.CallbackContext context) 
    {
        var J1 = p1Jump.action.IsPressed();
        //Debug.Log("jump");
        Rb1.AddForce(transform.up * JumpHight, ForceMode.Impulse);
    }

    public void Jump2(InputAction.CallbackContext context)
    {
        var J1 = p2Jump.action.IsPressed();
        //Debug.Log("jump");
        Rb2.AddForce(transform.up * JumpHight, ForceMode.Impulse);
    }


}
