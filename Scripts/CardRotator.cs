using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRotator : MonoBehaviour
{
    private float rotationSpeedX = 0f;
    private float rotationSpeedY = 1000f;
    private float rotationSpeedZ = 0f;

    private void Start()
    {
        FindObjectOfType<TrajectoryDrawer>().OnNewTrajectoryCreated += RotateCard;
    }

    private void RotateCard(IEnumerable<Vector3> points)
    {
        StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine()
    {
        while (true) // Infinite loop
        {
            // Calculate the rotation angles for this frame
            float rotationX = rotationSpeedX * Time.deltaTime;
            float rotationY = rotationSpeedY * Time.deltaTime;
            float rotationZ = rotationSpeedZ * Time.deltaTime;

            // Rotate the object
            transform.Rotate(rotationX, rotationY, rotationZ);

            yield return null;
        }
    }
}