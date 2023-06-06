using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

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
    private Navigation navigation;
	public static float currentDay = 1;
    public static float dayToGoHome = 1;

    private void Awake()
    {
        buildActive = false;
        matrix = new MapMatrix();
        humans = new List<Human>();
        buildings = new List<GameObject>();
        resources = new Dictionary<string, int>()
        {
            {"Wood", 100},
            {"Food", 100},
            {"Metal", 50},
            {"Stone", 200}
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
        if (navigation.HasToGoHome())
        {
            navigation.ToUpdate();
        }

		if (Math.Truncate(currentTime) == 0 && currentDay == (dayToGoHome-1)){
			currentDay++;
			Debug.Log("CurrentDay " + currentDay);
		}
    }
}