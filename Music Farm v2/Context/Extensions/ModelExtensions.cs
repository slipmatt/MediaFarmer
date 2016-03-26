using Music_Farm_v2.ViewModels;
using Music_Farm_v2.Context.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicFarmer.Data;

namespace Music_Farm_v2.Context.Extensions
{
    public static class ModelExtensions
    {
        #region Album
        public static AlbumViewModel ToModel(this Album item)
        {
            if (item == null) return null;
            return new AlbumViewModel
            {
                AlbumId = item.AlbumId,
                AlbumName = item.AlbumName
            };
        }
        public static Album ToData(this AlbumViewModel item)
        {
            if (item == null) return null;
            return new Album
            {
                AlbumId = item.AlbumId,
                AlbumName = item.AlbumName
            };
        }
        #endregion

        #region Artist
        public static ArtistViewModel ToModel(this Artist item)
        {
            if (item == null) return null;
            return new ArtistViewModel
            {
                ArtistId = item.ArtistId,
                ArtistName = item.ArtistName
            };
        }
        public static Artist ToData(this ArtistViewModel item)
        {
            if (item == null) return null;
            return new Artist
            {
                ArtistId = item.ArtistId,
                ArtistName = item.ArtistName
            };
        }
        #endregion

        #region Comment
        public static CommentViewModel ToModel(this Comment item)
        {
            if (item == null) return null;
            return new CommentViewModel
            {
                CommentId = item.CommentId,
                CommentText = item.CommentText,
                UserId = item.UserId,
                PlayHistoryId=item.PlayHistoryId
            };
        }
        public static Comment ToData(this CommentViewModel item)
        {
            if (item == null) return null;
            return new Comment
            {
                CommentId = item.CommentId,
                CommentText = item.CommentText,
                UserId = item.UserId,
                PlayHistoryId = item.PlayHistoryId
            };
        }
        #endregion

        #region Playhistory
        public static PlayHistoryViewModel ToModel(this PlayHistory item)
        {
            if (item == null) return null;
            return new PlayHistoryViewModel
            {
                PlayHistoryId = item.PlayHistoryId,
                TrackId = item.TrackId,
                UserId = item.UserId,
                TimePlayed = item.TimePlayed,
                UserName = item.User.UserName,
                TrackName = item.Track.TrackName,
                PlayCompleted=item.PlayCompleted
              //  AlbumName = item.Track.Album.AlbumName
            };
        }
        public static PlayHistory ToData(this PlayHistoryViewModel item)
        {
            if (item == null) return null;
            return new PlayHistory
            {
                PlayHistoryId = item.PlayHistoryId,
                TrackId = item.TrackId,
                UserId = item.UserId,
                TimePlayed = item.TimePlayed,
                PlayCompleted = item.PlayCompleted
            };
        }
        #endregion

        #region User
        public static UserViewModel ToModel(this User item)
        {
            if (item == null) return null;
            return new UserViewModel
            {
                UserId = item.UserId,
                UserName = item.UserName,
                Active = item.Active
            };
        }
        public static User ToData(this UserViewModel item)
        {
            if (item == null) return null;
            return new User
            {
                UserId = item.UserId,
                UserName = item.UserName,
                Active = item.Active
            };
        }
        #endregion

        #region Vote
        public static VoteViewModel ToModel(this Vote item)
        {
            if (item == null) return null;
            return new VoteViewModel
            {
                VoteId = item.VoteId,
                VoteValue = item.VoteValue,
                UserId = item.UserId,
                PlayHistoryId = item.PlayhistoryId
            };
        }
        public static Vote ToData(this VoteViewModel item)
        {
            if (item == null) return null;
            return new Vote
            {
                VoteId = item.VoteId,
                VoteValue = item.VoteValue,
                UserId = item.UserId
            };
        }
        #endregion

        //#region Track
        //public static TrackViewModel ToModel(this track item)
        //{
        //    if (item == null) return null;
        //    return new TrackViewModel
        //    {
        //        track_id = item.track_id,
        //        track_name = item.track_name,
        //        artist_id = item.artist_id,
        //        album_id = item.album_id
        //    };
        //}
        //public static track ToData(this TrackViewModel item)
        //{
        //    if (item == null) return null;
        //    return new track
        //    {
        //        track_id = item.track_id,
        //        track_name = item.track_name,
        //        artist_id = item.artist_id,
        //        album_id = item.album_id
        //    };
        //}
        //#endregion
    }
}