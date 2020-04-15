namespace DTWorld.Interfaces
{
    public interface IHealth
    {
        float Health { get; set; }
        void TakeDamage(float damage);
        void SetHealth(float health);
    }
}