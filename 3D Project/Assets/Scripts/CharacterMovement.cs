using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody)), 
    RequireComponent(typeof(CapsuleCollider))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private LayerMask walkableLayers;
    [SerializeField] private float jumpStrength = 200.0f;
    [SerializeField] private float increaseGroundDetection = 0.3f;

    private Vector3 userInput;
    private float raycastHeight;
    private Rigidbody rBody;
    private bool isGrounded;

    Vector3 projectedForward;
    Vector3 projectedRight;

    void Awake()
    {
        raycastHeight = GetComponent<CapsuleCollider>().height / 
            2.0f + increaseGroundDetection;
        rBody = GetComponent<Rigidbody>();
        isGrounded = false;
    }

    private void FixedUpdate()
    {
        Vector3 surfaceNormal = Vector3.up;

        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, Vector3.down,
            out hit, raycastHeight, walkableLayers);
        if (isGrounded)
        {
            surfaceNormal = hit.normal;
        }

        projectedForward = Vector3.ProjectOnPlane(transform.forward, surfaceNormal).normalized;
        projectedRight = Vector3.ProjectOnPlane(transform.right, surfaceNormal).normalized;

        Vector3 pos = transform.position;
        pos += projectedForward * userInput.y * moveSpeed * Time.fixedDeltaTime;
        pos += projectedRight * userInput.x * moveSpeed * Time.fixedDeltaTime;
        transform.position = pos;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        userInput = ctx.ReadValue<Vector2>();
        userInput.Normalize();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed || !isGrounded) return;

        rBody.AddForce(Vector3.up * jumpStrength);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + projectedForward);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + projectedRight);
    }
}
