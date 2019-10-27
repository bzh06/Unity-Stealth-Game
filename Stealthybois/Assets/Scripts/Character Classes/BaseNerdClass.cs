using System.Collections;
using System.Collections.Generic;

public class BaseNerdClass : BaseCharClass {
    public BaseNerdClass()
    {
        ClassName = "Nerd";
        ClassDescription = "Small, weak, and socially inept, the nerd doesn't have much going for him other than his vast intellect and knowledge of obscure internet memes.";
        Health = 75;
        Grades = 145;
        Social = 30;
        Money = 100;
        Attack = 6;
        Defense = 5;
        Speed = 9;
        CritChance = 0.1f;
    }
}
