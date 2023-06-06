using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

// This scrip has to be attached to anything in the scene
// if you want it to initialize your variables
public class GlobalVariables : MonoBehaviour
{
    [Range(0, 24)] public static float currentTime = 12;
    public static bool buildActive;
    public static MapMatrix matrix;
    public static List<Human> humans;
    public static List<GameObject> buildings;
    public static Dictionary<string, int> resources;
    public static List<Housing> housings;
    public static int housingCapacity = 0;
    private Navigation navigation;

    private void Awake()
    {
        buildActive = false;
        matrix = new MapMatrix();
        humans = new List<Human>();
        buildings = new List<GameObject>();
        resources = new Dictionary<string, int>()
        {
            { "Wood", 100 },
            { "Food", 100 },
            { "Metal", 50 },
            { "Stone", 200 }
        };
        housings = new List<Housing>();
        navigation = new Navigation();
    }


    private void Start()
    {
        GameObject[] houseObjects = GameObject.FindGameObjectsWithTag("House");
        int i = 1;
        foreach (var house in houseObjects)
        {
            housings.Add(new Housing(house, 3, new List<int>() { i }));
            housingCapacity += 3;
            i++;
        }
    }


    private void Update()
    {
        if (currentTime > 18)
        {
            navigation.ToUpdate();
        }
    }
}