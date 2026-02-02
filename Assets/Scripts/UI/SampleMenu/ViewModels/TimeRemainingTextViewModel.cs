public class TimeRemainingTextViewModel : TextViewModel<SampleMenuModel>
{
    public void Refresh()
    {
        // Since this view model will refresh very often, we add a way to manually refresh just this view model
        // This way we don't need to refresh every view model on the model to update the time remaining
        OnModelChanged();
    }

    protected override string GetText()
    {
        return Model.TimeRemaining.ToString("0.0");
    }
}
