using System;
using System.Collections.Generic;
using UnityEngine;


public class Housing
{
    public GameObject House { get; set; }
    public int MaxNumberOfHumans { get; set; }
    public List<int> Humans { get; set; }

    public Housing(GameObject house, int maxNumberOfHumans, List<int> humans)
    {
        House = house;
        MaxNumberOfHumans = maxNumberOfHumans;
        Humans = humans;
    }
}