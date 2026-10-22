using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rBody;
    [SerializeField] protected float maxSpeed;

    protected Vector3 velocity;
    protected Vector3 acceleration;
    protected Vector3 steeringForce;

    [SerializeField] private Vector3 worldBounds;

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

    //Helpers
    protected Vector3 CalcFuturePosition(float seconds)
    {
        Vector3 displacementInSeconds = velocity * seconds;
        return transform.position + displacementInSeconds;
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

    protected Vector3 Flee(Vector3 fleeTarget)
    {
        Vector3 desiredVelocity = transform.position - fleeTarget;
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        return desiredVelocity - velocity;
    }

    protected Vector3 Flee(GameObject fleeTarget)
    {
        return Flee(fleeTarget.transform.position);
    }

    protected Vector3 StayInBounds(float secondsAhead)
    {
        Vector3 futurePos = CalcFuturePosition(secondsAhead);

        if(futurePos.x > worldBounds.x / 2 ||
           futurePos.x < -worldBounds.x / 2 ||
           futurePos.y > worldBounds.y / 2 ||
           futurePos.y < -worldBounds.y / 2)
        {
            return Seek(Vector3.zero);
        }

        return Vector3.zero;
    }


    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, worldBounds);
    }
}
