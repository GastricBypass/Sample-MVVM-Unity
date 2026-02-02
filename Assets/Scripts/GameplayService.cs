using UnityEngine;

public class GameplayService
{
    private SampleMenuModel menuModel;
    private SampleShopData shopData;

    public GameplayService(SampleMenuModel model, SampleShopData data)
    {
        menuModel = model;
        shopData = data;
        SetTargetNumber();
    }

    public int TargetNumber { get; private set; }

    private int _currentNumber;
    public int CurrentNumber
    {
        get
        {
            return _currentNumber;
        }
        set
        {
            _currentNumber = value;
            CheckCompletionAndComplete();
        }
    }

    private void SetTargetNumber()
    {
        TargetNumber = Random.Range(1, 256); // returns 1 to 255
    }

    public void CheckCompletionAndComplete()
    {
        if (CurrentNumber == TargetNumber)
        {
            SetTargetNumber();
            menuModel.Reset();
            shopData.AddMoney(1);
        }
    }
}
