using System.Collections.Generic;

public class ClickIncrementDropdownViewModel : DropdownViewModel<SampleMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();

        if (Dropdown.options.Count == Model.IncremementOptions.Count)
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
        Model.IncrementAmountPerClick = Model.IncremementOptions[index];
    }
}
