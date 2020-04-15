using System.Collections;
using DTWorld.Core.Mobiles;

namespace DTWorld.Interfaces
{
    public interface IWeapon
    {
        IAttackType AttackType { get; set; }        
        void Hit(BaseMobile otherMobile);
        BaseMobile Mobile { get; set; }

        float Damage { get; set; }
        float SwingSpeed { get; set; }
    }
}