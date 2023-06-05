using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.StyleSheets;
public class ResourcesUI : MonoBehaviour
{
    private VisualElement root;
    public ProgressBar foodBar;
    public ProgressBar woodBar;
    public ProgressBar stoneBar;
    public ProgressBar ironBar;
    // Start is called before the first frame update
    void Start()
    {
        // Get the root VisualElement
        root = GetComponent<UIDocument>().rootVisualElement;
        
        // Find the progress bars and labels by name
        foodBar = root.Q<ProgressBar>("FoodBar");
        woodBar = root.Q<ProgressBar>("WoodBar");
        stoneBar = root.Q<ProgressBar>("StoneBar");
        ironBar = root.Q<ProgressBar>("IronBar");

        // Set the initial color of the progress bars to yellow
        SetProgressBarColor(foodBar, new Color(255f / 255f, 215f / 255f, 0f / 255f));
        SetProgressBarColor(woodBar, new Color(115f / 255f, 660f / 255f, 5f / 255f));
        SetProgressBarColor(stoneBar, new Color(168f / 255f, 165f / 255f, 81f / 255f));
        SetProgressBarColor(ironBar, new Color(192f / 255f, 192f / 255f, 192f / 255f));
    }

    // Update is called once per frame
    void Update()
    {
        foodBar.title = foodBar.value.ToString();
        woodBar.title = woodBar.value.ToString();
        stoneBar.title = stoneBar.value.ToString();
        ironBar.title = ironBar.value.ToString();
    }
    
    private void SetProgressBarColor(ProgressBar progressBar, Color color)
    {

    }
}
