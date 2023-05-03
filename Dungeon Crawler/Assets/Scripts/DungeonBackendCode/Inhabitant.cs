using System;

public class Inhabitant
{
    protected int maxHP;
    protected int hp;
    protected int ac;
    protected int damage;
    protected string name;

    public Inhabitant(string name)
    {
        this.name = name;
        Random r = new Random();
        this.hp = r.Next(10, 21);
        this.maxHP = this.hp;
        this.ac = r.Next(10, 18);
        this.damage = r.Next(1, 6);  
    }

    public string getData()
    {
        string s = this.name;
        s = s + " - " + this.hp + " / " + this.ac + " / " + this.damage;
        return s;
    }

    public bool isDead()
    {
        return this.hp <= 0;
    }

    public int getAC()
    {
        return this.ac;
    }

    public int getDamage()
    {
        return this.damage;
    }

    public void takeDamage(int damage)
    {
        this.hp = this.hp - damage;
    }

    public void healHP(int amount)
    {
        this.hp += amount; // this.hp = this.hp + amount
        if(this.hp > this.maxHP)
        {
            this.hp = this.maxHP;
        }
    }
}
