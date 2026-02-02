using System.Collections.Generic;
using UnityEngine;

public class SampleMenuModel : Model
{
    [SerializeField]
    private SampleShopData shopData;
    [SerializeField]
    private GameplayVariables gameplayVariables;
    [SerializeField]
    private TimeRemainingTextViewModel timeRemaining;

    private GameplayService gameplayService;

    #region Properties

    public int TargetCount => gameplayService.TargetNumber;
    public float TimeRemaining => gameplayService.TimeRemaining >= 0 ? gameplayService.TimeRemaining : 0;
    public int Score => gameplayService.Score;

    public int ClickCount
    {
        get
        {
            return gameplayService.CurrentNumber;
        }
        set
        {
            gameplayService.CurrentNumber = value;
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

    private List<int> _incrementOptions = new List<int>();
    public List<int> IncremementOptions
    {
        get
        {
            return _incrementOptions;
        }
    }

    private bool _hasLost;
    public bool HasLost
    {
        get
        {
            return (_hasLost);
        }
        set
        {
            _hasLost = value;
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

    public void Restart()
    {
        gameplayService = new GameplayService(this, shopData, gameplayVariables);
        HasLost = false;
        shopData.Restart();
        IncrementAmountPerClick = 1;
    }

    private void Awake()
    {
        gameplayService = new GameplayService(this, shopData, gameplayVariables);
        shopData.OnShopDataChanged.AddListener(SetIncrementOptions);
    }

    private void Start()
    {
        SetIncrementOptions();
    }

    private void Update()
    {
        if (TimeRemaining <= 0)
        {
            HasLost = true;
        }
        else
        {
            gameplayService.TimeElapsed += Time.deltaTime;
            timeRemaining.Refresh();
        }
    }

    private void SetIncrementOptions()
    {
        _incrementOptions.Clear();
        foreach (var option in shopData.UnlockedOptions)
        {
            AddIncrementOption(option.IncrementValue);
        }

        Refresh();
    }

    private void AddIncrementOption(int newOption)
    {
        int i = 0;
        while (i < IncremementOptions.Count && IncremementOptions[i] < newOption)
        {
            i++;
        }

        IncremementOptions.Insert(i, newOption);
    }
}
