using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;

    private Vector3 userInput;

    private void FixedUpdate()
    {
        Vector3 velocity = userInput * moveSpeed * Time.fixedDeltaTime;

        Vector3 pos = transform.position;
        pos += userInput;
        transform.position = pos;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        userInput = ctx.ReadValue<Vector2>();
        userInput.z = userInput.y;
        userInput.y = 0;
        userInput.Normalize();
    }
}
