using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SampleShopData : MonoBehaviour
{
    [SerializeField]
    private List<int> initialUnlockedShopItemIndeces = new List<int> { 0, 1 };

    [SerializeField]
    public List<ShopOption> AllShopOptions = new List<ShopOption>();

    public int Money { get; set; } = 0;
    public List<ShopOption> UnlockedOptions { get; set; } = new List<ShopOption>();

    public UnityEvent OnShopDataChanged { get; set; } = new UnityEvent();

    private void Start()
    {
        Restart();
    }

    public void UnlockOption(ShopOption option)
    {
        Money -= option.Cost;
        UnlockedOptions.Add(option);

        OnShopDataChanged.Invoke();
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        OnShopDataChanged.Invoke();
    }

    public void Restart()
    {
        UnlockedOptions.Clear();
        foreach (var index in initialUnlockedShopItemIndeces)
        {
            UnlockedOptions.Add(AllShopOptions[index]);
        }

        Money = 0;

        OnShopDataChanged.Invoke();
    }
}
