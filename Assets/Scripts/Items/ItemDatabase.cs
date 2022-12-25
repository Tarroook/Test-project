using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<ItemStats> items = new List<ItemStats>();

    private void Awake()
    {
        buildItemDatabase();
    }

    public ItemStats getItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    void buildItemDatabase()
    {
        items = new List<ItemStats>()
        {
            new ItemStats(1, "Apple", "Feeds you.",
            new Dictionary<string, int>{
               { "Heal", 10 }
            }),
            new ItemStats(2, "Poison Potion", "Drink at your own risk.",
            new Dictionary<string, int>{
               { "SelfDamage", 10 }
            })
        };
        //items[0].stats["Heal"].ToString;
    }
}
