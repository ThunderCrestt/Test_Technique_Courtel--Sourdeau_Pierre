using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Viking : Warrior
    {
        public Viking(string String="")
        {
            //base hitpoint and damage
            this.HP = 120;
            this.damage = 6;
        }

        public override Viking Equip(string objectToEquip)
        {
            return this;
        }
    }
}
