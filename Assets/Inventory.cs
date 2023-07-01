using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory;
    public Image[] icons;
    public Sprite fishIcon;
    public GameObject fishPrefab;
    public Sprite rockIcon;
    public GameObject rockPrefab;
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Fish")) {
            int inventoryAmount = -1;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                {
                    inventoryAmount = i;
                    break;
                }
            }
            
            if (inventoryAmount >= 0) {
                inventory[inventoryAmount] = fishPrefab;
                Destroy(collision.gameObject);
                UpdateIcons();
            }
        }
        if (collision.gameObject.CompareTag("Rock"))
        {
            int inventoryAmount = -1;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                {
                    inventoryAmount = i;
                    break;
                }
            }

            if (inventoryAmount >= 0)
            {
                inventory[inventoryAmount] = rockPrefab;
                Destroy(collision.gameObject);
                UpdateIcons();
            }
        }
    }

    void UpdateIcons()
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (inventory[i].CompareTag("Fish"))
            {
                icons[i].sprite = fishIcon;
            }
            else if(inventory[i].CompareTag("Rock"))
            {
                icons[i].sprite = rockIcon;
            }
            else
            {
                icons[i].sprite = null; // Reset the sprite if inventory slot doesn't contain a fish
            }
        }
    }
}
