using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject InventoryBox;
    public Player player;
    public List<Slots_UI> slots = new List<Slots_UI>();
    void Update(){

    }

    public void Start()
    {
        InventoryBox.SetActive(true);
    }

    void Setup()
{
    if (slots.Count == player.inventory.slots.Count)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (player.inventory.slots[i].type != CollectableType.NONE)
            {
                slots[i].SetItem(player.inventory.slots[i]);
            }
            else
            {
                slots[i].SetEmpty();
            }
        }
    }
}
}
