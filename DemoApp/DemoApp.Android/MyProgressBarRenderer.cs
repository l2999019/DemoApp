using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using DemoApp.MyRenderer;
using DemoApp.Droid;
using Xamarin.Forms.Platform.Android;

//表示使用 Xamarin.Forms在使用MyProgressBar的时候,用MyProgressBarRenderer渲染替换
[assembly: ExportRenderer(typeof(MyProgressBar), typeof(MyProgressBarRenderer))]
namespace DemoApp.Droid
{
    public class MyProgressBarRenderer:ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);

            Control.ScaleY = 10; //改变Y轴大小
           
            Control.SetPadding(-0, -12, 0, -12);


        }
    }
}