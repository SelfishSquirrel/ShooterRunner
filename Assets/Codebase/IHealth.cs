namespace Codebase
{
    public interface IHealth
    {
        float CurrentHealth { get; set; }
        float MaxHealth { get; set; }
        void ApplyDamage(float health);
    }
}