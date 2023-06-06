using System;
using System.Reflection;
using UnityEngine;

public class BuildLogic
{

    public bool ResourcesUsed(GameObject prefab)
    {
        var building = prefab.GetComponent<Building>();
        var resources = InvokeOnResourcesUsed(building);
        string[] resourceTypes = { "Wood", "Stone", "Metal" };

        for (var i = 0; i < resourceTypes.Length; i++)
        {
           var value = resources != null && i < resources.Length ? resources[i] : 0;
           
           if (GlobalVariables.resources[resourceTypes[i]] >= value)
           {
               GlobalVariables.resources[resourceTypes[i]] -= value;
           }
           else
           {
               return false;
           }
        }
        
        ResourcesUI.UpdateValues();
        return true;
    }
    
    private int[] InvokeOnResourcesUsed<T>(T component) where T : MonoBehaviour
    {
        //BUG: StreetLamp problem
        
        var type = Type.GetType(component.GetType().Name);
        var method = type!.GetMethod("GetCost");
        return method!.Invoke(component, null) as int[];
    }

}