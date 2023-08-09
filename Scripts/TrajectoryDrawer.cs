using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrajectoryDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> points = new();
    private List<Vector3> trajectory = new();

    public Action<IEnumerable<Vector3>> OnNewPathCreated = delegate { };

    [SerializeField] private GameObject player;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            trajectory.Clear();
            points.Clear();
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, layerMask: 3))
            {
                if (DistanceToLastPoint(hitInfo.point) > 1f)
                {
                    if (points.Count > 0)
                    {
                        trajectory.Add(hitInfo.point - points[0] + player.transform.position + new Vector3(0, 1f, 0));
                    }
                    else
                    {
                        trajectory.Add(player.transform.position);
                    }
                    points.Add(hitInfo.point);

                    lineRenderer.positionCount = points.Count;
                    lineRenderer.SetPositions(points.ToArray());
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnNewPathCreated(trajectory);
        }
    }

    private float DistanceToLastPoint(Vector3 point)
    {
        if(!points.Any())
            return Mathf.Infinity;
        return Vector3.Distance(points.Last(), point);
    }
}