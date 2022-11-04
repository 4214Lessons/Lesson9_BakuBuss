using Microsoft.Maps.MapControl.WPF;
using System;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Threading;

namespace Source;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private BakuBus? _bakuBus;
    public BakuBus? BakuBus
    {
        get { return _bakuBus; }
        set
        {
            _bakuBus = value;
            NotifyPropertyChanged(nameof(BakuBus));
        }
    }



    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;

        string bingMapKey = "VjUUjuRrgz7UAqN9d4W6~apN7MMFQlYzNqoepweIh1g~AtILO5mMbs-QjG16NrrQ4WDsuI7U8aeUtWoDyQwQ2AJfB1mFr6NDBM9mlN9U6mlr";
        // m.CredentialsProvider = new ApplicationIdCredentialsProvider(bingMapKey);


        //System.Timers.Timer timer = new();
        //timer.Interval = 1000;
        //timer.Elapsed += Timer_Elapsed;
        //timer.Start();


        DispatcherTimer timer = new();
        timer.Interval = new TimeSpan(5000);
        timer.Tick += Timer_Tick;
        timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        // txt.Text = DateTime.Now.ToLongTimeString();
    }


    private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        //Dispatcher.Invoke(() =>
        //{
        //    txt.Text = DateTime.Now.ToLongTimeString();
        //});
    }


    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        //// From API
        //var client = new HttpClient();
        //var jsonStr = await client.GetStringAsync("https://www.bakubus.az/az/ajax/apiNew1");




        // From file
        var fileName = "bakubusApi.json";
        var dir = new DirectoryInfo("../../../");
        var path = Path.Combine(dir.FullName, fileName);
        var jsonStr = await File.ReadAllTextAsync(path);
        
        
        
        BakuBus = JsonSerializer.Deserialize<BakuBus>(jsonStr);
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    void NotifyPropertyChanged(string propertyName)
     => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


}