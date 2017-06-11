using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790Assignment3.Data
{
    public class QuickNotes
    {
		/*
		 * 
		 * ---Video Games---

[Table] Publisher
int PublisherID [PK]
string Name
bool IsIndiePublisher

[Table] Game
int GameID [PK]
int PublisherID [FK]
string Name
string Genre
decimal Price
decimal HoursPlayed
bool IsGameCompleted
bool StillPlaying
bool IsOnlineMultiplayer

[Table] Screenshot
int ScreenshotID [PK]
int GameID [FK]
datetime CaptureDateTime
string LocalPath
string Category //eg Achievement Get, Humor, Awesome, Pretty Graphics, Bug/Glitch, etc.

[Table] Review
int ReviewID [PK]
int GameID [FK]
int AuthorID [FK] //Will make these up to prevent 80+ tables.
bool DoesRecommend
string ReviewContent
datetime LastUpdateDate
datetime SubmissionDate

--- RELATIONS ---
Publisher is a one to many with Game
	Game is a many to one with Publisher
	
Game is a one to many with Screenshot
	Screenshot is a many to one with Game

Game is a one to many with Review
	Review is a many to one with Game
	
--- TRAVERSALS ---
[Publisher]<--(PublisherID)-->[Game]
[Game]<--(GameID)-->[Screenshot]
[Game]<--(GameID)-->[Review]

		 * 
		 * 
		 * 
		 * 
		 * 
		 */
	}
}
