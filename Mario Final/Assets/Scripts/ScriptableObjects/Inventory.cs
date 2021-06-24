using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[
    CreateAssetMenu(
        fileName = "Inventory",
        menuName = "ScriptableObjects/Inventory",
        order = 6)
]
public class Inventory : ScriptableObject
{
   public BoolVar inventoryFull;

    public GameConstants constants;

    public List<MushroomBooster> boosterList;

    public void AddBooster(MushroomBooster booster)
    {
        if (boosterList.Count < constants.capacity)
        {
            boosterList.Add (booster);
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
            MushroomBooster booster = boosterList[0];
            boosterList.RemoveAt(0);
            booster.boosterEvent.Raise();
        }
        if (boosterList.Count < constants.capacity)
        {
            inventoryFull.Set(false);
        }
    }

    public void ClearAll()
    {
        boosterList = new List<MushroomBooster>();
    }

    public List<MushroomBooster> GetInventory()
    {
        return boosterList;
    }
}
