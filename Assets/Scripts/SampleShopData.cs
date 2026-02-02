using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SampleShopData : MonoBehaviour
{
    [SerializeField]
    private List<int> initialUnlockedShopItemIndeces = new List<int> { 0, 1 };

    [SerializeField]
    public List<ShopOption> AllShopOptions = new List<ShopOption>();

    public int Money = 0;
    public List<ShopOption> UnlockedOptions = new List<ShopOption>();

    public UnityEvent OnShopDataChanged { get; set; } = new UnityEvent();

    private void Start()
    {
        Restart();
    }

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

    public void Restart()
    {
        UnlockedOptions.Clear();
        foreach (var index in initialUnlockedShopItemIndeces)
        {
            UnlockedOptions.Add(AllShopOptions[index]);
        }

        OnShopDataChanged.Invoke();
    }
}
