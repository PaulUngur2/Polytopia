using UnityEngine;
using UnityEngine.UIElements;


public class ObjectInteraction : MonoBehaviour
{
    public VisualTreeAsset uiAsset;
    private VisualElement uiElement;
    private Button cancelButton;
    private Button interactButton;
    private bool isMouseOver;
    private bool isSelected;
    private Renderer render;
    private Material[] materials;
    
    

    void Start()
    {
        // Load the UI element defined in the UXML file
        uiElement = uiAsset.CloneTree();
        uiElement.style.display = DisplayStyle.None;
        
        isSelected = false;
        render = GetComponent<Renderer>();
        Material[] materials = render.materials;
        
        interactButton = uiElement.Q<Button>("Interact");
        if (interactButton != null)
        {
            // Register a click event listener for the button
            interactButton.clickable.clicked += OnInteractButtonClicked;
            uiElement.style.display = DisplayStyle.None;
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
            if (isSelected)
            {
                DeSelected();
            } else {
                Selected();
            }
            
            uiElement.style.position = Position.Absolute;
            uiElement.style.left = Input.mousePosition.x;
            uiElement.style.top = Screen.height - Input.mousePosition.y;
            uiElement.style.display = DisplayStyle.Flex;
        }
    }
    
    void Selected()
    {
        isSelected = true;
        materials = render.materials;
        foreach (Material material in materials)
        {
            // Store the original color of the material
            material.SetColor("_OriginalColor", material.color);
                
            // Make the material redder
            Color newColor = material.color + new Color(0.2f, 0f, 0f);
            material.color = newColor;
        }
    }
    
    void DeSelected()
    {
        isSelected = false;
        materials = render.materials;
        foreach (Material material in materials)
        {
            // Restore the original color of the material
            Color originalColor = material.GetColor("_OriginalColor");
            material.color = originalColor;
        }
    }

    private void OnInteractButtonClicked()
    {
        foreach (Human human in GlobalVariables.Humans)
        {
            if(human.available)
            {
                human.SetDestination(transform.position);
                human.available = false;
                break;
            }
        }
    }

    private void OnCancelButtonClicked()
    {
        // Hide the UI element when the Cancel button is clicked
        uiElement.style.display = DisplayStyle.None;
    }
}