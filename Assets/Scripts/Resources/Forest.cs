using System;
using System.Linq;

public class Forest : Resources
{
    private Human currentHuman;
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

    public override int GetResourceAmount(float workedHours)
    {
        var totalResources = 0;
        var random = new Random();

        for (var i = 0; i < workedHours; i++)
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
    
    public override void OnInteract(int idHuman)
    {
        if (GlobalVariables.currentTime > 6 && GlobalVariables.currentTime < 18)
        {
            currentHuman = GlobalVariables.humans.FirstOrDefault(h => h.id == idHuman);

            if (currentHuman != null)
            {
                var hoursWorked = GlobalVariables.currentTime - 6;
                
                GlobalVariables.resources[TypeOfResource] += GetResourceAmount(hoursWorked);
                ResourcesUI.UpdateValues();
            }
        }
    }
}