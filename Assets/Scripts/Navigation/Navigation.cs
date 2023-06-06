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
				Debug.Log("Human " + human.id + " is going home at " + Location(housing.House));
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

	public bool HasToGoHome()
    {
        if (Math.Truncate(GlobalVariables.currentTime) == 18 && GlobalVariables.currentDay == GlobalVariables.dayToGoHome)
        {
            GlobalVariables.dayToGoHome++;
			Debug.Log(GlobalVariables.dayToGoHome + " day to go home");
			return true;
        }
		return false;
    }

}