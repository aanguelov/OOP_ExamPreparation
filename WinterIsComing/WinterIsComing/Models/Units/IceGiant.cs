using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
     public class IceGiant : Unit
    {
         private const int DefaultIceGiantAttackPoints = 150;
         private const int DefaultIceGiantHealthPoints = 300;
         private const int DefaultIceGiantDefensePoints = 60;
         private const int DefaultIceGiantEnergyPoints = 50;
         private const int DefaultIceGiantRange = 1;

         public IceGiant(UnitType unitType, string name, int x, int y) 
             : base(unitType, name, x, y, DefaultIceGiantRange, DefaultIceGiantAttackPoints,
                    DefaultIceGiantHealthPoints, DefaultIceGiantDefensePoints, DefaultIceGiantEnergyPoints)
         {
             this.CombatHandler = new IceGiantCombatHandler(this);
         }
    }
}
