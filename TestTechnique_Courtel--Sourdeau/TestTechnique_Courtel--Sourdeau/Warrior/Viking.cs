using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Viking : Warrior
    {
        public Viking(string stateString = "") : base(stateString)
        {
            //base hitpoint and equipment
            this.HP = 120;
            this.maxHP = this.HP;
            this.Equip("axe");
        }


        public override Viking Equip(string objectToEquip)
        {
            base.Equip(objectToEquip);
            return this;
        }
    }
}
