using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    Vector2 lookMovement;

    private void Update()
    {
        Vector3 cameraPos = transform.position;
        cameraPos += (Vector3)lookMovement * 0.1f;
        transform.position = cameraPos;
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        lookMovement = ctx.ReadValue<Vector2>();
    }
}
