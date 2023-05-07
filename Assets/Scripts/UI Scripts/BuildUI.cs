using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class BuildUI : MonoBehaviour
{
    private VisualElement root;
    private List<VisualElement> tabs;
    private List<Button> tabButtons;
    private int selectedIndex = 0;

    void Start() {
        root = GetComponent<UIDocument>().rootVisualElement;

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
            tabButtons[i].clicked += () => {
                ToggleDisplay(tabs[index]);
                UpdateButtonColors(index);
            };
        }
    }

    void UpdateButtonColors(int newIndex)
    {

        tabButtons[newIndex].style.backgroundColor = new StyleColor(new Color(0.35f, 0.35f, 0.35f));
        
        if (selectedIndex != newIndex)
        {
            tabButtons[selectedIndex].style.backgroundColor = new StyleColor(new Color(0.2f, 0.2f, 0.2f));
            selectedIndex = newIndex;
        }
    }

    void ToggleDisplay(VisualElement container)
    {
        int index = tabs.IndexOf(container);
        for (int i = 0; i < tabs.Count; i++)
        {
            if (i == index)
            {
                tabs[i].style.display = DisplayStyle.Flex;
            }
            else
            {
                tabs[i].style.display = DisplayStyle.None;
                
            }
        }
    }
}
