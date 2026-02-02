public class MoneyTextViewModel : TextViewModel<SampleShopMenuModel>
{
    protected override string GetText()
    {
        return Model.Money.ToString();
    }
}
