using System.Collections.Generic;

public class ClickIncrementDropdownViewModel : DropdownViewModel<SampleMenuModel>
{
    private int incrementValue;

    protected override void OnModelChanged()
    {
        base.OnModelChanged();

        if (Dropdown.options.Count == Model.IncremementOptions.Count &&
            Model.IncrementAmountPerClick == incrementValue)
        {
            return;
        }

        var dropdownOptions = new List<TMPro.TMP_Dropdown.OptionData>();
        foreach (var option in Model.IncremementOptions)
        {
            dropdownOptions.Add(new TMPro.TMP_Dropdown.OptionData(option.ToString()));
        }

        Dropdown.ClearOptions();
        Dropdown.AddOptions(dropdownOptions);
    }

    protected override void OnDropdownChanged(int index)
    {
        incrementValue = Model.IncremementOptions[index];
        Model.IncrementAmountPerClick = incrementValue;
    }
}
