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
        private int isUpdate = 0;
        public ContextModelPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<ListViewPage, ContextModel>(this, "GetModel", (obj, item) => {

                //DisplayAlert("提示", "传过来的参数为" + item, "确定");
                this.times.Date = item.AddTime.Value;
                this.titel.Text = item.Title;
                this.contexts.Text = item.Context;
                isUpdate = item.ID;
            });
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            if (isUpdate>0)
            {

                ContextModel model = new ContextModel();
                model.AddTime = times.Date;
                model.Context = contexts.Text;
                model.Title = titel.Text;
                model.ID = isUpdate;
                MessagingCenter.Send(this, "UpdateItem", model);

            }
            else
            {

                ContextModel model = new ContextModel();
                model.AddTime = times.Date;
                model.Context = contexts.Text;
                model.Title = titel.Text;
                MessagingCenter.Send(this, "AddItem", model);
            }
            
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<ListViewPage, ContextModel>(this, "GetModel");
            base.OnDisappearing();
        }
    }
}