using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaFarmer.Tests.Mock.Database.MockData
{
    class MockJukeBoxTests : BaseMock
    {

        public MockJukeBoxTests()
        {
            PopulateJukeBoxTracks();
        }

        private void PopulateJukeBoxTracks()
        {
            var items = new List<JukeBoxTracks_Result>
            {
                new JukeBoxTracks_Result
                {
                    TrackId = 1,
                    TrackName = "Some Track",
                    Votes = 10,
                    Favourites = 3,
                    Played = 15
                },
                new JukeBoxTracks_Result
                {
                    TrackId = 1,
                    TrackName = "Some Track2",
                    Votes = 12,
                    Favourites = 3,
                    Played = 15
                }
            };
            MockContext.Setup(i => i.Set<JukeBoxTracks_Result>()).Returns(MockHelper.GetMockSet(items).Object);
        }

    }
}
