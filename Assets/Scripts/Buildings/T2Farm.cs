using System.Linq;

public class T2Farm : Building
{
    private Human currentHuman;
    public T2Farm()
    {
        NumberOfHumans = 2;
        TimeToBuild = 10;
        WoodCost = 15;
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