using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftRecipe
{
    public int[] requiredItems;
    public int itemToCraft;

    public CraftRecipe(int itemToCraft1, int [] requiredItems1)
    {
        this.requiredItems = requiredItems1;
        this.itemToCraft = itemToCraft1;
    }
}
