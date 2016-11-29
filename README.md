# MediaFarmer
A Complete File > New of Music Farmer.
<br>
Nifty Jukebox System perfect for work environments, let users queue music tracks from their desks to the servers loud speaker.

<b>Setting up your 'Media' Folder</b>

In Music Farm v2/Content, create a symbolic link to your Music or Media folder if it is elsewhere.

<b>Creating the hard link</b>
mklink /J [MediaFolderInMediaFarmer] [SourceMediaFolder]

<b>Projects in MediaFarmer</b>
The MusicFarmer v2 folder is the frontend, either the MusicFarmer.Player (Console App) or the MediaFarmer.PlayerService (Windows Service) is used by the machine actually playing the tracks from the playlist <b>(USE EITHER, NOT BOTH)</b>.

<b>Features</b>
Upvoting and downvoting a track affects the volume, either bumping it up or lowering it. This is for that instance of the track, JukeBox AutoQue automatically Queue's a track if things are quiet (Hint hint, add a config if you can ;)).

<b>Thanks</b>
<b>Adam Stockden</b> (This guy had the vision and created Music Farmer back in the day)
<b>Riaan Swart</b> (This guy guided me through this project end to end, this would have been called Spagetti Code MusicPlayer and no one would want to maintain it if it wasnt for him :))

Most of all, Play it loud!!!

