public class ShipShootCommand
{
    public void Execute()
    {
        ServiceLocator.Get<ShipAmmoPool>().Get();
    }
}
