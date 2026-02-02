public class RestartGameButtonViewModel : ButtonViewModel<SampleMenuModel>
{
    protected override void OnClick()
    {
        Model.Restart();
    }
}
