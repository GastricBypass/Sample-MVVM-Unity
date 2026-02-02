public class ShowWhenGameLostViewModel : HideableViewModel<SampleMenuModel>
{
    protected override bool IsVisible()
    {
        return Model.HasLost;
    }
}
