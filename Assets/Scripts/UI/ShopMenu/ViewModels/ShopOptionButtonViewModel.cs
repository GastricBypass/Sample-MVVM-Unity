using TMPro;
using UnityEngine;

public class ShopOptionButtonViewModel : ButtonViewModel<SampleShopMenuModel>
{
    [SerializeField]
    private TMP_Text buttonText;

    public ShopOption ShopOption { get; set; }

    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        buttonText.text = ShopOption.IncrementValue + (ShopOption.IsUnlocked ? " (owned)" : string.Empty);
    }

    protected override bool IsEnabled()
    {
        return Model.CanAffordOption(ShopOption) && !ShopOption.IsUnlocked;
    }

    protected override void OnClick()
    {
        Model.UnlockShopOption(ShopOption);
    }
}
