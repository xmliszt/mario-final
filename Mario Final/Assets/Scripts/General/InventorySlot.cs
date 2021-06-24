using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    private MushroomBooster _booster;

    public bool IsEmpty()
    {
        return icon.sprite == null;
    }

    public void AddItem(MushroomBooster booster)
    {
        _booster = booster;
        icon.sprite = booster.boosterImage;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        _booster = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
