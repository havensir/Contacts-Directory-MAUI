using Microsoft.Maui.ApplicationModel.Communication;

namespace havensir_M6ContactsDirectory;

public partial class ContactDetailsPage : ContentPage
{
    public ContactDetailsPage(Contact item)
    {
        InitializeComponent();

        contactImage.Source = ImageSource.FromFile(item.ImageName);
        contactName.Text = item.Name;
        contactPhone.Text = $"Phone\n{item.PhoneNumber}";
        contactEmail.Text = $"Email\n{item.Email}";
        
        contactDescription.Text = item.Description;
    }
}
