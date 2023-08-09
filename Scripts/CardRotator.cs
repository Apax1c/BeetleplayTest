using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRotator : MonoBehaviour
{
    private float rotationSpeedX = 30f;
    private float rotationSpeedY = 700f;
    private float rotationSpeedZ = 30f;

    private void Start()
    {
        // Start the rotation coroutine
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
            //float rotationZ = rotationSpeedZ * Time.deltaTime;

            // Rotate the object
            transform.Rotate(rotationX, rotationY, rotationZ);

            yield return null; // Wait for the next frame
        }
    }
}