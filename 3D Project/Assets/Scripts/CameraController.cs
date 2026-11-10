using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float horizontalSensitivity = 1.0f;
    [SerializeField] private float verticalSensitivity = 1.0f;

    public void OnLook(InputAction.CallbackContext ctx)
    {
        Vector2 lookInput = ctx.ReadValue<Vector2>();

        transform.Rotate(
            -lookInput.y * verticalSensitivity, 
            0,
            0);

        transform.parent.Rotate(0, lookInput.x * horizontalSensitivity, 0);
    }
}
