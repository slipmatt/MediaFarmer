# MediaFarmer
A Little Jukebox System perfect for work environments

<b>Setting up your 'Media' Folder</b>

In Music Farm v2/Content, create a symbolic link to your Music or Media folder if it is elsewhere.

<b>Creating the hard link</b>
mklink /J [MediaFolderInMediaFarmer] [SourceMediaFolder]

<b>Projects in MediaFarmer</b>
The MusicFarmer v2 folder is the frontend, the MusicFarmer.Player is the console app (I know...) that is used by the machine actually playing the tracks from the playlist.

<b>Features</b>
Upvoting and downvoting a track affects the volume, either bumping it up or lowering it. This is for that instance of the track, JukeBox AutoQue automatically Queue's a track if things are quiet (Hint hint, add a config if you can ;)).

Most of all, Play it loud!!!

