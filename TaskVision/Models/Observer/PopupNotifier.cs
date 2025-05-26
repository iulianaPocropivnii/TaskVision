using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Observer
{
    public class PopupNotifier : IObserver
    {
        public async void Update(string message)
        {
            await App.Current.MainPage.DisplayAlert("Notificare Task", message, "OK");
        }
    }
}
