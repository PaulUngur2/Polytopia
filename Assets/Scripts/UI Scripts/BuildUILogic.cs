using System;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildUILogic : MonoBehaviour {
    public GameObject cube;
    public GameObject cylinder;
    public GameObject sphere;

    private bool buildEnabled;
    private bool cubeSelected;
    private bool cylinderSelected;
    private bool sphereSelected;

    private GameObject currentPrefab;
    private Camera mainCamera;
    private Plane plane;

    private void Start() {
        buildEnabled = false;
        cubeSelected = false;
        cylinderSelected = false;
        sphereSelected = false;
        mainCamera = Camera.main;
        plane = new Plane(Vector3.up, Vector3.zero);
    }

    void Update() {
        if (buildEnabled) {
            Vector3 mousePosition = Utils.CastRay(mainCamera, plane);
            mousePosition.x = (float)Math.Round(mousePosition.x);
            mousePosition.z = (float)Math.Round(mousePosition.z);
            currentPrefab.transform.position = mousePosition;

            // This if else might be useless
            // We'll see when we add the models
            if (cubeSelected) {
                if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse)) {
                    if (Place(currentPrefab)) {
                        Select("cube");
                    }
                } else if (Input.GetKey(KeyCode.Escape) || Input.GetMouseButtonDown((int)MouseButton.RightMouse)) {
                    Destroy(currentPrefab);
                    Select(null);
                }
            } else if (cylinderSelected) {
                if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse)) {
                    if (Place(currentPrefab)) {
                        Select("cylinder");
                    }
                } else if (Input.GetKey(KeyCode.Escape) || Input.GetMouseButtonDown((int)MouseButton.RightMouse)) {
                    Destroy(currentPrefab);
                    Select(null);
                }
            } else if (sphereSelected) {
                if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse)) {
                    if (Place(currentPrefab)) {
                        Select("sphere");
                    }
                } else if (Input.GetKey(KeyCode.Escape) || Input.GetMouseButtonDown((int)MouseButton.RightMouse)) {
                    Destroy(currentPrefab);
                    Select(null);
                }
            }
        }
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
                buildEnabled = true;
                cubeSelected = true;
                cylinderSelected = false;
                sphereSelected = false;
                currentPrefab = Instantiate(cube, Utils.CastRay(mainCamera, plane), Quaternion.identity);
                break;
            case "cylinder":
                buildEnabled = true;
                cubeSelected = false;
                cylinderSelected = true;
                sphereSelected = false;
                currentPrefab = Instantiate(cylinder, Utils.CastRay(mainCamera, plane), Quaternion.identity);
                break;
            case "sphere":
                buildEnabled = true;
                cubeSelected = false;
                cylinderSelected = false;
                sphereSelected = true;
                currentPrefab = Instantiate(sphere, Utils.CastRay(mainCamera, plane), Quaternion.identity);
                break;
            default:
                buildEnabled = false;
                cubeSelected = false;
                cylinderSelected = false;
                sphereSelected = false;
                currentPrefab = null;
                break;
        }
    }

    private bool Place(GameObject prefab) {
        Bounds bounds = prefab.GetComponent<Collider>().bounds;

        if (GlobalVariables.matrix.CanPlace(bounds)) {
            GlobalVariables.matrix.AddOccupiedTiles(bounds);
            return true;
        }

        return false;
    }
}