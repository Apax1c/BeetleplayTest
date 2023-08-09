using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrajectoryMover : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Queue<Vector3> trajectoryPoints = new();

    private Rigidbody rb;
    private Vector3 firstPoint;
    private Vector3 lastPoint;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        FindObjectOfType<TrajectoryDrawer>().OnNewPathCreated += SetPoints;
        rb = GetComponent<Rigidbody>();
    }

    private void SetPoints(IEnumerable<Vector3> points)
    {
        trajectoryPoints = new Queue<Vector3>(points);
    }

    private void Update()
    {
        if(ShouldSetDestination())
            navMeshAgent.SetDestination(trajectoryPoints.Dequeue());

        if (trajectoryPoints.Count == 2)
        {
            firstPoint = trajectoryPoints.Peek();
        }
        else if(trajectoryPoints.Count == 1)
        {
            lastPoint = trajectoryPoints.Peek();
        }

        if (trajectoryPoints.Count == 0)
        {
            rb.AddForce(lastPoint - firstPoint, ForceMode.Force);
        }
    }

    private bool ShouldSetDestination()
    {
        if(trajectoryPoints.Count == 0)
            return false;

        if(navMeshAgent.hasPath == false || navMeshAgent.remainingDistance < 0.5f)
            return true;

        return false;
    }
}