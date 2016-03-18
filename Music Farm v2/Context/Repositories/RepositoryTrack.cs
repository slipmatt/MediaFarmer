using Music_Farm_v2.Context.Extensions;
using Music_Farm_v2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.Context.Repositories
{
    public class RepositoryTrack
    {
        public static List<TrackViewModel> GetAllItems(bool showInactive, string filterString)
        {
            List<TrackViewModel> items = new List<TrackViewModel>();

            //if (!string.IsNullOrEmpty(filterString))
            //{
            //    items = GetContext().tracks
            //    .Where(i => i.track_name.Contains(filterString)).ToList()
            //    .Select(i => i.ToModel()).ToList();
            //}
            //else
            //{
            //    items = GetContext().tracks
            //    .Select(i => i.ToModel()).ToList();
            //}
            return items;
        }
    }
}