using UnityEngine;
using UnityEngine.UI;

public class SampleShopMenuModel : Model
{
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

    public bool IsOptionUnlocked(ShopOption option)
    {
        return shopData.UnlockedOptions.Contains(option);
    }

    private void Awake()
    {
        shopData.OnShopDataChanged.AddListener(Refresh);
        CreateShopOptions();
    }

    private void CreateShopOptions()
    {
        foreach (var option in shopData.AllShopOptions)
        {
            var optionGameObject = Instantiate(shopOptionPrefab, shopListGroup.transform);
            optionGameObject.ShopOption = option;
        }
    }
}
