using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
    [SerializeField] public int slotID;
    [SerializeField] public Inventory inventory;

    [SerializeField] public Image itemIcon;
    [SerializeField] public TextMeshProUGUI quantityText;
    [SerializeField] private GameObject highlight;

    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = Color.white;
            quantityText.text = slot.count.ToString();
        }
        else
        {
            SetEmpty();
        }
    }

    public void SetEmpty()
    {
        itemIcon.sprite = null;
        itemIcon.color = Color.clear;
        quantityText.text = "";
    }

    public void SetHighlight(bool isSelected)
    {
        highlight.SetActive(isSelected);
    }
}
