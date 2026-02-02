using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SampleShopData : MonoBehaviour
{
    public int Money = 0;
    public List<ShopOption> UnlockedOptions = new List<ShopOption>();

    public UnityEvent OnShopDataChanged { get; set; } = new UnityEvent();

    public void UnlockOption(ShopOption option)
    {
        Money -= option.Cost;
        option.IsUnlocked = true;
        UnlockedOptions.Add(option);

        OnShopDataChanged.Invoke();
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        OnShopDataChanged.Invoke();
    }
}
