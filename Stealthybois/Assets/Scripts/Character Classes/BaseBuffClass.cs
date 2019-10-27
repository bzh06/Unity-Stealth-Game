using System.Collections;
using System.Collections.Generic;

public class BaseBuffClass : BaseCharClass{
    public BaseBuffClass()
    {
        ClassName = "Meathead";
        ClassDescription = "Physically strong and imposing, this class focuses on brute strength and power above all else. Weaknesses include leg day and basic Algebra.";
        Health = 150;
        Grades = 60;
        Social = 50;
        Money = 90;
        Attack = 12;
        Defense = 5;
        Speed = 3;
        CritChance = 0.02f;
    }
}
