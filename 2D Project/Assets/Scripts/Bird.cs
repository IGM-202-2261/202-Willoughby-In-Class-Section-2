using UnityEngine;

public class Bird : Agent
{
    private FlockCoordinator flock;

    [SerializeField, Range(0, 10)] private float cohesionWeight = 1.0f;
    [SerializeField, Range(0, 10)] private float alignmentWeight = 1.0f;
    [SerializeField, Range(0, 10)] private float separateWeight = 1.0f;
    [SerializeField, Range(0, 10)] private float separateRadius = 5.0f;

    [SerializeField] private float wanderJitter = 0.1f;
    [SerializeField, Range(0, 10)] private float wanderWeight = 1.0f;
    [SerializeField, Range(0, 10)] private float wanderRadius = 1.0f;
    [SerializeField, Range(0, 10)] private float wanderLookAhead = 1.0f;

    [SerializeField, Range(0, 10)] private float stayInBoundsWeight = 1f;
    [SerializeField] private float stayInBoundsLookAhead = 0.5f;

    void Awake()
    {
        flock = transform.parent.gameObject.GetComponent<FlockCoordinator>();
    }

    protected override Vector3 CalcSteering()
    {
        Vector3 totalForce = Vector3.zero;

        totalForce += Wander(wanderJitter, wanderRadius, wanderLookAhead) * wanderWeight;

        totalForce += StayInBounds(stayInBoundsLookAhead) * stayInBoundsWeight;

        //Cohesion
        totalForce += Seek(flock.AveragePosition) * cohesionWeight;

        //Alignment
        totalForce += Alignment(flock.AverageVelocity) * alignmentWeight;

        //Separate
        Agent[] nearby = flock.GetNearby(this, separateRadius);
        totalForce += Separate(nearby, separateRadius) * separateWeight;


        return totalForce;
    }
}
