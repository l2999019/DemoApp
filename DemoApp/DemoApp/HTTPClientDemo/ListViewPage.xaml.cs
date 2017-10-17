using DemoApp.HTTPClientDemo.Model;
using DemoApp.HTTPClientDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp.HTTPClientDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        ContextViewModel viewModel;
        public ListViewPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new ContextViewModel();
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            ContextModel date = mi.CommandParameter as ContextModel;
            Navigation.PushAsync(new ContextModelPage());
            MessagingCenter.Send<ListViewPage,ContextModel>(this, "GetModel", date);
        }

        private async void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            int id = Convert.ToInt32( mi.CommandParameter);
            var date = await viewModel.DeleteItem(id);
            if (!date)
            {
              await  DisplayAlert("提示", "删除失败,请检查网络", "确定");
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContextModelPage());
        }
    }
}