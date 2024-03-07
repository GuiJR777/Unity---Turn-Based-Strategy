using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNameCreator
{
    List<string> maleNames = new List<string> { "John", "James", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Charles", "Thomas" };
    List<string> femaleNames = new List<string> { "Mary", "Patricia", "Jennifer", "Linda", "Elizabeth", "Barbara", "Susan", "Jessica", "Sarah", "Karen" };
    List<string> lastNames = new List<string> { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez" };

    public string CreateRandomName()
    {
        string name = "";
        if (Random.Range(0, 2) == 0)
        {
            name = maleNames[Random.Range(0, maleNames.Count)];
        }
        else
        {
            name = femaleNames[Random.Range(0, femaleNames.Count)];
        }
        name += " " + lastNames[Random.Range(0, lastNames.Count)];
        return name;
    }
}
