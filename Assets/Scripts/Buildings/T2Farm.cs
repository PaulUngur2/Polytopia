public class T2Farm : Building
{
    public T2Farm()
    {
        NumberOfHumans = 2;
        Decoration = false;
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
}