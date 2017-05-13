using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Sample.Common;

namespace Xamarin.Sample
{
    public partial class MainPage : ContentPage
    {
        private Timer _timer;
        private int _counter;

        public MainPage()
        {
            InitializeComponent();
          
        }

        void InitCyclicCounter()
        {
            //TimerCallback timerDelegate = new TimerCallback(IncrementCounter);

            //_timer = new Timer(timerDelegate, null, 1000, 1000);
        }

        void IncrementCounter()
        {
            _counter++;
            labelCounter.Text = _counter.ToString();
        }

        void ShowAd(object sender, EventArgs e)
        {
           var adMobService = DependencyService.Get<IAdService>();
            adMobService.ShowInterstital();
        }
    }
}
