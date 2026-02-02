using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleShopMenuModel : Model
{
    [SerializeField]
    private List<ShopOption> allShopOptions = new List<ShopOption>();
    [SerializeField]
    private ShopOptionButtonViewModel shopOptionPrefab;
    [SerializeField]
    private VerticalLayoutGroup shopListGroup;

    public int Money => shopData.Money;

    [SerializeField]
    private SampleShopData shopData;

    public void UnlockShopOption(ShopOption option)
    {
        if (!CanAffordOption(option))
        {
            return;
        }

        shopData.UnlockOption(option);
    }

    public bool CanAffordOption(ShopOption option)
    {
        return shopData.Money >= option.Cost;
    }

    private void Awake()
    {
        shopData.OnShopDataChanged.AddListener(Refresh);
        CreateShopOptions();
    }

    private void CreateShopOptions()
    {
        foreach (var option in allShopOptions)
        {
            var optionGameObject = Instantiate(shopOptionPrefab, shopListGroup.transform);
            optionGameObject.ShopOption = option;

            if (option.IsUnlocked)
            {
                shopData.UnlockedOptions.Add(option);
            }
        }
    }
}
