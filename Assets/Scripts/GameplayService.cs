using UnityEngine;

public class GameplayService
{
    private SampleMenuModel menuModel;
    private SampleShopData shopData;
    private GameplayVariables gameplayVariables;

    private float timeLimit;

    public GameplayService(SampleMenuModel model, SampleShopData data, GameplayVariables variables)
    {
        menuModel = model;
        shopData = data;
        gameplayVariables = variables;
        timeLimit = gameplayVariables.InitialTimeLimit;
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

    public float TimeRemaining => timeLimit - TimeElapsed;
    public float TimeElapsed { get; set; }

    public int Score { get; private set; }

    private void SetTargetNumber()
    {
        TargetNumber = Random.Range(1, 256); // returns 1 to 255
    }

    public void CheckCompletionAndComplete()
    {
        if (CurrentNumber == TargetNumber)
        {
            SetTargetNumber();
            TimeElapsed = 0;
            Score++;
            timeLimit = GetNextTimeLimit();
            menuModel.Reset();
            shopData.AddMoney(1);
        }
    }

    private float GetNextTimeLimit()
    {
        return gameplayVariables.InitialTimeLimit / (1 + (Score * gameplayVariables.Difficulty));
    }
}
