using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using MouseButton = UnityEngine.UIElements.MouseButton;

public class BuildUI : MonoBehaviour
{
    public GameObject t1House;
    public GameObject t2House;
    public GameObject t1Farm;
    public GameObject t2Farm;
    public GameObject streetLamp;

    private GameObject currentPrefab;
    private Camera mainCamera;
    private Plane plane;

    private VisualElement root;
    private VisualElement scrollView;
    private List<VisualElement> tabs;
    private List<Button> tabButtons;

    private int activeTabIndex = 0;

    public void Start()
    {
        mainCamera = Camera.main;
        plane = new Plane(Vector3.up, new Vector3(0, -0.5f, 0));
    }

    public void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        scrollView = root.Q<VisualElement>("ScrollView");

        VisualElement tab1 = root.Q<VisualElement>("tab1");
        VisualElement tab2 = root.Q<VisualElement>("tab2");
        VisualElement tab3 = root.Q<VisualElement>("tab3");
        tabs = new List<VisualElement> { tab1, tab2, tab3 };

        Button tab1Button = root.Q<Button>("tab1Button");
        Button tab2Button = root.Q<Button>("tab2Button");
        Button tab3Button = root.Q<Button>("tab3Button");
        tabButtons = new List<Button> { tab1Button, tab2Button, tab3Button };

        for (int i = 0; i < tabButtons.Count; i++)
        {
            int index = i;
            tabButtons[i].clicked += () => ToggleDisplay(index);
        }

        ToggleDisplay(activeTabIndex);

        Button t1HouseButton = root.Q<Button>("T1house");
        Button t2HouseButton = root.Q<Button>("T2house");
        Button t1FarmButton = root.Q<Button>("T1farm");
        Button t2FarmButton = root.Q<Button>("T2farm");
        Button streetLampButton = root.Q<Button>("StreetLamp");

        t1HouseButton.clicked += () => Select("T1 House");
        t2HouseButton.clicked += () => Select("T2 House");
        t1FarmButton.clicked += () => Select("T1 Farm");
        t2FarmButton.clicked += () => Select("T2 Farm");
        streetLampButton.clicked += () => Select("Street Lamp");
    }

    // private void test()
    // {
    //     Rect position1 = root.Q<VisualElement>("background").layout;
    //     Rect position = root.Q<VisualElement>("background").parent.layout;
    //     Rect width = tabs[activeTabIndex].layout;
    //     Rect rect = new Rect(position.x, position.y, width.width, position.height);
    //     Vector2 mousePos = Input.mousePosition;
    //     if(rect.Contains(mousePos))
    //     {
    //         String msg = "inside" + 
    //                       "X: " + rect.x +
    //                      "\nY: " + rect.y + 
    //                      "\n H: " + rect.height + 
    //                      "\nW: " + rect.width + 
    //                      "\nMX: " + mousePos.x + 
    //                      "\n MY: " + mousePos.y;
    //         Debug.Log(msg);
    //     }
    //     else
    //     {
    //         String msg = "outside" + 
    //                      "X: " + rect.x +
    //                      "\nY: " + rect.y + 
    //                      "\n H: " + rect.height + 
    //                      "\nW: " + rect.width + 
    //                      "\nMX: " + mousePos.x + 
    //                      "\n MY: " + mousePos.y;
    //         Debug.Log(msg);
    //     }
    // }
    
    public void Update()
    {
        if (GlobalVariables.buildActive)
        {
            Vector3 mousePosition = Utils.CastRay(mainCamera, plane);
            mousePosition.x = (float)Math.Round(mousePosition.x);
            mousePosition.z = (float)Math.Round(mousePosition.z);
            currentPrefab.transform.position = mousePosition;

            float scrollDelta = Input.mouseScrollDelta.y;
            if (scrollDelta != 0)
            {
                currentPrefab.transform.Rotate(Vector3.up, 90 * scrollDelta);
            }

            if (Input.GetMouseButton((int)MouseButton.LeftMouse))
            {
                if (Place(currentPrefab))
                {
                    Select(null);
                }
            }
            else if (Input.GetKey(KeyCode.Escape) || Input.GetMouseButtonDown((int)MouseButton.RightMouse))
            {
                Destroy(currentPrefab);
                Select(null);
            }
        }
    }

    void ToggleDisplay(int index)
    {
        if (index == activeTabIndex && tabs[index].style.display == DisplayStyle.Flex)
        {
            tabs[index].style.display = DisplayStyle.None;
            scrollView.style.display = DisplayStyle.None;
            tabButtons[index].style.backgroundColor = new Color(0.22f, 0.22f, 0.22f);
            activeTabIndex = -1;
        }
        else
        {
            for (int i = 0; i < tabs.Count; i++)
            {
                if (i == index)
                {
                    tabs[i].style.display = DisplayStyle.Flex;
                    tabButtons[i].style.backgroundColor = new Color(0.35f, 0.35f, 0.35f);
                }
                else
                {
                    tabs[i].style.display = DisplayStyle.None;
                    tabButtons[i].style.backgroundColor = new Color(0.22f, 0.22f, 0.22f);
                }
            }

            scrollView.style.display = DisplayStyle.Flex;
            activeTabIndex = index;
        }
    }

    void Select(String prefab)
    {
        if (!GlobalVariables.buildings.Contains(currentPrefab))
        {
            Destroy(currentPrefab);
        }
        if (prefab == "T1 House")
        {
            currentPrefab = Instantiate(t1House, Utils.CastRay(mainCamera, plane), Quaternion.identity);
        }
        else if (prefab == "T2 House")
        {
            currentPrefab = Instantiate(t2House, Utils.CastRay(mainCamera, plane), Quaternion.identity);
        }
        else if (prefab == "T1 Farm")
        {
            currentPrefab = Instantiate(t1Farm, Utils.CastRay(mainCamera, plane), Quaternion.identity);
        }
        else if (prefab == "T2 Farm")
        {
            currentPrefab = Instantiate(t2Farm, Utils.CastRay(mainCamera, plane), Quaternion.identity);
        }
        else if (prefab == "Street Lamp")
        {
            currentPrefab = Instantiate(streetLamp, Utils.CastRay(mainCamera, plane), Quaternion.identity);
        }
        else
        {
            GlobalVariables.buildActive = false;
            return;
        }

        GlobalVariables.buildActive = true;
    }

    private bool Place(GameObject prefab)
    {
        Bounds bounds = prefab.GetComponent<Collider>().bounds;
        BuildLogic buildLogic = new BuildLogic();

        if (GlobalVariables.matrix.CanPlace(bounds))
        {
            if (!buildLogic.ResourcesUsed(prefab))
            {
                return false;
                //BUG BUILD UI
            }
            
            GlobalVariables.matrix.AddOccupiedTiles(bounds);
            GlobalVariables.buildings.Add(prefab);

            if (prefab.GetComponent<Decorations>() == null)
            {
                HousingCheck(prefab);
            }
            
            return true;
        }

        return false;
    }
    
    private void HousingCheck(GameObject prefab)
    {
        List<int> housingList = new List<int>();
        foreach (var variaHuman in GlobalVariables.humans)
        {
            if (!variaHuman.housingStatus)
            {
                variaHuman.housingStatus = true;
                housingList.Add(variaHuman.id);
            }
        }
        
        GlobalVariables.housings.Add(new Housing(prefab, InvokeOnOccupants(prefab.GetComponent<Building>()), housingList));
        
    }
    
    private int InvokeOnOccupants<T>(T component) where T : MonoBehaviour
    {
        var type = component.GetType();
        var method = type.GetMethod("GetNumberOfHumans");
        return (int)method.Invoke(component, null);
    }

}