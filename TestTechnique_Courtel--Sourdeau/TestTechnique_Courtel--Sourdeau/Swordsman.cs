using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Swordsman : Warrior
    {
        public Swordsman(string String="")
        {
            //base hitpoint and damage
            this.HP = 100;
            this.damage = 5;
        }

        public override Warrior Equip(string objectToEquip)
        {
            return this;
        }
    }
}
