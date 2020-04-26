using System.Collections;
using DTWorld.Core.Mobiles;

namespace DTWorld.Interfaces
{
    public interface IShield
    {      
        void Defend(BaseMobile otherMobile);
        BaseMobile Mobile { get; set; }
        float DefendRate { get; set; }
        float SwingSpeed { get; set; }
    }
}