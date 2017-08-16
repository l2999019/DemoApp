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
    public partial class ViewsDomePage : ContentPage
    {
        public ViewsDomePage()
        {
            InitializeComponent();
            Loading.IsEnabled = true;
            Loading.IsRunning = true;
            Loading.Color = Color.Green;
            Pickeritem.Items.Add("选项1");
            Pickeritem.Items.Add("选项2");
            Pickeritem.Items.Add("选项3");
            Pickeritem.Items.Add("选项4");
            Pickeritem.Items.Add("选项5");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("提示", "按钮点击", "关闭");
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            DisplayAlert("提示", "这里是搜索事件", "关闭");
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private void Switch_Toggled_1(object sender, ToggledEventArgs e)
        {

        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }
    }
}