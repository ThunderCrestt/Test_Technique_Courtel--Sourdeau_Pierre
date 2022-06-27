using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //the mother class for all Armours
    class Armour : Equipment
    {
        public Armour(string name, Warrior owner) : base(name, owner) { }
    }

    /// <summary>
    /// the buckler class
    /// </summary>
    class buckler : Armour
    {
        public int numBlowByAxe = 0;
        int numBlow = 0;
        public buckler(string name, Warrior owner) : base(name, owner) { }

        /// <summary>
        /// the effect of the buckler
        /// </summary>
        public override void doEffect()
        {
            //avoid damage 1/2 of the time
            if (isActive && numBlow % 2 == 0)
            {
                //ignore damage
                owner.block();
            }
            numBlow++;

        }

        /// <summary>
        /// reset the effect of the buckler
        /// </summary>
        public override void resetEffect()
        {
            owner.unBlock();
        }

        /// <summary>
        /// damage the buckler, is called if the opponent has an axe
        /// </summary>
        public void takeDamageByAxe()
        {
            //the buckler take damage, an if it has been hitten 3times, set isActive to false
            if (numBlow % 2 == 1)
            {
                numBlowByAxe++;
                if (numBlowByAxe == 3)
                {
                    this.isActive = false;
                }
            }
        }
    }

    /// <summary>
    /// the armor class
    /// </summary>
    class armor : Armour
    {
        public armor(string name, Warrior owner) : base(name, owner)
        {
        }
        public override void doEffect()
        {
            base.doEffect();
        }

        /// <summary>
        /// affect the warrior when armor is equipped
        /// </summary>
        public override void onEquip()
        {
            //reduce damage dealt, and damage received
            owner.setDamage(owner.damage - 1);
            owner.setResistance(3);
        }
    }
}
