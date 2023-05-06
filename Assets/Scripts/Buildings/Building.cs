using UnityEngine;

public abstract class Building : MonoBehaviour
{
    protected int NumberOfHumans { get; set; }
    protected int TimeToBuild { get; set; }
    protected int WoodCost { get; set; }
    protected int StoneCost { get; set; }
    protected int MetalCost { get; set; }
    
    public abstract void DisplayUI();
    public abstract int[] GetCost();
    public abstract bool CheckLivingSpace(int currentNumberOfHumans);
    public abstract int GetTimeToBuild();
}
