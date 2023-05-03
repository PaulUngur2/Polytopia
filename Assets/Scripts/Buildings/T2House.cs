public class T2House : Building
{
    public T2House()
    {
        NumberOfHumans = 6;
        Decoration = false;
        TimeToBuild = 10;
        WoodCost = 10;
        StoneCost = 5;
    }

    public override void DisplayUI()
    {
        throw new System.NotImplementedException();
    }

    public override int[] GetCost()
    {
        return new int[] { WoodCost, StoneCost };
    }

    public override int GetTimeToBuild()
    {
        return TimeToBuild;
    }

    public override bool CheckLivingSpace(int currentNumberOfHumans)
    {
        return currentNumberOfHumans < NumberOfHumans;
    }
        
}
