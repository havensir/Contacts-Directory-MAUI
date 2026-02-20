using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace havensir_M6ContactsDirectory
{
    public class ContactGroup : ObservableCollection<Contact>
    {
        public string Title { get; set; }

        public ContactGroup(string title, IEnumerable<Contact> contacts) : base(contacts)
        {
            Title = title;
        }
    }
}