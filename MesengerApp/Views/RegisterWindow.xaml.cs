using System.Windows.Controls;

namespace MesengerApp.Views;
public partial class RegisterWindow : UserControl
{
    public RegisterWindow()
    {
        InitializeComponent();
    }

    private void Reset_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        this.textBoxAddress.Text = string.Empty;
        this.textBoxEmail.Text = string.Empty;
        this.textBoxFirstName.Text = string.Empty;
        this.textBoxLastName.Text = string.Empty;
        this.passwordBox1.Password = string.Empty;
        this.passwordBoxConfirm.Password = string.Empty;
    }
}

