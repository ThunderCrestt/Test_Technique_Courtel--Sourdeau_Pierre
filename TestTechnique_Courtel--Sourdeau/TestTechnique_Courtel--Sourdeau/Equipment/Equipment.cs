using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Equipment
    {
        //the name of the equipment
        public string name { get; private set; }
        //the owner of the equipment
        protected Warrior owner;
        //if the equipment is active
        protected bool isActive = true;
        public Equipment(string name,Warrior owner)
        {
            this.name = name;
            this.owner = owner;
        }
        public static Equipment createObject(string className, object[] parameters)
        {
            //Create the object in function of the string
                var instance = Activator.CreateInstance(Type.GetType(className), parameters);
                return (Equipment)instance;
        }

        public virtual void onEquip() {}

        public virtual void doEffect() { }

        public virtual void resetEffect() {}
    }

  



}
