public class T1Farm : Building
{
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
}