using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp.MasterDetailPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageTestMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageTestMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageTestMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageTestMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageTestMenuItem> MenuItems { get; set; }

            public MasterDetailPageTestMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageTestMenuItem>(new[]
                {
                    new MasterDetailPageTestMenuItem { Id = 0, Title = "Page 1" },
                    new MasterDetailPageTestMenuItem { Id = 1, Title = "Page 2" },
                    new MasterDetailPageTestMenuItem { Id = 2, Title = "Page 3" },
                    new MasterDetailPageTestMenuItem { Id = 3, Title = "Page 4" },
                    new MasterDetailPageTestMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}