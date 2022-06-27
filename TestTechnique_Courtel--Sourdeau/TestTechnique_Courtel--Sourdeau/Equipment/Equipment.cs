using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// the mother class of weapon and armour
    /// </summary>
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
        /// <summary>
        /// create the equipment via the className and the parameters
        /// </summary>
        /// <param name="className"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Equipment createEquipment(string className, object[] parameters)
        {
            //Create the object in function of the string
            if(className!=string.Empty)
            {
                var instance = Activator.CreateInstance(Type.GetType(className), parameters);
                return (Equipment)instance;
            } else
            {
                return null;
            }

        }

        /// <summary>
        /// executed when the object is equipped
        /// </summary>
        public virtual void onEquip() {}

        /// <summary>
        /// the effect of the object
        /// </summary>
        public virtual void doEffect() { }

        /// <summary>
        /// reset the effect of the object
        /// </summary>
        public virtual void resetEffect() {}
    }

  



}
