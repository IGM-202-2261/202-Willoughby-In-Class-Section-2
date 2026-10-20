using UnityEngine;

public class Seeker : Agent
{
    [SerializeField] private GameObject target;

    private Vector3 totalForce;

    protected override Vector3 CalcSteering()
    {
        totalForce = Vector3.zero;

        totalForce += Seek(target);

        return totalForce;
    }

    private void OnDrawGizmos()
    {
        Vector3 posPlusVelocity = transform.position + velocity;

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, posPlusVelocity);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(posPlusVelocity, posPlusVelocity + totalForce);
    }
}
