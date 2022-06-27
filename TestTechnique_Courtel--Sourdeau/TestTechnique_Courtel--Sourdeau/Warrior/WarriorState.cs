using System;

namespace ConsoleApp1
{
    /// <summary>
    /// the mother class for all warrior states
    /// </summary>
    public class WarriorState
    {
        public string name { get; private set; }
        public Warrior warrior { get; private set; }
        public WarriorState(string name,Warrior warrior)
        {
            this.name = name;
            this.warrior = warrior;
        }
        /// <summary>
        /// create the warrior state in function of the class name and the parameters
        /// </summary>
        /// <param name="className"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
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
        /// <summary>
        /// is done at each attack
        /// </summary>
        public virtual void doEffectOnAttack()
        {

        }
        /// <summary>
        /// is reset at each attack
        /// </summary>
        public virtual void resetEffectOnAttack()
        {

        }
    }

    /// <summary>
    /// the vicious state
    /// </summary>
    class Vicious : WarriorState
    {
        int numOfBlow = 0;
        public Vicious(string name, Warrior warrior) : base(name,warrior)
        { }

        public override void doEffectOnAttack()
        {
            //increase damage of this attack and the next one
            if(numOfBlow<2)
            {
                warrior.setDamage(warrior.damage + 20);
            }
            numOfBlow++;
        }

        public override void resetEffectOnAttack()
        {
            //reset the effect
            if (numOfBlow <= 2)
            {
                warrior.setDamage(warrior.damage - 20);
            }
        }
    }

    /// <summary>
    /// the veteran state
    /// </summary>
    class Veteran : WarriorState
    {
        bool doOnce = true;
        public Veteran(string name, Warrior warrior) : base(name, warrior)
        { }
        public override void doEffectOnAttack()
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
