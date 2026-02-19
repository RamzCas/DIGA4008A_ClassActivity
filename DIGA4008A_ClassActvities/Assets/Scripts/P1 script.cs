using UnityEngine;

public class P1script : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 5;
    [SerializeField] private float JumpFource;
    [SerializeField] private float RoatationSpeed;
    private Vector2 lookInput;
    private Vector2 moveInput;

    void Update()
    {
        float y = lookInput.x * RoatationSpeed * Time.deltaTime;
        transform.Rotate(0f, y, 0f, Space.World);

        Vector3 move3 = new Vector3(moveInput.x, 0f, moveInput.y) * MoveSpeed * Time.deltaTime;
        
    }
}
