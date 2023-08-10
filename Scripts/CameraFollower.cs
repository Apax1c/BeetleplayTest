using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    void Update()
    {
        Vector3 temp = Input.mousePosition;
        temp.z = 1f;
        this.transform.position = Camera.main.ScreenToWorldPoint(temp);
    }
}
