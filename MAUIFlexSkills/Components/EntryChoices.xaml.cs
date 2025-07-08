using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MAUIFlexSkills.Components;

public partial class EntryChoices : ContentView, INotifyPropertyChanged
{
    public EntryChoices()
	{
		InitializeComponent();
	}

    // Step 1: Define the BindableProperty
    public static readonly BindableProperty ItemsProperty =
        BindableProperty.Create(
            propertyName: nameof(Items),                            // Property name
            returnType: typeof(ObservableCollection<string>),       // Property type
            declaringType: typeof(EntryChoices),                    // Declaring type
            defaultValue: new ObservableCollection<string>(),       // Default value
            propertyChanged: OnItemsChanged,                        // Optional: PropertyChanged callback
            defaultBindingMode: BindingMode.TwoWay
        );

    // Step 2: Create the CLR property wrapper
    public ObservableCollection<string> Items
    {
        get => (ObservableCollection<string>)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    // Step 3: (Optional) Handle property changes
    private static void OnItemsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is EntryChoices customView)
        {
            // Handle the property change logic here
            customView.OnItemsUpdated((ObservableCollection<string>)newValue);
        }
    }

    private void OnItemsUpdated(ObservableCollection<string> newValue)
    {
        // Example: Update UI or perform actions based on the new value
        Console.WriteLine($"Items updated to: {string.Join(',', newValue)}");
    }

    private void OnDeleteSkillClicked(object sender, TappedEventArgs e)
    {
        string skill = (sender as Image).BindingContext as string;
        if (!string.IsNullOrEmpty(skill))
        {
            Items.Remove(skill);
        }
    }

    private void OnAddSkillClicked(object sender, TappedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(ItemEntry.Text))
        {
            Items.Add(ItemEntry.Text);
            ItemEntry.Text = "";
        }
    }
}