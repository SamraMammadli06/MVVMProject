using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace MesengerApp.ViewModels;
public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void PropertyChange<T>(out T field, T value, [CallerMemberName] string propName = "")
    {
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}

