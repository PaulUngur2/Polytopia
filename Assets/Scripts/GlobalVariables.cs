using System;
using UnityEngine;
using System.Collections.Generic;

// This scrip has to be attached to anything in the scene
// if you want it to initialize your variables
public class GlobalVariables : MonoBehaviour {
    public static MapMatrix matrix;
    public static List<Human> selectedHumans;
    public static List<Building> buildings;
    
    private void Start() {
        matrix = new MapMatrix();
        selectedHumans = new List<Human>();
        buildings = new List<Building>();
    }   
}