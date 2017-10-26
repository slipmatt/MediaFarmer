using MediaFarmer.ViewModels;
using MediaFarmer.Context.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicFarmer.Data;

namespace MediaFarmer.Context.Extensions
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
                PlayHistoryId = item.PlayHistoryId,
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
                TrackName = item.Track != null ? item.Track.TrackName : "Unknown",
                PlayCompleted = item.PlayCompleted,
                IsPlaying = item.IsPlaying,
                Track = item.Track,
                User = item.User
                //  AlbumName = item.Track.Album.AlbumName
            };
        }

        public static PlayHistoryViewModel ToAPIModel(this PlayHistoryViewModel item)
        {
            if (item == null) return null;
            return new PlayHistoryViewModel
            {
                PlayHistoryId = item.PlayHistoryId,
                TrackId = item.TrackId,
                UserId = item.UserId,
                TimePlayed = item.TimePlayed,
                UserName = item.User.UserName,
                TrackName = item.Track != null ? item.Track.TrackName : "Unknown",
                PlayCompleted = item.PlayCompleted,
                IsPlaying = item.IsPlaying,
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
                Track = item.Track,
                User = item.User,
                PlayCompleted = item.PlayCompleted,
                IsPlaying = item.IsPlaying,
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
        public static Vote UpdateData(this Vote dbItem, VoteViewModel item)
        {
            if (item == null) return dbItem;
            dbItem.VoteValue = item.VoteValue;
            return dbItem;
        }
        public static Vote DeleteData(this Vote dbItem, VoteViewModel item)
        {
            return dbItem;
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
                TrackURL = item.TrackURL,
                PreviewURL = string.Concat("/Content\\", item.TrackURL.Substring(item.TrackURL.IndexOf("Media"))),
                AlbumName = item.Album == null ? "" : item.Album.AlbumName,
                ArtistName = item.Artist == null ? "" : item.Artist.ArtistName
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
                TrackURL = item.TrackURL,
            };
        }

        public static Track UpdateData(this Track dbItem, TrackViewModel item)
        {
            if (item == null) return dbItem;
            dbItem.TrackId = item.TrackId;
            dbItem.TrackName = item.TrackName;
            dbItem.TrackURL = item.TrackURL;
            dbItem.AlbumId = item.AlbumId;
            dbItem.ArtistId = item.ArtistId;
            return dbItem;
        }
        public static Track DeleteData(this Track dbItem, TrackViewModel item)
        {
            return dbItem;
        }
        #endregion

        #region Favourite
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

        #region JukeBox
        public static JukeBoxViewModel ToModel(this JukeBoxTracks_Result item)
        {
            if (item == null) return null;
            return new JukeBoxViewModel
            {
                TrackId = item.TrackId,
                TrackName = item.TrackName,
                Votes = item.Votes,
                Favourites = item.Favourites,
                Played = item.Played
            };
        }
        public static JukeBoxTracks_Result ToData(this JukeBoxViewModel item)
        {
            if (item == null) return null;
            return new JukeBoxTracks_Result
            {
                TrackId = item.TrackId,
                TrackName = item.TrackName,
                Votes = item.Votes,
                Favourites = item.Favourites,
                Played = item.Played
            };
        }
        #endregion

        #region Settings
        public static SettingValueViewModel ToModel(this SettingValue item)
        {
            if (item == null) return null;
            return new SettingValueViewModel
            {
                SettingId = item.SettingValueId,
                SettingName = item.SettingName,
                SettingValue = item.SettingValue1,
                DataType = item.DataType,
                Active = item.Active
            };
        }
        public static SettingValue ToData(this SettingValueViewModel item)
        {
            if (item == null) return null;
            return new SettingValue
            {
                SettingValueId = item.SettingId,
                SettingName = item.SettingName,
                SettingValue1 = item.SettingValue,
                DataType = item.DataType,
                Active = item.Active
            };
        }
        public static SettingValue UpdateData(this SettingValue dbItem, SettingValueViewModel item)
        {
            if (item == null) return dbItem;
            dbItem.SettingName = item.SettingName;
            dbItem.SettingValue1 = item.SettingValue;
            dbItem.DataType = item.DataType;
            dbItem.Active = item.Active;
            return dbItem;
        }
        public static SettingValue DeleteData(this SettingValue dbItem, SettingValueViewModel item)
        {
            return dbItem;
        }
        #endregion
    }
}