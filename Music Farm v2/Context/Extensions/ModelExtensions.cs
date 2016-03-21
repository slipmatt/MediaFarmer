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

        //#region Comment
        //public static CommentViewModel ToModel(this comment item)
        //{
        //    if (item == null) return null;
        //    return new CommentViewModel
        //    {
        //        comment_id = item.comment_id,
        //        comment_text = item.comment_text,
        //        user_id = item.user_id
        //    };
        //}
        //public static comment ToData(this CommentViewModel item)
        //{
        //    if (item == null) return null;
        //    return new comment
        //    {
        //        comment_id = item.comment_id,
        //        comment_text = item.comment_text,
        //        user_id = item.user_id
        //    };
        //}
        //#endregion

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

        //#region User
        //public static UserViewModel ToModel(this user item)
        //{
        //    if (item == null) return null;
        //    return new UserViewModel
        //    {
        //        user_id = item.user_id,
        //        user_name = item.user_name,
        //        active = item.active
        //    };
        //}
        //public static user ToData(this UserViewModel item)
        //{
        //    if (item == null) return null;
        //    return new user
        //    {
        //        user_id = item.user_id,
        //        user_name = item.user_name,
        //        active = item.active
        //    };
        //}
        //#endregion

        //#region Vote
        //public static VoteViewModel ToModel(this vote item)
        //{
        //    if (item == null) return null;
        //    return new VoteViewModel
        //    {
        //        vote_id = item.vote_id,
        //        vote_value = item.vote_value,
        //        user_id = item.user_id
        //    };
        //}
        //public static vote ToData(this VoteViewModel item)
        //{
        //    if (item == null) return null;
        //    return new vote
        //    {
        //        vote_id = item.vote_id,
        //        vote_value = item.vote_value,
        //        user_id = item.user_id
        //    };
        //}
        //#endregion

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