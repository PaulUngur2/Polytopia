using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaceBuildings : MonoBehaviour
{
    public GameObject T1housePrefab;
    public GameObject T2housePrefab;
    public GameObject T1farmPrefab;
    public GameObject T2farmPrefab;
    public GameObject StreetlampPrefab;

    private VisualElement root;
    private List<Button> buttons;
    private List<GameObject> prefabs;
    private int activeIndex = -1;

    private GameObject ground; // Reference to the "Ground" plane mesh

    private void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        buttons = new List<Button> {
            root.Q<Button>("T1house"),
            root.Q<Button>("T2house"),
            root.Q<Button>("T1farm"),
            root.Q<Button>("T2farm"),
            root.Q<Button>("StreetLamp")
        };

        prefabs = new List<GameObject> {
            T1housePrefab,
            T2housePrefab,
            T1farmPrefab,
            T2farmPrefab,
            StreetlampPrefab
        };

        // Find the "Ground" object in the scene
        ground = GameObject.Find("Ground");

        for (var i = 0; i < buttons.Count; i++)
        {
            var index = i;
            buttons[i].clicked += () => TogglePrefab(index);
        }
    }

    private void TogglePrefab(int index)
    {
        if (index == activeIndex)
        {
            // Clicked on active button, deactivate prefab placement
            activeIndex = -1;
        }
        else
        {
            // Clicked on inactive button, activate prefab placement
            activeIndex = index;
        }
    }

    private void Update()
    {
        if (activeIndex == -1 || !Input.GetMouseButtonDown(0)) return;
        // Get mouse position in world space
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the raycast hit the "Ground" object
        if (!Physics.Raycast(ray, out hit) || hit.collider.gameObject != ground) return;
        // Check if there is no collider in the placement position
        var colliders = Physics.OverlapBox(hit.point, prefabs[activeIndex].GetComponent<BoxCollider>().bounds.extents);
        if (colliders.Length != 0) return;
        // Place prefab at mouse position
        var prefab = prefabs[activeIndex];
        Instantiate(prefab, hit.point, Quaternion.identity);
                    
        // Deactivate prefab placement
        activeIndex = -1;
    }
}
