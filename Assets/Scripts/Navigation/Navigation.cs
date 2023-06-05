using System;
using System.Linq;
using UnityEngine;

public class Navigation
{
    public void ToUpdate()
    {
        foreach (var human in GlobalVariables.humans)
        {
            human.available = true;
            foreach (var housing in GlobalVariables.housings.Where(housing => housing.Humans.Contains(human.id)))
            {
                human.SetDestination(Location(housing.House));
                break;
            }
        }
    }

    private Vector3 Location(GameObject gameObject)
    {
        return gameObject.transform.childCount > 0
            ? gameObject.transform.GetChild(0).position
            : gameObject.transform.position;
    }
}