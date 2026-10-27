using UnityEngine;

public class Wolf : Agent
{
    [SerializeField] private Agent pursueTarget;
    [SerializeField] private float pursueWeight = 1.0f;
    [SerializeField] private float stayInBoundsWeight = 1.0f;

    [SerializeField] private float pursueLookAhead = 1.0f;
    [SerializeField] private float stayInBoundsLookAhead = 0.5f;
    [SerializeField] private float closingRadius = 3.0f;

    protected override Vector3 CalcSteering()
    {
        Vector3 totalForce = Vector3.zero;

        float distToTarget = Vector2.Distance(transform.position, pursueTarget.transform.position);
        if (distToTarget < closingRadius)
        {
            totalForce += Pursue(pursueTarget, 
                pursueLookAhead * (distToTarget / closingRadius)) * pursueWeight;
        }
        else
        {
            totalForce += Pursue(pursueTarget, pursueLookAhead) * pursueWeight;
        }
        totalForce += StayInBounds(stayInBoundsLookAhead) * stayInBoundsWeight;

        return totalForce;
    }
}
