using System;
using System.Collections.Generic;
using UnityEngine;

public class Housing
{
    public GameObject House { get; set; }
    public int Occupants { get; set; }
    public List<int> Humans { get; set; }

    public Housing(GameObject house, int occupants, List<int> humans)
    {
        House = house;
        Occupants = occupants;
        Humans = humans;
    }
}