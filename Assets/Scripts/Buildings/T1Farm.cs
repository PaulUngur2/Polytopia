using System.Linq;
using UnityEngine;

public class T1Farm : Building
{
    private int id;
    private Human currentHuman;
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
    
    public override void OnInteract(int idHuman)
    {
        if (GlobalVariables.currentTime > 6 && GlobalVariables.currentTime < 18)
        {
            currentHuman = GlobalVariables.humans.FirstOrDefault(h => h.id == idHuman);

            if (currentHuman != null)
            {
                GlobalVariables.resources["Food"] += 2;
            }
        }
    }

}