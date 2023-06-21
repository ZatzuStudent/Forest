using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject InventoryBox;
    public Player player;
    public List<Slots_UI> slots = new List<Slots_UI>();
    void Update(){
    if(Input.GetKeyDown(KeyCode.Tab))
    {
        ToggleInventory();
    }
    }

    public void Start()
    {
        InventoryBox.SetActive(false);
    }

    public void ToggleInventory()
    {
        if(!InventoryBox.activeSelf)
        {
            InventoryBox.SetActive(true);
            Setup();
        }
        else
        {
            InventoryBox.SetActive(false);
        }
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
