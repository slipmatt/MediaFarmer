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
                PlayHistoryId=item.PlayHistoryId,
                UserName = item.User.UserName
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
                PlayHistoryId = item.PlayHistoryId
            };
        }
        public static Vote ToData(this VoteViewModel item)
        {
            if (item == null) return null;
            return new Vote
            {
                VoteId = item.VoteId,
                VoteValue = item.VoteValue,
                UserId = item.UserId,
                PlayHistoryId = item.PlayHistoryId
            };
        }
        #endregion

        #region Track
        public static TrackViewModel ToModel(this Track item)
        {
            if (item == null) return null;
            return new TrackViewModel
            {
                TrackId = item.TrackId,
                TrackName = item.TrackName,
                ArtistId = item.ArtistId,
                AlbumId = item.AlbumId,
                TrackURL=item.TrackURL
            };
        }
        public static Track ToData(this TrackViewModel item)
        {
            if (item == null) return null;
            return new Track
            {
                TrackId = item.TrackId,
                TrackName = item.TrackName,
                ArtistId = item.ArtistId,
                AlbumId = item.AlbumId,
                TrackURL = item.TrackURL
            };
        }
        #endregion

        #region Track
        public static FavouriteViewModel ToModel(this Favourite item)
        {
            if (item == null) return null;
            return new FavouriteViewModel
            {
                FavouriteId = item.FavouriteId,
                UserId = item.UserId,
                TrackId = item.TrackId,
                UserName = item.User.UserName,
                TrackName = item.Track.TrackName,
            };
        }
        public static Favourite ToData(this FavouriteViewModel item)
        {
            if (item == null) return null;
            return new Favourite
            {
                FavouriteId = item.FavouriteId,
                UserId = item.UserId,
                TrackId = item.TrackId
            };
        }
        #endregion
    }
}