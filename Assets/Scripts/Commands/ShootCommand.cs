public class ShootCommand
{
    public void Execute()
    {
        ServiceLocator.Get<ObjectPool>().GetAmmo();
    }
}
