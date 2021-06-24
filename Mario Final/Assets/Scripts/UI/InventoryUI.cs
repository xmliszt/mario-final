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

    private List<string> boosterDescriptions;

    private InventorySlot[] slots;

    private void Start()
    {
        slots = GetComponentsInChildren<InventorySlot>();
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        boosters = inventory.GetInventory();
        boosterDescriptions = new List<string>();
        int i = 0;
        for (i = 0; i < boosters.Count; i++)
        {
            slots[i].AddItem(boosters[i]);
            boosterDescriptions.Add(boosters[i]._name);
        }
        for (int j = i; j < slots.Length; j++)
        {
            slots[j].ClearSlot();
        }
        if (boosterDescriptions.Count > 0)
        {
            desc.text = boosterDescriptions[0];
        }
        else
        {
            desc.text = "";
        }
    }
}
