using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public GameObject drawPrefab;
    private GameObject trail;
    private Plane planeObj;
    private Vector3 startPos;

    private void Start()
    {
        planeObj = new Plane(Camera.main.transform.forward * -1, this.transform.position);
    }

    private void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            trail = (GameObject)Instantiate(drawPrefab, this.transform.position, Quaternion.identity);

            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance;
            if(planeObj.Raycast(mouseRay, out distance))
            {
                startPos = mouseRay.GetPoint(distance);
            }
        }
        else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance;
            if (planeObj.Raycast(mouseRay, out distance))
            {
                trail.transform.position = mouseRay.GetPoint(distance);
            }
        }
    }
}
