using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour {
    public GameObject cube;
    public GameObject cylinder;
    public GameObject sphere;

    private bool cubeSelected ;
    private bool cylinderSelected;
    private bool sphereSelected;

    private GameObject currentPrefab;
    private Camera camera;
    private Plane plane;

    private void Start() {
        cubeSelected = false;
        cylinderSelected = false;
        sphereSelected = false;
        camera = Camera.main;
        plane = new Plane(Vector3.up, Vector3.zero);
    }

    void Update() {
        currentPrefab.transform.position = CastRay();
        if (cubeSelected) {
            if (Input.GetMouseButton(1)) {
                Select("");
            }
        } else if (cylinderSelected) {
            if (Input.GetMouseButton(1)) {
                Select("");
            }
        } else if (sphereSelected) {
            if (Input.GetMouseButton(1)) {
                Select("");
            }
        }
    }

    private Vector3 CastRay() {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Vector3 hitPoint = new Vector3(0, -10, 0);

        if (plane.Raycast(ray, out var enter)) {
            hitPoint = ray.GetPoint(enter);
            hitPoint.y += 1;
        }

        return hitPoint;
    }

    private void OnEnable() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buildCube = root.Q<Button>("buildCube");
        Button buildCylinder = root.Q<Button>("buildCylinder");
        Button buildSphere = root.Q<Button>("buildSphere");

        buildCube.clicked += () => Select("cube");
        buildCylinder.clicked += () => Select("cylinder");
        buildSphere.clicked += () => Select("sphere");
    }

    private void Select(String item) {
        switch (item) {
            case "cube":
                cubeSelected = true;
                cylinderSelected = false;
                sphereSelected = false;
                currentPrefab = Instantiate(cube, CastRay(), Quaternion.identity);
                break;
            case "cylinder":
                cubeSelected = false;
                cylinderSelected = true;
                sphereSelected = false;
                currentPrefab = Instantiate(cylinder, CastRay(), Quaternion.identity);
                break;
            case "sphere":
                cubeSelected = false;
                cylinderSelected = false;
                sphereSelected = true;
                currentPrefab = Instantiate(sphere, CastRay(), Quaternion.identity);
                break;
            default:
                cubeSelected = false;
                cylinderSelected = false;
                sphereSelected = false;
                currentPrefab = null;
                break;
        }
    }
}