using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;

    private Vector3 userInput;

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos += transform.forward * userInput.y * moveSpeed * Time.fixedDeltaTime;
        pos += transform.right * userInput.x * moveSpeed * Time.fixedDeltaTime;
        transform.position = pos;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        userInput = ctx.ReadValue<Vector2>();
        userInput.Normalize();
    }
}
