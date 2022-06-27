using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    public class Warrior
    {
        public int HP { get; protected set; }
        public int damage { get; protected set; }
        public bool isAlive { get; private set; } = true;

        public int resistance { get; protected set; } = 0;
        public Warrior opponent { get; protected set; }

        public List<Equipment> equipments = new List<Equipment>();

        protected bool ignoreNextDamage = false;

        public Warrior(string String="")
        {

        }

        public virtual void Engage(Warrior opponent)
        {
            this.opponent = opponent;
            this.opponent.opponent = this;
            while(this.isAlive && opponent.isAlive)
            {
                doDamage(opponent);
                opponent.doDamage(this);
            }
        }

        public virtual Warrior Equip(string objectToEquip)
        {
            Equipment pieceOfEquipment = Equipment.createObject("ConsoleApp1." + objectToEquip, new Object[] { objectToEquip, this });
            pieceOfEquipment.onEquip();
            equipments.Add(pieceOfEquipment);
            return this;
        }


        public void doDamage(Warrior opponent)
        {
            //weapon effect
            useEquipmentInAttack();
            Console.WriteLine(this.GetType() + " damage");
        }

        public void receivedDamage(int damage)
        {
            //armor effect
            useEquipmentInDefense();
            if (isAlive && !ignoreNextDamage && damage > resistance)
            {
                this.HP -= (damage - resistance);
                if (HitPoints() <= 0)
                {
                    this.HP = 0;
                    isAlive = false;
                }
            }
            resetEquipmentInDefense();
        }

        protected void useEquipmentInAttack()
        {
            foreach(Equipment equipment in equipments)
            {
                if (equipment is Weapon)
                {
                    equipment.doEffect();
                }
            }
        }

        protected void resetEquipmentInDefense()
        {
            foreach (Equipment equipment in equipments)
            {
                if (equipment is Armour)
                {
                    equipment.resetEffect();
                }
            }
        }

        protected void useEquipmentInDefense()
        {
            foreach (Equipment equipment in equipments)
            {
                if(equipment is Armour)
                {
                    equipment.doEffect();
                }
            }
        }

        public int HitPoints()
        {
            return this.HP;
        }

        public void setDamage(int damage)
        {
            this.damage = damage;
        }

        public void setResistance(int resistance)
        {
            this.resistance = resistance;
        }

        //effect of object 
        public void block()
        {
            ignoreNextDamage = true;
        }

        public void unBlock()
        {
            ignoreNextDamage = false;
        }
    }
}
