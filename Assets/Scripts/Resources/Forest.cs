using System;

public class Forest : Resources
{
    public Forest()
    {
        NumberOfHumans = 20;
        NumberOfResources = 1000;
        TypeOfResource = "Wood" ;
    }
    
    public override void DisplayUI()
    {
        throw new NotImplementedException();
    }

    public override string GetResourceType()
    {
        return TypeOfResource;
    }

    public override int GetResourceAmount(int currentNumberOfHumans)
    {
        var totalResources = 0;
        var random = new Random();

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