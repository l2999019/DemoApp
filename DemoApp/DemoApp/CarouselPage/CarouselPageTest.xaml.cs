using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp.CarouselPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarouselPageTest :Xamarin.Forms.CarouselPage
    {
        public CarouselPageTest()
        {
            
            InitializeComponent();
        }
    }
}