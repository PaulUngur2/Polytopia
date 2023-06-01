using System;
using UnityEngine;
using System.Collections.Generic;

// This scrip has to be attached to anything in the scene
// if you want it to initialize your variables
public class GlobalVariables : MonoBehaviour
{
    public static bool buildActive;
    public static MapMatrix matrix;
    public static List<Human> Humans;
    public static List<Building> buildings;

    private void Awake()
    {
        buildActive = false;
        matrix = new MapMatrix();
        Humans = new List<Human>();
        buildings = new List<Building>();
    }
}