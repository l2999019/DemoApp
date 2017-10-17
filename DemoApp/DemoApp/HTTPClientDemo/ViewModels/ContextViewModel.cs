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
        public ContextDataStore DataStore =new ContextDataStore();
        public ObservableCollection<ContextModel> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
      

        private int page = 1;
        private int rows = 10;

        public  ContextViewModel()
        {
            Items = new ObservableCollection<ContextModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            //DeleteItemCommand = new Command<int>(async (key) => await DeleteItem(key));
            MessagingCenter.Subscribe<ContextModelPage, ContextModel>(this, "AddItem", async (obj, item) =>
            {

                var _item = item as ContextModel;
                var date =  await DataStore.AddItemAsync(_item);
                
                if (date)
                {
                    LoadDate();
                    // Items.Add(_item);
                    // OnPropertyChanged("Items");
                    await obj.DisplayAlert("提示", "添加成功!", "关闭");
                    await obj.Navigation.PopAsync();
                }
                else
                {
                    await obj.DisplayAlert("提示", "添加失败!", "关闭");
                }
               
            });


            MessagingCenter.Subscribe<ContextModelPage, ContextModel>(this, "UpdateItem", async (obj, item) =>
            {

               // var _item = item as ContextModel;
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
