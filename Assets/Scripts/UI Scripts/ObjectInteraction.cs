using UnityEngine;
using UnityEngine.UIElements;

public class ObjectInteraction : MonoBehaviour
{
    public VisualTreeAsset uiAsset;
    private VisualElement uiElement;
    private Button cancelButton;
    private bool isMouseOver;

    void Start()
    {
        // Load the UI element defined in the UXML file
        uiElement = uiAsset.CloneTree();
        uiElement.style.display = DisplayStyle.None;

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
            uiElement.style.position = Position.Absolute;
            uiElement.style.left = Input.mousePosition.x;
            uiElement.style.top = Screen.height - Input.mousePosition.y;
            uiElement.style.display = DisplayStyle.Flex;
        }
    }

    private void OnCancelButtonClicked()
    {
        // Hide the UI element when the Cancel button is clicked
        uiElement.style.display = DisplayStyle.None;
    }
}