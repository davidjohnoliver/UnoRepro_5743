using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public TestViewModel ViewModel { get; }

        public MainPage()
        {
            this.InitializeComponent();

            DataContext = ViewModel = new TestViewModel();

            var comboValues = new ObservableCollection<TestComboValue>(new[]
            {
                new TestComboValue { Label = "Test1" },
                new TestComboValue { Label = "Test2" },
            });
            ViewModel.Items.Add(new TestViewModelItem() { SelectedValue = comboValues[0], Values = comboValues });
            ViewModel.Items.Add(new TestViewModelItem() { SelectedValue = comboValues[1], Values = comboValues });
        }
    }

    public class TestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<TestViewModelItem> Items { get; } = new ObservableCollection<TestViewModelItem>();
        //public ObservableCollection<TestViewModelGroup> Groups { get; } = new ObservableCollection<TestViewModelGroup>();
    }

    //public class TestViewModelGroup : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    public string Label { get; set; }

    //    public ObservableCollection<TestViewModelItem> Items { get; } = new ObservableCollection<TestViewModelItem>();
    //}

    public class TestViewModelItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Label { get; set; }

        public TestComboValue SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                if (_selectedValue != value)
                {
                    System.Console.WriteLine($"TestViewModelItem.SelectedValue set: {value?.Label}");
                    _selectedValue = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedValue)));
                }
            }
        }
        TestComboValue _selectedValue;

        public ObservableCollection<TestComboValue> Values { get; set; }
    }

    public class TestComboValue : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Label { get; set; }
    }
}