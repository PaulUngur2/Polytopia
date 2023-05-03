public class MetalDeposit : Resources
{
    
    public MetalDeposit()
    {
        NumberOfHumans = 10;
        NumberOfResources = 250;
        TypeOfResource = "Metal";
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
            
            if (randomNumber <= 9)
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