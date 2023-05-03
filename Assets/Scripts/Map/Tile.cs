public class Tile {
    private bool occupied;

    public Tile() {
        occupied = false;
    }

    public bool IsOccupied() {
        return occupied;
    }

    public void SetOccupied(bool occupied) {
        this.occupied = occupied;
    }
}