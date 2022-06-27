using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class WarriorState
    {
        public string name;
        public Warrior warrior;
        public WarriorState(string name,Warrior warrior)
        {
            this.name = name;
            this.warrior = warrior;
        }
        public static WarriorState createObject(string className, object[] parameters)
        {
            var instance = Activator.CreateInstance(Type.GetType(className), parameters);
            return (WarriorState)instance;
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
            if(numOfBlow<2)
            {
                warrior.setDamage(warrior.damage + 20);
                Console.WriteLine("poison" + warrior.damage.ToString());
            }
            numOfBlow++;
        }

        public override void resetEffect()
        {
            if (numOfBlow <= 2)
            {
                warrior.setDamage(warrior.damage - 20);
                Console.WriteLine("reset" + warrior.damage.ToString());
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
            Console.WriteLine("HP : "+ warrior.HitPoints());
            if (doOnce && (warrior.HitPoints()<=(0.3*(float)warrior.maxHP)))
            {
                Console.WriteLine("berserk");
                warrior.setDamage(2 * warrior.damage);
                doOnce = false;
            }
        }
    }
}
