using Music_Farm_v2.ViewModels;
using Music_Farm_v2.Context.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Music_Farm_v2.Data;

namespace Music_Farm_v2.Context.Extensions
{
    public static class ModelExtensions
    {
        #region Album
        public static AlbumViewModel ToModel(this album item)
        {
            if (item == null) return null;
            return new AlbumViewModel
            {
                album_id = item.album_id,
                album_name = item.album_name
            };
        }
        public static album ToData(this AlbumViewModel item)
        {
            if (item == null) return null;
            return new album
            {
                album_id = item.album_id,
                album_name = item.album_name
            };
        }
        #endregion

        #region Artist
        public static ArtistViewModel ToModel(this artist item)
        {
            if (item == null) return null;
            return new ArtistViewModel
            {
                artist_id = item.artist_id,
                artist_name = item.artist_name
            };
        }
        public static artist ToData(this ArtistViewModel item)
        {
            if (item == null) return null;
            return new artist
            {
                artist_id = item.artist_id,
                artist_name = item.artist_name
            };
        }
        #endregion

        #region Comment
        public static CommentViewModel ToModel(this comment item)
        {
            if (item == null) return null;
            return new CommentViewModel
            {
                comment_id = item.comment_id,
                comment_text = item.comment_text,
                user_id = item.user_id
            };
        }
        public static comment ToData(this CommentViewModel item)
        {
            if (item == null) return null;
            return new comment
            {
                comment_id = item.comment_id,
                comment_text = item.comment_text,
                user_id = item.user_id
            };
        }
        #endregion

        #region Playhistory
        public static PlayhistoryViewModel ToModel(this play_history item)
        {
            if (item == null) return null;
            return new PlayhistoryViewModel
            {
                play_id = item.play_id,
                track_id = item.track_id,
                user_id = item.user_id,
                time_played = item.time_played,
                user_name = item.user.user_name,
                track_name = item.track.track_name,
                //album_name = item.track.album.album_name
            };
        }
        public static play_history ToData(this PlayhistoryViewModel item)
        {
            if (item == null) return null;
            return new play_history
            {
                play_id = item.play_id,
                track_id = item.track_id,
                user_id = item.user_id,
                time_played = item.time_played

            };
        }
        #endregion

        #region User
        public static UserViewModel ToModel(this user item)
        {
            if (item == null) return null;
            return new UserViewModel
            {
                user_id = item.user_id,
                user_name = item.user_name,
                active = item.active
            };
        }
        public static user ToData(this UserViewModel item)
        {
            if (item == null) return null;
            return new user
            {
                user_id = item.user_id,
                user_name = item.user_name,
                active = item.active
            };
        }
        #endregion

        #region Vote
        public static VoteViewModel ToModel(this vote item)
        {
            if (item == null) return null;
            return new VoteViewModel
            {
                vote_id = item.vote_id,
                vote_value = item.vote_value,
                user_id = item.user_id
            };
        }
        public static vote ToData(this VoteViewModel item)
        {
            if (item == null) return null;
            return new vote
            {
                vote_id = item.vote_id,
                vote_value = item.vote_value,
                user_id = item.user_id
            };
        }
        #endregion

        #region Track
        public static TrackViewModel ToModel(this track item)
        {
            if (item == null) return null;
            return new TrackViewModel
            {
                track_id = item.track_id,
                track_name = item.track_name,
                artist_id = item.artist_id,
                album_id = item.album_id
            };
        }
        public static track ToData(this TrackViewModel item)
        {
            if (item == null) return null;
            return new track
            {
                track_id = item.track_id,
                track_name = item.track_name,
                artist_id = item.artist_id,
                album_id = item.album_id
            };
        }
        #endregion
    }
}