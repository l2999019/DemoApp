using DemoApp.HTTPClientDemo.Model;
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
    public partial class ContextModelPage : ContentPage
    {
        public ContextModelPage()
        {
            InitializeComponent();
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            ContextModel model = new ContextModel();
            model.AddTime = times.Date;
            model.Context = contexts.Text;
            model.Title = titel.Text;
            MessagingCenter.Send(this, "AddItem", model);
            
        }
    }
}