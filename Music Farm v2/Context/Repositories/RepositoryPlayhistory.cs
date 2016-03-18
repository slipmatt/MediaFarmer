using Music_Farm_v2.Context.Extensions;
using Music_Farm_v2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.Context.Repositories
{
    public class RepositoryPlayhistory
    {

        public static List<PlayhistoryViewModel> GetAllItems(bool showCompleted=false)
        {
            List<PlayhistoryViewModel> items = new List<PlayhistoryViewModel>();

                //items = GetContext().play_history
                //.Where(i => i.play_completed.Equals(showCompleted)).ToList()
                //.Select(i => i.ToModel()).ToList();
            return items;
        }
    }
}