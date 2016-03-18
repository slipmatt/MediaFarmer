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

        public static List<PlayHistoryViewModel> GetAllItems(bool showCompleted=false)
        {
            List<PlayHistoryViewModel> items = new List<PlayHistoryViewModel>();

                //items = GetContext().play_history
                //.Where(i => i.play_completed.Equals(showCompleted)).ToList()
                //.Select(i => i.ToModel()).ToList();
            return items;
        }
    }
}