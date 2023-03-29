using UnityEngine;
using UnityEngine.UIElements;

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

    // Update is called once per frame
    void Update() {
        if (showGrid) {
            Vector3 mousePosition = Utils.CastRay(mainCamera, plane);
            gridMask.transform.position = mousePosition;
        }
    }
}