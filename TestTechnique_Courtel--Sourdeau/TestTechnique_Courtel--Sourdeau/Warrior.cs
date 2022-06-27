using System;

namespace ConsoleApp1
{
    public class Warrior
    {
        public int HP { get; protected set; }
        public int damage { get; protected set; }
        public bool isAlive { get; private set; } = true;
        public Warrior(string String="")
        {

        }

        public void Engage(Warrior opponent)
        {
            while(this.isAlive && opponent.isAlive)
            {
                doDamage(opponent);
                opponent.doDamage(this);
            }
        }

        public virtual Warrior Equip(string objectToEquip)
        {
            return this;
        }

        private void doDamage(Warrior opponent)
        {
            opponent.receivedDamage(opponent, damage);
        }

        public void receivedDamage(Warrior opponent,int damage)
        {
            this.HP -= damage;
            if(HitPoints()<=0)
            {
                this.HP = 0;
                isAlive = false;
            }
        }

        public int HitPoints()
        {
            return this.HP;
        }
    }
}
