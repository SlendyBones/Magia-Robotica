using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool _inventoryEnabled;
    public GameObject inventory;
    private int _allSlots;
    private int _enabledSlots;
    [HideInInspector]
    public GameObject[] _slot;
    public GameObject slotHolder;
    void Start()
    {
        _allSlots = slotHolder.transform.childCount;
        _slot = new GameObject[_allSlots];
        for (int i = 0; i < _allSlots; i++)
        {
            _slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if (_slot[i].GetComponent<Slot>().item == null)
            {
                _slot[i].GetComponent<Slot>().empty = true;
            }
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _inventoryEnabled = !_inventoryEnabled;
        }
        if (_inventoryEnabled)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _inventoryEnabled = false;
            inventory.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Item")
        {
            InteractionObject(target.gameObject);
        }
    }

    public void InteractionObject(GameObject interaction)
    {
        Item item = interaction.GetComponent<Item>();
        AddItem(interaction, item.ID, item.type, item.description, item.icon);
    }
    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i <_allSlots; i++)
        {
            if (_slot[i].GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;

                _slot[i].GetComponent<Slot>().item = itemObject;
                _slot[i].GetComponent<Slot>().ID = itemID;
                _slot[i].GetComponent<Slot>().type = itemType;
                _slot[i].GetComponent<Slot>().description = itemDescription;
                _slot[i].GetComponent<Slot>().icon = itemIcon;

                itemObject.transform.parent = _slot[i].transform;
                itemObject.SetActive(false);
                _slot[i].GetComponent<Slot>().UpdateSlot();

                _slot[i].GetComponent<Slot>().empty = false;
                return;
            }
        }
    }

    //Busqueda de Objetos



}
