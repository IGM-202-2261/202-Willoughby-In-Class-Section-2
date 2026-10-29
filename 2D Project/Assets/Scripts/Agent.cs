using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rBody;
    [SerializeField] protected float maxSpeed;

    protected Vector3 velocity;
    protected Vector3 acceleration;
    protected Vector3 steeringForce;

    [SerializeField] private Vector3 worldBounds;

    private Vector3 wanderTarget;
    private Quaternion nextRotation;

    public Vector3 Velocity { get { return velocity; } }

    protected abstract Vector3 CalcSteering();

    private void FixedUpdate()
    {
        acceleration = Vector3.zero;

        steeringForce = CalcSteering();
        acceleration += steeringForce;

        velocity += acceleration * Time.fixedDeltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        //if(velocity.magnitude != 0)
        //{
        //    nextRotation = Quaternion.LookRotation(velocity, Vector3.forward);
        //}

        Vector3 nextPosition = transform.position + velocity * Time.fixedDeltaTime;

        //nextRotation = transform.rotation.eulerAngles;
        //Vector3 rot = transform.rotation.eulerAngles;
        //rot.z = Vector3.Angle(Vector3.right, velocity);
        //transform.rotation = Quaternion.;
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

    protected Vector3 Pursue(Agent pursueTarget, float seconds)
    {
        Vector3 futurePos = pursueTarget.CalcFuturePosition(seconds);
        return Seek(futurePos);
    }

    protected Vector3 Evade(Agent evadeTarget, float seconds)
    {
        Vector3 futurePos = evadeTarget.CalcFuturePosition(seconds);
        return Flee(futurePos);
    }

    protected Vector3 Alignment(Vector3 targetVelocity, bool clampToMaxSpeed = false)
    {
        if (clampToMaxSpeed)
        {
            targetVelocity = Vector3.ClampMagnitude(targetVelocity, maxSpeed);
        }

        return targetVelocity - velocity;
    }

    protected Vector3 Separate(Agent[] nearby, float distance)
    {
        Vector3 separateForce = Vector3.zero;

        for(int i = 0; i < nearby.Length; i++)
        {
            float distToNearby = Vector2.Distance
                (transform.position, nearby[i].transform.position);

            //float scale = distance / distToNearby;
            float scale = 1 - distToNearby / distance;

            separateForce += Flee(nearby[i].transform.position) * scale;
        }

        separateForce = Vector3.ClampMagnitude(separateForce, maxSpeed);
        return separateForce;
    }

    protected Vector3 Wander(float jitterSpeed, float radius, float ahead)
    {
        Vector3 wanderCenter = CalcFuturePosition(ahead);

        wanderTarget.x += Random.Range(-jitterSpeed, jitterSpeed);
        wanderTarget.y += Random.Range(-jitterSpeed, jitterSpeed);
        wanderTarget = wanderTarget.normalized * radius;

        Vector3 wanderPoint = wanderCenter + wanderTarget;
        return Seek(wanderPoint);
    }


    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, worldBounds);
    }
}
