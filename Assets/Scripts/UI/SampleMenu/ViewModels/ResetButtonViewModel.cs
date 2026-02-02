public class ResetButtonViewModel : ButtonViewModel<SampleMenuModel>
{
    protected override void OnClick()
    {
        Model.Reset();
    }
}
