using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public int ItemId;

    public int GetItemId()
    {
        return ItemId;
    }

    public void DestoryItem()
    {
        Destroy(this.gameObject);
    }

}
