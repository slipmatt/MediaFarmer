using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MediaFarmer.MobileDevice
{
    public partial class PlayHistoryPage : ContentPage
    {
        public PlayHistoryPage()
        {
            InitializeComponent();
        }
    }

    [ImplementPropertyChanged]
    public class PlayHistoryPageModel : FreshBasePageModel
    {

    }
}
