using UnityEngine;

public class Seeker : Agent
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject fleeTarget;
    [SerializeField] private Agent evadeTarget;

    [SerializeField, Range(0, 10)] private float seekTargetWeight = 1f;
    [SerializeField, Range(0, 10)] private float fleeTargetWeight = 1f;
    [SerializeField, Range(0, 10)] private float stayInBoundsWeight = 1f;
    [SerializeField, Range(0, 10)] private float evadeWeight = 1f;
    [SerializeField] private float stayInBoundsLookAhead = 0.5f;
    [SerializeField] private float evadeLookAhead = 0.5f;

    private Vector3 totalForce;

    protected override Vector3 CalcSteering()
    {
        totalForce = Vector3.zero;

        totalForce += Seek(target) * seekTargetWeight;
        totalForce += Flee(fleeTarget) * fleeTargetWeight;
        totalForce += StayInBounds(stayInBoundsLookAhead) * stayInBoundsWeight;
        totalForce += Evade(evadeTarget, evadeLookAhead) * evadeWeight;

        return totalForce;
    }

    private void OnDrawGizmos()
    {
        Vector3 posPlusVelocity = transform.position + velocity;

        //Gizmos.color = Color.magenta;
        //Gizmos.DrawLine(transform.position, posPlusVelocity);
        //
        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(posPlusVelocity, posPlusVelocity + totalForce);

        Gizmos.DrawSphere(CalcFuturePosition(4), 0.3f);
    }
}
