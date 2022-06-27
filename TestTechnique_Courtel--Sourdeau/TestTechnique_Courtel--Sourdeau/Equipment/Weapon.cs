using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Weapon : Equipment
    {
        protected Warrior opponent;
        public int damage = 0;
        public Weapon(string name, Warrior owner) : base(name, owner)
        {
            this.opponent = owner.opponent;
        }
        public override void onEquip()
        {
            owner.setDamage(damage);
        }

        public override void doEffect()
        {
            //the opponent receivedDamage in function of the owner Damage
            owner.opponent.receivedDamage(owner.damage);
        }
    }


    class axe : Weapon
    {
        public axe(string name, Warrior owner) : base(name, owner)
        {
            //the damage of the axe
            this.damage = 6;
        }
        public override void doEffect()
        {
            //find armor and increment damage of the bulck, if it has been hitten 3times, destroy it
            buckler buck = ((buckler)owner.opponent.equipments.Find(equip => equip.name == "buckler"));
            buck?.takeDamageByAxe();
            //the opponent receivedDamage in function of the owner Damage
            base.doEffect();
        }


    }

    class sword : Weapon
    {
        public sword(string name, Warrior owner) : base(name, owner)
        {
            //the damage of the sword
            this.damage = 5;
        }

    }

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
