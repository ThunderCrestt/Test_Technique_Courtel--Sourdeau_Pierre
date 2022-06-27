using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Swordsman : Warrior
    {
        public Swordsman(string stateString = "") : base(stateString)
        {
            //base hitpoint and damage
            this.HP = 100;
            this.maxHP = this.HP;
            this.Equip("sword");
        }

        
        public override Swordsman Equip(string objectToEquip)
        {
            base.Equip(objectToEquip);
            return this;
        }
        
    }
}
