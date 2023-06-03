public class T1House : Building
{
    public T1House() 
    {
        NumberOfHumans = 3;
        TimeToBuild = 5;
        WoodCost = 5;
    }

    public override void DisplayUI() 
    {
        throw new System.NotImplementedException();
    }
    
    public override int[] GetCost() 
    {
        return new int[] {WoodCost};
    }
    
    public override int GetTimeToBuild() 
    {
        return TimeToBuild;
    }
    
    public override bool CheckLivingSpace(int currentNumberOfHumans) 
    {
        return currentNumberOfHumans < NumberOfHumans;
    }
    
    public override void OnInteract(int idHuman) 
    {
        throw new System.NotImplementedException();
    }
}