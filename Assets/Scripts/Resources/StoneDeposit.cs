public class StoneDeposit : Resources
{
    
    public StoneDeposit()
    {
        NumberOfHumans = 10;
        NumberOfResources = 500;
        TypeOfResource = "Stone";
    }
    
    public override void DisplayUI()
    {
        throw new System.NotImplementedException();
    }

    public override string GetResourceType()
    {
        return TypeOfResource;
    }

    public override int GetResourceAmount(int currentNumberOfHumans)
    {
        var totalResources = 0;
        var random = new System.Random();

        for (var i = 0; i < currentNumberOfHumans; i++)
        {
            var randomNumber = random.Next(1, 11);
            
            if (randomNumber <= 8)
            {
                totalResources += 1;
            }
            else
            {
                totalResources += 2;
            }
        }
        
        NumberOfResources -= totalResources;
        
        return totalResources;
    }
}