using System;
using System.Reflection;
using UnityEditor.Experimental;
using UnityEngine;

public class BuildLogic
{

    public bool ResourcesUsed(GameObject prefab)
    {
        var building = prefab.GetComponent<Building>();
        var decorations = prefab.GetComponent<Decorations>();

        var resources = building == null ? InvokeOnResourcesUsed(decorations) : InvokeOnResourcesUsed(building);

        if (building != null || decorations != null)
        {
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
        }

        ResourcesUI.UpdateValues();
        return true;
    }
    
    private int[] InvokeOnResourcesUsed<T>(T component) where T : MonoBehaviour
    {
        var type = Type.GetType(component.GetType().Name);
        var method = type!.GetMethod("GetCost");
        return method!.Invoke(component, null) as int[];
    }

}