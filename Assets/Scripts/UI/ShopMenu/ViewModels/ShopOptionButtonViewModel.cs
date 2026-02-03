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
        buttonText.text = ShopOption.IncrementValue + (Model.IsOptionUnlocked(ShopOption) ? " (owned)" : string.Empty);
    }

    protected override bool IsEnabled()
    {
        return Model.CanAffordOption(ShopOption) && !Model.IsOptionUnlocked(ShopOption);
    }

    protected override void OnClick()
    {
        Model.UnlockShopOption(ShopOption);
    }
}
