using UnityEngine;

public class GridManager : MonoBehaviour {
    public GameObject gridMask;

    private bool showGrid;

    private Plane plane;
    private Camera mainCamera;

    void Start() {
        showGrid = true;

        plane = new Plane(Vector3.up, Vector3.zero);
        mainCamera = Camera.main;
    }

    void Update() {
        if (!showGrid) return;
        
        Vector3 mousePosition = Utils.CastRay(mainCamera, plane);
        if (Vector3.Distance(transform.position, mousePosition) > 25 && gridMask.activeSelf) {
            gridMask.SetActive(false);
        } else if (Vector3.Distance(transform.position, mousePosition) < 25 && !gridMask.activeSelf){
            gridMask.SetActive(true);
        }

        gridMask.transform.position = mousePosition;
    }
}