public class SampleMenuModel : Model
{
    #region Properties

    private int _clickCount = 0;
    public int ClickCount
    {
        get
        {
            return _clickCount;
        }
        set
        {
            _clickCount = value;
            Refresh();
        }
    }

    private int _incrementAmountPerClick = 1;
    public int IncrementAmountPerClick
    {
        get 
        {
            return _incrementAmountPerClick;
        }
        set
        {
            _incrementAmountPerClick = value;
            Refresh();
        }
    }

    #endregion

    public void IncrementClickCount()
    {
        ClickCount += IncrementAmountPerClick;
    }

    public void Reset()
    {
        ClickCount = 0;
    }
}
