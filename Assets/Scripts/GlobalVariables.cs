using System;
using UnityEngine;

// This scrip has to be attached to anything in the scene
// if you want it to initialize your variables
public class GlobalVariables : MonoBehaviour {
    public static MapMatrix matrix;
    
    private void Start() {
        matrix = new MapMatrix();
    }
}