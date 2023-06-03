using System.Linq;
using UnityEngine;

public class T1Farm : Building
{
    private bool shouldUpdate;
    private int id;
    public T1Farm()
    {
        NumberOfHumans = 1;
        TimeToBuild = 5;
        WoodCost = 2;
    }
    
    public override void DisplayUI()
    {
        throw new System.NotImplementedException();
    }
    
    private void Update()
    {
        if (!shouldUpdate) return;
        if (!(GlobalVariables.currentTime > 18)) return;
        GoBackToHouse(id);
        shouldUpdate = false;
        Debug.Log(GlobalVariables.currentTime);

    }

    public override int[] GetCost()
    {
        return new int[] {WoodCost};
    }

    public override bool CheckLivingSpace(int currentNumberOfHumans)
    {
        return currentNumberOfHumans < NumberOfHumans;
    }

    public override int GetTimeToBuild()
    {
        return TimeToBuild;
    }
    
    private void GoBackToHouse(int idHuman)
    {
        foreach (var matchingHouse in from housing in GlobalVariables.housings where housing.Humans.Contains(idHuman) select housing.House)
        {
            GlobalVariables.humans[idHuman].available = true;
            break;
        }

    }
    
    public override void OnInteract(int idHuman)
    {
        Debug.Log(GlobalVariables.currentTime);
        if (!(GlobalVariables.currentTime > 6) || !(GlobalVariables.currentTime < 18)) return;
        var hoursWorked = GlobalVariables.currentTime - 6;

        for (var i = 0; i < hoursWorked; i++)
        {
            GlobalVariables.resources["Food"] += 1; 
        }
        shouldUpdate = true;
        id = idHuman;
    }
}