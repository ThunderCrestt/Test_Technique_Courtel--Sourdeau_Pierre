using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    public class Warrior
    {
        //The maxHP of the warrior, default 100
        public int maxHP = 100;
        //the current HP of the warrior
        public int HP { get; protected set; } = 100;
        //the damage that the warrior deals to his opponent, is based on the weapon type and the armor, but also the state of the warrior
        public int damage { get; protected set; }
        //a bool to inform if this warrior is still alive
        public bool isAlive { get; private set; } = true;
        //the resistance of the warrior, is based on his armor
        public int resistance { get; protected set; } = 0;
        //the opponent of the warriors
        public Warrior opponent { get; protected set; }

        //all the equipments of the warrior
        public List<Equipment> equipments = new List<Equipment>();

        //if the warrior ignore the next time it is damage, useful when he is equiped of a bulcker
        protected bool ignoreNextDamage = false;

        //the current warrior state
        protected WarriorState state;
        public Warrior(string stateString="")
        {
            if(stateString!=string.Empty)
            {
                //create the warrior state in function of the stateString input
                state = WarriorState.createWarriorState("ConsoleApp1." + stateString, new Object[] { stateString, this });
            }
        }
        /// <summary>
        /// engage the opponent
        /// </summary>
        /// <param name="opponent">another warrior</param>
        public virtual void Engage(Warrior opponent)
        {
            this.opponent = opponent;
            this.opponent.opponent = this;
            while(this.isAlive && opponent.isAlive)
            {
                doDamage();
                opponent.doDamage();
            }
        }

        /// <summary>
        /// equip an object to this warrior
        /// </summary>
        /// <param name="objectToEquip">the string of the object to equi^p</param>
        /// <returns> the instance of the warrior </returns>
        public virtual Warrior Equip(string objectToEquip)
        {
            if(objectToEquip!=string.Empty)
            {
                Equipment pieceOfEquipment = Equipment.createEquipment("ConsoleApp1." + objectToEquip, new Object[] { objectToEquip, this });
                if (pieceOfEquipment != null)
                {
                    pieceOfEquipment.onEquip();
                    equipments.Add(pieceOfEquipment);
                }
            }

            return this;
        }

        /// <summary>
        /// do damage to the opponent
        /// </summary>
        public void doDamage()
        {
            //weapon effect
            state?.doEffect();
            useEquipmentInAttack();
            state?.resetEffect();
        }

        /// <summary>
        /// received damage from an opponent
        /// </summary>
        /// <param name="damage"></param>
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

        /// <summary>
        /// use the equipment a the moment of attack, so only weapons are used
        /// </summary>
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

        /// <summary>
        /// reset the advantage gave by Armour equipment
        /// </summary>
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

        /// <summary>
        /// use the Armour equipments
        /// </summary>
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

        /// <summary>
        /// return current HP
        /// </summary>
        /// <returns>current HP</returns>
        public int HitPoints()
        {
            return this.HP;
        }

        /// <summary>
        /// set the number of damage dealt by this warrior
        /// </summary>
        /// <param name="damage">the new damage of the warrior</param>
        public void setDamage(int damage)
        {
            this.damage = damage;
        }

        /// <summary>
        /// set the resistance of the warrior
        /// </summary>
        /// <param name="resistance"> the new resistance</param>
        public void setResistance(int resistance)
        {
            this.resistance = resistance;
        }

        /// <summary>
        /// effect of the bulker
        /// </summary>
        public void block()
        {
            ignoreNextDamage = true;
        }

        /// <summary>
        /// reset of the bulcker
        /// </summary>
        public void unBlock()
        {
            ignoreNextDamage = false;
        }
    }
}
