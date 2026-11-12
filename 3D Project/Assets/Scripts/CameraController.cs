using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float horizontalSensitivity = 1.0f;
    [SerializeField] private float verticalSensitivity = 1.0f;

    private float rotAngle = 0;

    public void OnLook(InputAction.CallbackContext ctx)
    {
        Vector2 lookInput = ctx.ReadValue<Vector2>();

        rotAngle += -lookInput.y * verticalSensitivity;
        rotAngle = Mathf.Clamp(rotAngle, -89, 89);

        if (lookInput.y < 0 && rotAngle < 89 ||
            lookInput.y > 0 && rotAngle > -89)
        {
            transform.Rotate(-lookInput.y * verticalSensitivity, 0, 0);
        }

        transform.parent.Rotate(0, lookInput.x * horizontalSensitivity, 0);
    }
}
