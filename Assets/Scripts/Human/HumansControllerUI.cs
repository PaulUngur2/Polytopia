using System;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Collections;
public class HumansControllerUI : MonoBehaviour {
    public static bool controlEnabled;
    public static bool setDestination;
    public static bool selectHumans;
    private void Start() {
        controlEnabled = false;
        setDestination = false;
        selectHumans = false;
    }

    private void OnEnable() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button setDestination = root.Q<Button>("setDestination");
        Button selectHumans = root.Q<Button>("selectHumans");
        setDestination.clicked += () => Select("destination");
        selectHumans.clicked += () => Select("humans");
    }
    public static void Select(String item) {
        if (item == "destination")
        {
            if (!setDestination){
                controlEnabled = true;
                setDestination = true;
                selectHumans = false;
            } else {
                controlEnabled = false;
                setDestination = false;
                selectHumans = false;
            }
        } else if (item == "humans")
        {
            if (!selectHumans){
                controlEnabled = true;
                setDestination = false;
                selectHumans = true;
            } else {
                controlEnabled = false;
                setDestination = false;
                selectHumans = false;
            }
        }
    }
}