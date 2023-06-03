using System;
using UnityEngine;
using System.Collections.Generic;

// This scrip has to be attached to anything in the scene
// if you want it to initialize your variables
public class GlobalVariables : MonoBehaviour
{
    public static bool buildActive;
    public static MapMatrix matrix;
    public static List<Human> humans;
    public static List<GameObject> buildings;
    public static float currentTime = 12;
    public static Dictionary<string, int> resources;
    public static List<Housing> housings;
    public static int housingCapacity = 0;

    private void Awake()
    {
        buildActive = false;
        matrix = new MapMatrix();
        humans = new List<Human>();
        buildings = new List<GameObject>();
        resources = new Dictionary<string, int>()
        {
            {"Wood", 0},
            {"Food", 0},
            {"Metal", 0},
            {"Stone", 0}
        };
        housings = new List<Housing>();
    }

    private void Start()
    {
        housings.Add(new Housing(GameObject.FindGameObjectWithTag("House"),2, new List<int>() {0, 1}));
        housingCapacity += 2;
    }
}