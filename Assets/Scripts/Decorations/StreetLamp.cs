public class StreetLamp : Decorations
{
    public StreetLamp()
    {
        WoodCost = 5;
    }
    
    public override void DisplayUI()
    {
        throw new System.NotImplementedException();
    }

    public override int[] GetCost()
    {
        return new int[] {WoodCost};
    }
}