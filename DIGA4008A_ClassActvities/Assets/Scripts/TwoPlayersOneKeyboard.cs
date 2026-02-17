using UnityEngine;
using UnityEngine.InputSystem;

public class TwoPlayersOneKeyboard : MonoBehaviour
{
    [Header("Actions(Drag from your Input Action assest)")]
    [SerializeField] private InputActionReference p1Move;
    [SerializeField] private InputActionReference p2Move;


    [Header("Players")]
    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;

    [SerializeField] private float speed = 5;

    private void OnEnable()
    {
        p1Move.action.Enable();
        p2Move.action.Enable();
    }

    private void OnDisable()
    {
        p1Move.action.Disable();
        p2Move.action.Disable();
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
}
