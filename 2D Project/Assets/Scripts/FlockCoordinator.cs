using UnityEngine;
using System.Collections.Generic;

public class FlockCoordinator : MonoBehaviour
{
    private List<Agent> flock;
    [SerializeField] private Agent agentPrefab;
    [SerializeField] private int numAgents = 10;

    public Vector3 AverageVelocity { get; private set; }
    public Vector3 AveragePosition { get; private set; }

    void Awake()
    {
        flock = new List<Agent>();
        for(int i = 0; i < numAgents; i++)
        {
            flock.Add(Instantiate(agentPrefab, transform));
        }
    }

    private void FixedUpdate()
    {
        AverageVelocity = Vector3.zero;
        AveragePosition = Vector3.zero;

        if (flock.Count == 0) return;

        for(int i = 0; i < flock.Count; i++)
        {
            AverageVelocity += flock[i].Velocity;
            AveragePosition += flock[i].transform.position;
        }

        AverageVelocity /= flock.Count;
        AveragePosition /= flock.Count;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(AveragePosition, 0.5f);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(AveragePosition, AveragePosition + AverageVelocity);
    }
}
