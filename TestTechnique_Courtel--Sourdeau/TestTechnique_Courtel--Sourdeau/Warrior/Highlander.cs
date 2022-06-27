using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Highlander : Warrior
    {
        public Highlander(string stateString = "") : base(stateString)
        {
            //base hitpoint and damage
            this.HP = 150;
            this.maxHP = this.HP;
            this.Equip("greatSword");
        }
        
        public override Highlander Equip(string objectToEquip)
        {
            base.Equip(objectToEquip);
            return this;

        }
        
    }
}
