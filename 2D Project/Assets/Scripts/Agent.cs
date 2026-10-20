using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rBody;
    [SerializeField] protected float maxSpeed;

    protected Vector3 velocity;
    protected Vector3 acceleration;
    protected Vector3 steeringForce;

    protected abstract Vector3 CalcSteering();

    private void FixedUpdate()
    {
        acceleration = Vector3.zero;

        steeringForce = CalcSteering();
        acceleration += steeringForce;

        velocity += acceleration * Time.fixedDeltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        Vector3 nextPosition = transform.position + velocity * Time.fixedDeltaTime;
        rBody.MovePosition(nextPosition);
    }

    //Steering Behaviors
    protected Vector3 Seek(Vector3 target)
    {
        Vector3 desiredVelocity = target - transform.position; // unscaled
        desiredVelocity = desiredVelocity.normalized * maxSpeed; // scaled

        Vector3 seekForce = desiredVelocity - velocity; // red line in image
        return seekForce;
    }

    protected Vector3 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }
}
