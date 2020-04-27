using DTWorld.Core.Items.Weapons.Melee;
namespace DTWorld.Behaviours.Items.Weapons.Melee
{
    public class SwordBehaviour : BaseMeleeWeaponBehaviour
    {
        public override void Awake()
        {
            base.Awake();
            Item = new Sword("Sword", Damage, SwingSpeed);
        }

        public override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
        }
    }

}