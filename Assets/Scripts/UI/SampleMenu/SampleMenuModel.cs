using System.Collections.Generic;
using UnityEngine;

public class SampleMenuModel : Model
{
    [SerializeField]
    private SampleShopData shopData;

    private GameplayService gameplayService;

    #region Properties

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

    public int TargetCount
    {
        get
        {
            return gameplayService.TargetNumber;
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

    #endregion

    public void IncrementClickCount()
    {
        ClickCount += IncrementAmountPerClick;
    }

    public void Reset()
    {
        ClickCount = 0;
    }

    private void Awake()
    {
        gameplayService = new GameplayService(this, shopData);
        shopData.OnShopDataChanged.AddListener(SetIncrementOptions);
    }

    private void Start()
    {
        SetIncrementOptions();
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
