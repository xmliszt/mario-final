using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public TMP_Text desc;

    public BoolVar inventoryFull;

    public GameConstants constants;

    public Inventory inventory;

    private List<MushroomBooster> boosters;

    private InventorySlot[] slots;

    private void Start()
    {
        slots = GetComponentsInChildren<InventorySlot>();
        boosters = inventory.GetInventory();
        desc.text = "";
    }

    public void AddBooster(MushroomBooster booster)
    {
        if (boosters.Count < constants.capacity)
        {
            boosters.Add (booster);
        }
        UpdateUI();
    }

    public void UseBooster()
    {
        desc.text = boosters[0]._name;
        boosters.RemoveAt(0);
        UpdateUI();
        StartCoroutine(RemoveDesc());
    }

    IEnumerator RemoveDesc()
    {
        yield return new WaitForSeconds(5);
        desc.text = "";
    }

    private void UpdateUI()
    {
        int i = 0;
        for (i = 0; i < boosters.Count; i++)
        {
            slots[i].AddItem(boosters[i]);
        }
        for (int j = i; j < slots.Length; j++)
        {
            slots[j].ClearSlot();
        }
    }
}
