using DemoApp.HTTPClientDemo.Model;
using DemoApp.HTTPClientDemo.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoApp.HTTPClientDemo.ViewModels
{
    public class ContextViewModel: INotifyPropertyChanged
    {
        //初始化仓储
        public ContextDataStore DataStore =new ContextDataStore();

        //设置绑定对象
        public ObservableCollection<ContextModel> Items { get; set; }
        //设置刷新命令
        public Command LoadItemsCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
      

        private int page = 1;
        private int rows = 10;

        /// <summary>
        /// 初始化各种数据与监听
        /// </summary>
        public  ContextViewModel()
        {
            Items = new ObservableCollection<ContextModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //监听添加的消息
            MessagingCenter.Subscribe<ContextModelPage, ContextModel>(this, "AddItem", async (obj, item) =>
            {

                var _item = item as ContextModel;
                var date =  await DataStore.AddItemAsync(_item);
                
                if (date)
                {
                    LoadDate();
                    await obj.DisplayAlert("提示", "添加成功!", "关闭");
                    await obj.Navigation.PopAsync();
                }
                else
                {
                    await obj.DisplayAlert("提示", "添加失败!", "关闭");
                }
               
            });

            //监听更新的消息
            MessagingCenter.Subscribe<ContextModelPage, ContextModel>(this, "UpdateItem", async (obj, item) =>
            {

                var date = await DataStore.UpdateItemAsync(item);

                if (date)
                {
                    LoadDate();
                    await obj.DisplayAlert("提示", "修改成功!", "关闭");
                    await obj.Navigation.PopAsync();
                }
                else
                {
                    await obj.DisplayAlert("提示", "修改失败!", "关闭");
                }

            });
            ExecuteLoadItemsCommand();
        }


        /// <summary>
        /// 删除的方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteItem(int id)
        {
            var date = await DataStore.DeleteItemAsync(id);
            if (date)
            {
                var item = Items.Where(a => a.ID == id).FirstOrDefault();
                Items.Remove(item);
                OnPropertyChanged("Items");
            }
            return date;
        }

        /// <summary>
        /// 加载数据的命令
        /// </summary>
        /// <returns></returns>
        async Task ExecuteLoadItemsCommand()
        {
          
            try
            {
                //Items.Clear();
                var items = await DataStore.GetItemsAsync(page,rows);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
                OnPropertyChanged("Items");
                page++;
            }
            catch (Exception ex)
            {
               
            }
        }

        /// <summary>
        /// 重新刷新数据
        /// </summary>
        private async void LoadDate()
        {
            Items.Clear();
            page = 1;
            var items = await DataStore.GetItemsAsync(page, rows);
            foreach (var item in items)
            {
                Items.Add(item);
            }
            OnPropertyChanged("Items");
            page++;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
