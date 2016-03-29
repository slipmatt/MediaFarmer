using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Farm_v2.Tests.Mock.Database.MockData
{
    public class MockTrackTests : BaseMock
    {
        public MockTrackTests()
        {
            PopulateTracks();
        }
        private void PopulateTracks()
        {
            var items = new List<Track>
            {
                new Track
                {
                    TrackId=1,
                    TrackName="Track1",
                    AlbumId=1,
                    ArtistId=1,
                    Album=new Album
                    {
                        AlbumId=1,
                        AlbumName="TestAlbum"
                    },
                    Artist=new Artist
                    {
                        ArtistId=1,
                        ArtistName="Artist 1"
                    }
                },
                new Track
                {
                    TrackId=2,
                    TrackName="Track2",
                    AlbumId=1,
                    ArtistId=2,
                    Album=new Album
                    {
                        AlbumId=1,
                        AlbumName="TestAlbum"
                    },
                    Artist=new Artist
                    {
                        ArtistId=2,
                        ArtistName="Artist 2"
                    }
                },
                new Track
                {
                    TrackId=3,
                    TrackName="Track3",
                    AlbumId=1,
                    ArtistId=3,
                    Album=new Album
                    {
                        AlbumId=1,
                        AlbumName="TestAlbum"
                    },
                    Artist=new Artist
                    {
                        ArtistId=3,
                        ArtistName="Artist 3"
                    }
                },
                new Track
                {
                    TrackId=4,
                    TrackName="Track15",
                    AlbumId=2,
                    ArtistId=1,
                    Album=new Album
                    {
                        AlbumId=1,
                        AlbumName="TestTwoAlbum"
                    },
                    Artist=new Artist
                    {
                        ArtistId=1,
                        ArtistName="Artist 1"
                    }
                }
            };
            MockContext.Setup(i => i.Set<Track>()).Returns(MockHelper.GetMockSet(items).Object);
            MockContext.SetupGet(i => i.Tracks).Returns(() => MockHelper.GetMockSet(items).Object);
        }
    }
}
