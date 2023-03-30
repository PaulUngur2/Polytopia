using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour {
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

            if (cubeSelected) {
                if (Input.GetMouseButton(1)) {
                    Select("");
                } else if (Input.GetKey(KeyCode.Escape)) {
                    Destroy(currentPrefab);
                    Select("");
                }
            } else if (cylinderSelected) {
                if (Input.GetMouseButton(1)) {
                    Select("");
                } else if (Input.GetKey(KeyCode.Escape)) {
                    Destroy(currentPrefab);
                    Select("");
                }
            } else if (sphereSelected) {
                if (Input.GetMouseButton(1)) {
                    Select("");
                } else if (Input.GetKey(KeyCode.Escape)) {
                    Destroy(currentPrefab);
                    Select("");
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
}