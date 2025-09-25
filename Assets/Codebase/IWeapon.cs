namespace Codebase
{
    public interface IWeapon
    {
        void Use();
        void Deactivate();
        void Activate();
        
        float FireRate { get; set; }
    }
}