using UnityEngine;

public abstract class Decorations : MonoBehaviour
{
    protected int WoodCost { get; set; }
    protected int StoneCost { get; set; }
    protected int MetalCost { get; set; }

    public abstract void DisplayUI();
    public abstract int[] GetCost();

}
