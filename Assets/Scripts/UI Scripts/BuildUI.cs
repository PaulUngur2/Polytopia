using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class BuildUI : MonoBehaviour
{
    private VisualElement root;
    private List<VisualElement> tabs;
    private List<Button> tabButtons;
    private int activeTabIndex = 0;

    public void Start()
    {
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
            tabButtons[i].clicked += () => ToggleDisplay(index);
        }

        ToggleDisplay(activeTabIndex);
    }

    void ToggleDisplay(int index)
    {
        if (index == activeTabIndex && tabs[index].style.display == DisplayStyle.Flex)
        {
            // Clicked on active tab, hide buttons
            tabs[index].style.display = DisplayStyle.None;
            tabButtons[index].style.backgroundColor = new Color(0.22f, 0.22f, 0.22f);
            activeTabIndex = -1;
        }
        else
        {
            // Clicked on inactive tab, show tab and hide other tabs
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

            activeTabIndex = index;
        }
    }
}
