using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DisplayingAlertsPages : ContentPage
	{
		public DisplayingAlertsPages ()
		{
			InitializeComponent ();
            this.lab.Text = "ssss";
            MessagingCenter.Subscribe<MainPage, string>(this, "Hello",  (obj, item) => {

                 DisplayAlert("提示", "传过来的参数为" + item, "确定");
                 this.lab.Text = item;
                lab.TextColor = Color.Red;
            });
            
        }
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<MainPage, string>(this, "Hello");
            base.OnDisappearing();
        }
        protected override void OnAppearing()
        {
           

            base.OnAppearing();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("提示", "这里是提示信息", "确定");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("请选择分享到的位置", "取消", null, "QQ空间", "微博", "微信");
            await DisplayAlert("提示", "选中了" + action, "确定");
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("请选择内容", "取消", "删除", "QQ空间", "微博", "微信");
            await DisplayAlert("提示", "选中了" + action, "确定");
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
           var date = await DisplayAlert("提示", "你确定要选择这个按钮么?", "确定","取消");
            await DisplayAlert("提示", "选中了"+date, "确定");
        }
    }
}