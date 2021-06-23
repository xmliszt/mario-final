using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public BoolVar inventoryFull;

    public GameConstants constants;

    private Queue<MushroomBooster> boosterList = new Queue<MushroomBooster>();

    public void AddBooster(MushroomBooster booster)
    {
        if (boosterList.Count < constants.capacity)
        {
            boosterList.Enqueue (booster);
        }
        if (boosterList.Count == constants.capacity)
        {
            inventoryFull.Set(true);
        }
    }

    public void UseBooster()
    {
        if (boosterList.Count > 0)
        {
            MushroomBooster booster = boosterList.Dequeue();
            booster.boosterEvent.Raise();
        }
        if (boosterList.Count < constants.capacity)
        {
            inventoryFull.Set(false);
        }
    }
}
