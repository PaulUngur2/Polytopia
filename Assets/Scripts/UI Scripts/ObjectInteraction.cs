using UnityEngine;
using UnityEngine.UIElements;


public class ObjectInteraction : MonoBehaviour
{
    public VisualTreeAsset uiAsset;
    private VisualElement uiElement;
    private Button cancelButton;
    private Button interactButton;
    private bool isMouseOver;
    private Renderer[] childRenderers;
    private Color[] originalColors;
    //private bool isSelected;
    private Renderer objectRenderer;
    private Color originalObjectColor;

    void Start()
    {
        // Load the UI element defined in the UXML file
        uiElement = uiAsset.CloneTree();
        uiElement.style.display = DisplayStyle.None;
        
        //isSelected = false;
        // Check if the prefab has child objects
        if (transform.childCount > 0)
        {
            // Get all child mesh renderers
            childRenderers = GetComponentsInChildren<Renderer>();

            // Store the original colors of each child renderer
            originalColors = new Color[childRenderers.Length];
            for (int i = 0; i < childRenderers.Length; i++)
            {
                originalColors[i] = childRenderers[i].material.color;
            }
        }
        else
        {
            // Get the renderer and store the original color
            objectRenderer = GetComponent<Renderer>();
            originalObjectColor = objectRenderer.material.color;
        }
        
        interactButton = uiElement.Q<Button>("Interact");
        if (interactButton != null)
        {
            // Register a click event listener for the button
            interactButton.clickable.clicked += OnInteractButtonClicked;
        }

        // Find the button with the "Cancel" id
        cancelButton = uiElement.Q<Button>("Cancel");
        if (cancelButton != null)
        {
            // Register a click event listener for the button
            cancelButton.clickable.clicked += OnCancelButtonClicked;
        }

        // Add the UI element to the root of the UI hierarchy
        var root = GetComponent<UIDocument>().rootVisualElement;
        root.Add(uiElement);
    }

    void OnMouseEnter()
    {
        isMouseOver = true;
    }

    void OnMouseExit()
    {
        isMouseOver = false;
    }

    void Update()
    {
        // Show the UI element at the position of the mouse cursor when the game object is clicked using the mouse scroll button
        if (isMouseOver && Input.GetMouseButtonDown(2))
        {
            Selected();

            uiElement.style.position = Position.Absolute;
            uiElement.style.left = Input.mousePosition.x;
            uiElement.style.top = Screen.height - Input.mousePosition.y;
            uiElement.style.display = DisplayStyle.Flex;
        }
    }

    void Selected()
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

    void DeSelected()
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
        foreach (Human human in GlobalVariables.Humans)
        {
            if(human.available)
            {
                Vector3 destination = Vector3.zero;
                if (childRenderers != null)
                {
                    destination = transform.GetChild(0).position;
                } else if (objectRenderer != null)
                {
                    destination = transform.position;
                }

                Debug.Log("Human available " + destination);
                human.SetDestination(destination);
                human.available = false;
                break;
            }
        }
        uiElement.style.display = DisplayStyle.None;
        DeSelected();
    }

    private void OnCancelButtonClicked()
    {
        // Hide the UI element when the Cancel button is clicked
        uiElement.style.display = DisplayStyle.None;
        DeSelected();
    }
}