using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class WarriorState
    {
        public string name { get; private set; }
        public Warrior warrior { get; private set; }
        public WarriorState(string name,Warrior warrior)
        {
            this.name = name;
            this.warrior = warrior;
        }
        public static WarriorState createWarriorState(string className, object[] parameters)
        {
            //Create the object in function of the string
            if(className!=string.Empty)
            {
                var instance = Activator.CreateInstance(Type.GetType(className), parameters);
                return (WarriorState)instance;
            }
            else
            {
                return null;
            }
        }

        public virtual void doEffect()
        {

        }

        public virtual void resetEffect()
        {

        }
    }

    class Vicious : WarriorState
    {
        int numOfBlow = 0;
        public Vicious(string name, Warrior warrior) : base(name,warrior)
        { }

        public override void doEffect()
        {
            //increase damage of this attack and the next one
            if(numOfBlow<2)
            {
                warrior.setDamage(warrior.damage + 20);
            }
            numOfBlow++;
        }

        public override void resetEffect()
        {
            //reset the effect
            if (numOfBlow <= 2)
            {
                warrior.setDamage(warrior.damage - 20);
            }
        }
    }

    class Veteran : WarriorState
    {
        bool doOnce = true;
        public Veteran(string name, Warrior warrior) : base(name, warrior)
        { }
        public override void doEffect()
        {
            //enter in berserk when hp<30% of max hp
            if (doOnce && (warrior.HitPoints()<=(0.3*(float)warrior.maxHP)))
            {
                warrior.setDamage(2 * warrior.damage);
                doOnce = false;
            }
        }
    }
}
