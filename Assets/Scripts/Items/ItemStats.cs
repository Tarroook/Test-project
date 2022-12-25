using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStats
{
    public int id;
    public string title;
    public string description;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    // v^ don't have to match
    public ItemStats(int id1, string title1, string description1, Dictionary<string, int> stats1)
    {
        this.id = id1;
        this.title = title1;
        this.description = description1;
        this.stats = stats1;
    }

    public ItemStats(ItemStats item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.stats = item.stats;
    }
}
