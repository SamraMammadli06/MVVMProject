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
        this.textBoxEmail.Text = string.Empty;
        this.textBoxFirstName.Text = string.Empty;
        this.textBoxLastName.Text = string.Empty;
        this.passwordBox1.Text = string.Empty;
        this.passwordBoxConfirm.Text = string.Empty;
    }
}

