public class ScoreTextViewModel : TextViewModel<SampleMenuModel>
{
    protected override string GetText()
    {
        return Model.Score.ToString();
    }
}
