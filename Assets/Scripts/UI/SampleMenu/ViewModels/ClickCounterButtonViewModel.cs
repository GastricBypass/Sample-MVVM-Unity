public class ClickCounterButtonViewModel : ButtonViewModel<SampleMenuModel>
{
    protected override bool IsEnabled()
    {
        return !Model.HasLost;
    }

    protected override void OnClick()
    {
        Model.IncrementClickCount();
    }
}
