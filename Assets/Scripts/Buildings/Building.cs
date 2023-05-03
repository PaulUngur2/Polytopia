using UnityEngine;

public abstract class Building : MonoBehaviour{
    private int numberOfHumans;
    private bool decoration;

    public abstract void DisplayUI();

    public int NumberOfHumans {
        get => numberOfHumans;
        set => numberOfHumans = value;
    }

    public bool Decoration {
        get => decoration;
        set => decoration = value;
    }
}
