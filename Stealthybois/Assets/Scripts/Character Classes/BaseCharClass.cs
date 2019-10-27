using System.Collections;
using System.Collections.Generic;

public class BaseCharClass
{
    private string className;
    private string classDescription;
    private int attack;
    private int defense;
    private int speed;
    private int health;
    private int grades;
    private int social;
    private int money;
    private float critChance;

    public string ClassName
    {
        get { return className; }
        set { className = value; }
    }
    public string ClassDescription
    {
        get { return classDescription; }
        set { classDescription = value; }
    }
    public int Attack
    {
        get { return attack; }
        set { attack = value; }
    }
    public int Defense
    {
        get { return defense; }
        set { defense = value; }
    }
    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public float CritChance
    {
        get { return critChance; }
        set { critChance = value; }
    }
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    public int Grades
    {
        get { return grades; }
        set { grades = value; }
    }
    public int Social
    {
        get { return social; }
        set { social = value; }
    }
    public int Money
    {
        get { return money; }
        set { money = value; }
    }
}
