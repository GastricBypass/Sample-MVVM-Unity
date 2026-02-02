public class ClickCounterButtonViewModel : ButtonViewModel<SampleMenuModel>
{
    protected override void OnClick()
    {
        Model.IncrementClickCount();
    }
}
