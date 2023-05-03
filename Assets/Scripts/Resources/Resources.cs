using UnityEngine;

public abstract class Resources : MonoBehaviour
{
    protected int NumberOfHumans { get; set; }
    protected int NumberOfResources { get; set; }
    protected string TypeOfResource { get; set; }
    
    public abstract void DisplayUI();
    public abstract string GetResourceType();
    public abstract int GetResourceAmount(int currentNumberOfHumans);
}
