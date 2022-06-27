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
    }



    class axe : Weapon
    {
        public axe(string name, Warrior owner) : base(name, owner)
        {
            this.damage = 6;
        }
        public override void doEffect()
        {
            //find armor and increment damage
            buckler buck = ((buckler)owner.opponent.equipments.Find(equip => equip.name == "buckler"));
            buck?.takeDamageByAxe();
            owner.opponent.receivedDamage(owner.damage);
        }

        public override void onEquip()
        {
            owner.setDamage(damage);
        }
    }

    class sword : Weapon
    {
        public sword(string name, Warrior owner) : base(name, owner)
        {
            this.damage = 5;
        }

        public override void onEquip()
        {
            owner.setDamage(damage);
        }

        public override void doEffect()
        {
            owner.opponent.receivedDamage(owner.damage);
        }
    }

    class greatSword : Weapon
    {
        private int numberOfAttacks = 1;
        public greatSword(string name, Warrior owner) : base(name, owner)
        {
            this.damage = 12;
        }

        public override void onEquip()
        {
            owner.setDamage(damage);
        }

        public override void doEffect()
        {
            if(this.numberOfAttacks%3!=0)
            {
                owner.opponent.receivedDamage(owner.damage);
            }
            numberOfAttacks++;
        }

    }
}
