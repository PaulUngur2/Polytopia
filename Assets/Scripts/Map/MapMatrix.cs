using System;
using UnityEngine;

public class MapMatrix {
    private const int MAP_SIZE = 200;
    private readonly Tile[,] occupiedTiles;

    public MapMatrix() {
        occupiedTiles = new Tile[MAP_SIZE * 2, MAP_SIZE * 2];
        for (int i = 0; i < MAP_SIZE * 2; i++) {
            for (int j = 0; j < MAP_SIZE * 2; j++) {
                occupiedTiles[i, j] = new Tile();
            }
        }
    }

    public void AddOccupiedTiles(Bounds bounds) {
        int xPosition = (int)bounds.center.x + MAP_SIZE;
        int zPosition = (int)bounds.center.z + MAP_SIZE;
        int xLenght = (int)Math.Ceiling(bounds.extents.x * 2);
        int zLenght = (int)Math.Ceiling(bounds.extents.z * 2);

        for (int i = zPosition; i < zPosition + zLenght; i++) {
            for (int j = xPosition; j < xPosition + xLenght; j++) {
                occupiedTiles[i, j].SetOccupied(true);
            }
        }
    }

    public bool CanPlace(Bounds bounds) {
        int xPosition = (int)bounds.center.x + MAP_SIZE;
        int zPosition = (int)bounds.center.z + MAP_SIZE;
        int xLenght = (int)Math.Ceiling(bounds.extents.x * 2);
        int zLenght = (int)Math.Ceiling(bounds.extents.z * 2);

        for (int i = zPosition; i < zPosition + zLenght; i++) {
            for (int j = xPosition; j < xPosition + xLenght; j++) {
                if (occupiedTiles[i, j].IsOccupied()) {
                    return false;
                }
            }
        }

        return true;
    }
}