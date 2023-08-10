using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public GameObject drawPrefab;
    private GameObject trail;
    private Plane planeObj;

    private void Start()
    {
        planeObj = new Plane(Camera.main.transform.forward * -1, this.transform.position);
    }

    private void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            trail = (GameObject)Instantiate(drawPrefab, this.transform.position, Quaternion.identity);
        }
        else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (planeObj.Raycast(mouseRay, out float distance))
            {
                trail.transform.position = mouseRay.GetPoint(distance);
            }
        }
    }
}
