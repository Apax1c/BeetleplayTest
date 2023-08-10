using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrajectoryDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> points = new();       // Trajectory drawed on screen
    private List<Vector3> trajectory = new();   // Trajectory along which the card flies

    private bool isTrajectoryCreated = false;
    public Action<IEnumerable<Vector3>> OnNewTrajectoryCreated = delegate { };

    [SerializeField] private GameObject card;

    public static TrajectoryDrawer Instance;

    private void Awake()
    {
        Instance = this;
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (isTrajectoryCreated)
            return;

        DrawTrajectory();
    }

    private void DrawTrajectory()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, layerMask: 3))
            {
                if (DistanceToLastPoint(hitInfo.point) > 1f)
                {
                    if (points.Count > 0)
                    {
                        trajectory.Add(hitInfo.point - points[0] + card.transform.position + new Vector3(0, 1f, 0));
                    }
                    else
                    {
                        trajectory.Add(card.transform.position);
                    }
                    points.Add(hitInfo.point);

                    lineRenderer.positionCount = points.Count;
                    lineRenderer.SetPositions(points.ToArray());
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnNewTrajectoryCreated(trajectory);
            isTrajectoryCreated = true;
        }
    }

    private float DistanceToLastPoint(Vector3 point)
    {
        if(!points.Any())
            return Mathf.Infinity;
        return Vector3.Distance(points.Last(), point);
    }
}