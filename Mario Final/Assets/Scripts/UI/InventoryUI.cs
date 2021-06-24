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
        boosters = inventory.GetInventory();
        UpdateUI();
        desc.text = "";
    }

    public void AddBooster(MushroomBooster booster)
    {
        UpdateUI();
    }

    public void UseBooster()
    {
        desc.text = boosterDescriptions[0];
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
    }
}
