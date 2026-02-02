public class TargetTextViewModel : TextViewModel<SampleMenuModel>
{
    protected override string GetText()
    {
        return Model.TargetCount.ToString();
    }
}
