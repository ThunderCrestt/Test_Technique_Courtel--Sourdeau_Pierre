using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Armour : Equipment
    {
        public Armour(string name, Warrior owner) : base(name, owner) { }
    }

    class buckler : Armour
    {
        public int numBlowByAxe = 0;
        int numBlow = 0;
        public buckler(string name, Warrior owner) : base(name, owner) { }

        public override void doEffect()
        {
            //évite les domages 1 fois sur deux est détruit après 3 coups de haches
            if (isActive && numBlow % 2 == 0)
            {
                Console.WriteLine(owner.GetType() + numBlow.ToString());
                owner.block();
                //ignore damage
            }
            numBlow++;

        }

        public override void resetEffect()
        {
            owner.unBlock();
        }

        public void takeDamageByAxe()
        {
            if (numBlow % 2 == 1)
            {
                numBlowByAxe++;
                if (numBlowByAxe == 3)
                {
                    Console.WriteLine(owner.GetType() + " destroy");
                    this.isActive = false;
                }
            }
        }
    }


    class armor : Armour
    {
        public armor(string name, Warrior owner) : base(name, owner)
        {
        }
        public override void doEffect()
        {
            base.doEffect();
        }

        public override void onEquip()
        {
            //réduit les dommages reçu de 3 mais inflige 1 dégat de moins
            owner.setDamage(owner.damage - 1);
            owner.setResistance(3);
        }
    }
}
