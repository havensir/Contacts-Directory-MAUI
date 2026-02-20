using System.Collections.ObjectModel;
using System.Linq;

namespace havensir_M6ContactsDirectory
{
    public partial class MainPage : ContentPage
    {
        public List<Contact> contactsList = new List<Contact>()
        {
            // A Group
        new Contact { Name = "Alex Carter", ImageName = "pic1m.png", Email="alex.carter@email.com", PhoneNumber="(513) 555-0101", Description="Met through a group project. Good contact for app-related questions." },
        new Contact { Name = "Alyssa Moore", ImageName = "pic2f.png", Email="alyssa.moore@email.com", PhoneNumber="(513) 555-0102", Description="Works in event planning. Helpful to coordinate schedules and deadlines." },
        new Contact { Name = "Andrew Patel", ImageName = "pic3m.png", Email="andrew.patel@email.com", PhoneNumber="(513) 555-0103", Description="Data-focused contact. Reached out for help with analytics assignments." },

        // B Group
        new Contact { Name = "Brandon Lee", ImageName = "pic1m.png", Email="brandon.lee@email.com", PhoneNumber="(513) 555-0104", Description="Former classmate. Easy to reach for quick technical questions." },
        new Contact { Name = "Brianna Scott", ImageName = "pic2f.png", Email="brianna.scott@email.com", PhoneNumber="(513) 555-0105", Description="Design-oriented contact. Has a good eye for layouts and UI feedback." },
        new Contact { Name = "Benjamin Wright", ImageName = "pic3m.png", Email="benjamin.wright@email.com", PhoneNumber="(513) 555-0106", Description="Team member from a past project. Reliable for collaboration." },

        // C Group
        new Contact { Name = "Chris Morgan", ImageName = "pic1m.png", Email="chris.morgan@email.com", PhoneNumber="(513) 555-0107", Description="Usually available to troubleshoot issues and talk through problems." },
        new Contact { Name = "Chloe Nguyen", ImageName = "pic4f.png", Email="chloe.nguyen@email.com", PhoneNumber="(513) 555-0108", Description="Enjoys design work. Good person to ask for UI opinions." },
        new Contact { Name = "Carlos Rivera", ImageName = "pic3m.png", Email="carlos.rivera@email.com", PhoneNumber="(513) 555-0109", Description="Familiar with cloud tools. Helpful when working on deployment topics." },

        // D Group
        new Contact { Name = "Daniel Ruiz", ImageName = "pic1m.png", Email="daniel.ruiz@email.com", PhoneNumber="(513) 555-0110", Description="Easy to collaborate with and quick to respond to messages." },
        new Contact { Name = "Diana Foster", ImageName = "pic2f.png", Email="diana.foster@email.com", PhoneNumber="(513) 555-0111", Description="Detail-oriented contact. Helpful for reviewing work before submission." },
        new Contact { Name = "David Kim", ImageName = "pic3m.png", Email="david.kim@email.com", PhoneNumber="(513) 555-0112", Description="Strong with debugging. Good person to ask when something isn’t working." },

        // E Group
        new Contact { Name = "Ethan Brooks", ImageName = "pic1m.png", Email="ethan.brooks@email.com", PhoneNumber="(513) 555-0113", Description="Interested in security topics. Useful contact for related questions." },
        new Contact { Name = "Emily Turner", ImageName = "pic4f.png", Email="emily.turner@email.com", PhoneNumber="(513) 555-0114", Description="Often tests apps and points out usability issues." },
        new Contact { Name = "Eric Johnson", ImageName = "pic3m.png", Email="eric.johnson@email.com", PhoneNumber="(513) 555-0115", Description="Good general contact for coordinating group work." }

        };

        public ObservableCollection<ContactGroup> GroupedContacts { get; set; }

        public MainPage()
        {
            InitializeComponent();

            GroupedContacts = new ObservableCollection<ContactGroup>(
                contactsList
                    .GroupBy(c => c.Name[0].ToString().ToUpper())
                    .OrderBy(g => g.Key)
                    .Select(g => new ContactGroup(g.Key, g.OrderBy(c => c.Name)))
            );

            ContactsCollectionView.ItemsSource = GroupedContacts;
        }

        private void ContactsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedContact = e.CurrentSelection.FirstOrDefault() as Contact;
            if (selectedContact != null)
            {
                Navigation.PushAsync(new ContactDetailsPage(selectedContact));

                // Clear selection so that the user can select the same contact again if they want to
                ContactsCollectionView.SelectedItem = null;
            }
        }
    }
}
