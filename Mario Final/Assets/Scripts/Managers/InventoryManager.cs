using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;

    public void AddBooster(MushroomBooster booster)
    {
        inventory.AddBooster (booster);
    }

    public void UseBooster()
    {
        inventory.UseBooster();
    }
}
