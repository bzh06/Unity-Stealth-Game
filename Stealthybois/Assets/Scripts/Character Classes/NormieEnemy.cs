using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormieEnemy : BaseCharClass{
    public NormieEnemy()
    {
        ClassName = "Normie";
        ClassDescription = "Typical student, blends in with the rest of the crowd and doesn't stand out much.";
        Health = 50;
        Grades = 50;
        Social = 50;
        Money = 50;
        Attack = 5;
        Defense = 5;
        Speed = 5;
        CritChance = 0.05f;
    }

}
