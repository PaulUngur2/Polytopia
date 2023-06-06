using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System;
using System.Reflection;


public class ObjectInteraction : MonoBehaviour
{
    public VisualTreeAsset uiAsset;
    private VisualElement uiElement;
    private Button cancelButton;
    private Button interactButton;
    private bool isMouseOver;
    private Renderer[] childRenderers;
    private Color[] originalColors;
    private Renderer objectRenderer;
    private Color originalObjectColor;
    private Dictionary<string, string> buildingFunctions = new Dictionary<string, string>()
    {
        { "House", "WIP" },
        { "Farm", "Work" },
        { "Forest", "Collect Wood" },
        { "Metal", "Collect Metal" },
        { "Rocks", "Collect Stone" }
    };

    private void Start()
    {
        uiElement = uiAsset.CloneTree();
        uiElement.style.display = DisplayStyle.None;
        
        if (transform.childCount > 0)
        {
            childRenderers = GetComponentsInChildren<Renderer>();
            
            originalColors = new Color[childRenderers.Length];
            for (int i = 0; i < childRenderers.Length; i++)
            {
                originalColors[i] = childRenderers[i].material.color;
            }
        }
        else
        {
            objectRenderer = GetComponent<Renderer>();
            originalObjectColor = objectRenderer.material.color;
        }
        
        interactButton = uiElement.Q<Button>("Interact");
        if (interactButton != null)
        {
            interactButton.clickable.clicked += OnInteractButtonClicked;
        }
        
        cancelButton = uiElement.Q<Button>("Cancel");
        if (cancelButton != null)
        {
            cancelButton.clickable.clicked += OnCancelButtonClicked;
        }
        
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Add(uiElement);
    }
    
    private void Update()
    {
        // Show the UI element at the position of the mouse cursor when the game object is clicked using the mouse scroll button
        if (isMouseOver && Input.GetMouseButtonDown(2))
        {
            Selected();

            interactButton = uiElement.Q<Button>("Interact");

            foreach (KeyValuePair<string, string> kvp in buildingFunctions)
            {
                if (gameObject.name.Contains(kvp.Key))
                {
                    interactButton.text = kvp.Value;
                    break;
                }
            }

            uiElement.style.position = Position.Absolute;
            uiElement.style.left = Input.mousePosition.x;
            uiElement.style.top = Screen.height - Input.mousePosition.y;
            uiElement.style.display = DisplayStyle.Flex;
        }
    }

    private void Selected()
    {
        //isSelected = true;

        if (childRenderers != null)
        {
            // The prefab has child objects with individual renderers
            for (int i = 0; i < childRenderers.Length; i++)
            {
                // Set a reddish color (you can adjust the values to get the desired shade of red)
                childRenderers[i].material.color = originalColors[i] + new Color(0.2f, 0f, 0f);
            }
        }
        else if (objectRenderer != null)
        {
            // Set a reddish color
            objectRenderer.material.color = originalObjectColor + new Color(0.2f, 0f, 0f);
        }
    }

    private void DeSelected()
    {
        //isSelected = false;
        if (childRenderers != null)
        {
            // The prefab has child objects with individual renderers
            for (int i = 0; i < childRenderers.Length; i++)
            {
                // Restore the original color
                childRenderers[i].material.color = originalColors[i];
            }
        }
        else if (objectRenderer != null)
        {
            // Restore the original color
            objectRenderer.material.color = originalObjectColor;
        }
    }

    private void OnInteractButtonClicked()
    {
        
        if (interactButton.text != "WIP")
        {
            
            foreach (Human human in GlobalVariables.humans)
            {
                if (human.available)
                {
                    Vector3 destination = Vector3.zero;
                    if (childRenderers != null)
                    {
                        destination = transform.GetChild(0).position;
                    }
                    else if (objectRenderer != null)
                    {
                        destination = transform.position;
                    }
                    
                    if (transform.name.Contains("Building"))
                    {
                        Building buildingComponent = transform.GetComponent<Building>();
                        InvokeOnInteractMethod(buildingComponent, human.id);
                    }
                    else if (transform.name.Contains("Resources"))
                    {
                        Resources resourcesComponent = transform.GetComponent<Resources>();
                        InvokeOnInteractMethod(resourcesComponent, human.id);
                    }
                    
                    human.SetDestination(destination);
                    human.available = false;
                    break;
                }
            }
        }
        uiElement.style.display = DisplayStyle.None;
        DeSelected();
    }
    
    private void InvokeOnInteractMethod<T>(T component, int humanId) where T : MonoBehaviour
    {
        string className = component.GetType().Name;
        Type type = Type.GetType(className);
        MethodInfo method = type.GetMethod("OnInteract");
        method.Invoke(component, new object[] { humanId });
    }


    private void OnCancelButtonClicked()
    {
        // Hide the UI element when the Cancel button is clicked
        uiElement.style.display = DisplayStyle.None;
        DeSelected();
    }
    
    
    private void OnMouseEnter()
    {
        isMouseOver = true;
    }

    
    private void OnMouseExit()
    {
        isMouseOver = false;
    }
}