using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// the mother class of all weapons
    /// </summary>
    class Weapon : Equipment
    {
        protected Warrior opponent;
        public int damage = 0;
        public Weapon(string name, Warrior owner) : base(name, owner)
        {
            this.opponent = owner.opponent;
        }

        /// <summary>
        /// when a weapon is equipped, it changes the damage that the warrior can deal, so the weapons must be equiped first
        /// </summary>
        public override void onEquip()
        {
            if(owner.equipments.Find(equip => equip.name =="armor")!=null)
            {
                owner.setDamage(damage-1);

            } else
            {
                owner.setDamage(damage);
            }
        }

        public override void doEffect()
        {
            //the opponent receivedDamage in function of the owner Damage
            owner.opponent.receivedDamage(owner.damage);
        }
    }

    /// <summary>
    /// the axe class
    /// </summary>
    class axe : Weapon
    {
        public axe(string name, Warrior owner) : base(name, owner)
        {
            //the damage of the axe
            this.damage = 6;
        }
        public override void doEffect()
        {
            //find armor and increment damage of the buckler, if it has been hitten 3times, destroy it
            buckler buck = ((buckler)owner.opponent.equipments.Find(equip => equip.name == "buckler"));
            buck?.takeDamageByAxe();
            //the opponent receivedDamage in function of the owner Damage
            base.doEffect();
        }


    }

    /// <summary>
    /// the sword class
    /// </summary>
    class sword : Weapon
    {
        public sword(string name, Warrior owner) : base(name, owner)
        {
            //the damage of the sword
            this.damage = 5;
        }

    }

    /// <summary>
    /// the greatSword class
    /// </summary>
    class greatSword : Weapon
    {
        private int numberOfAttacks = 1;
        public greatSword(string name, Warrior owner) : base(name, owner)
        {
            //the damage of the greatSword
            this.damage = 12;
        }

        public override void doEffect()
        {
            //can only attack 2/3 of a time
            if(this.numberOfAttacks%3!=0)
            {
                base.doEffect();
            }
            numberOfAttacks++;
        }

    }
}
