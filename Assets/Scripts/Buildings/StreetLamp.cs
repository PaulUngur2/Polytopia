public class StreetLamp : Building
{
    public StreetLamp()
    {
        Decoration = true;
        TimeToBuild = 0;
        WoodCost = 5;
        
    }
    
    public override void DisplayUI()
    {
        throw new System.NotImplementedException();
    }

    public override int[] GetCost()
    {
        throw new System.NotImplementedException();
    }

    public override bool CheckLivingSpace(int currentNumberOfHumans)
    {
        throw new System.NotImplementedException();
    }

    public override int GetTimeToBuild()
    {
        throw new System.NotImplementedException();
    }
}