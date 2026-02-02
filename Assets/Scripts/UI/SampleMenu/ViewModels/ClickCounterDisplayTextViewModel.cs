public class ClickCounterDisplayTextViewModel : TextViewModel<SampleMenuModel>
{
    protected override string GetText()
    {
        return Model.ClickCount.ToString();
    }
}
