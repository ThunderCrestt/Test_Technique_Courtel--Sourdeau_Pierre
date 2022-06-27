using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Equipment
    {
        public string name { get; private set; }
        protected Warrior owner;
        protected bool isActive = true;
        public Equipment(string name,Warrior owner)
        {
            this.name = name;
            this.owner = owner;
        }
        public static Equipment createObject(string className, object[] parameters)
        {
                var instance = Activator.CreateInstance(Type.GetType(className), parameters);
                return (Equipment)instance;
        }

        public virtual void enter() {}

        public virtual void doEffect() { }

        public virtual void resetEffect() {}
    }

    class Armour : Equipment
    {
        public Armour(string name, Warrior owner) : base(name, owner) {}
    }

    class Weapon : Equipment
    {
        protected Warrior opponent;
        public int damage=0;
        public Weapon(string name, Warrior owner) : base(name, owner)
        {
            this.opponent = owner.opponent;
        }
    }

    class buckler : Armour
    {
        public int numBlowByAxe = 0;
        int numBlow = 0;
        public buckler(string name,Warrior owner) : base(name,owner) {}

        public override void doEffect()
        {
            //évite les domages 1 fois sur deux est détruit après 3 coups de haches
            if(isActive && numBlow%2==0)
            {
                Console.WriteLine(numBlow);
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
            numBlowByAxe++;
            if(numBlowByAxe==3)
            {
                Console.WriteLine("destroy");
                isActive = false;
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
            //réduit les dommages reçu de 3 mais inflige 1 dégat de moins
        }

        public override void enter()
        {
            owner.setDamage(owner.damage - 1);
            owner.setResistance(3);
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
        }

        public override void enter()
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
        public override void doEffect()
        {
        }

        public override void enter()
        {
            owner.setDamage(damage);
        }
    }

    class greatSword : Weapon
    {
        public greatSword(string name, Warrior owner) : base(name, owner)
        {
            this.damage = 12;
        }
        public override void doEffect()
        {
        }

        public override void enter()
        {
            owner.setDamage(damage);
        }

    }


}
