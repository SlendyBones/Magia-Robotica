using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public bool empty;
    public Sprite icon;
    Sprite background;
    public Transform slotIconGameObject;

    private void Start()
    {
        slotIconGameObject = transform.GetChild(0);
        background = slotIconGameObject.GetComponent<Image>().sprite;
    }
    public void UpdateSlot()
    {
        slotIconGameObject.GetComponent<Image>().sprite = icon;
    }
    public void CleanSlot()
    {
        item = null;
        ID = 0;
        type = null;
        description = null;
        icon = background;
        empty = true;
        UpdateSlot();

    }

}
