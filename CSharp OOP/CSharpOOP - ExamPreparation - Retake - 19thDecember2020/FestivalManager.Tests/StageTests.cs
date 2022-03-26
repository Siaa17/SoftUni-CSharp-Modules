// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;
		private Song song;
		private Performer performer;

		[SetUp]
		public void SetUp()
        {
			this.stage = new Stage();
			this.song = new Song("Nevermind", new TimeSpan(0, 2, 36));
			this.performer = new Performer("Dennis", "Lloyd", 28);
        }

		[Test]
	    public void Ctor_InitializesCollectionCorrectly()
	    {
			Assert.IsNotNull(this.stage);
		}

		[Test]
		public void Prop_ReturnsCollectionAsReadOnly()
        {
			Assert.IsInstanceOf<IReadOnlyCollection<Performer>>(this.stage.Performers);
        }

		[Test]
		public void AddPerformer_ThrowsException_WhenPerformerIsNull()
        {
			Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(null));
        }

		[Test]
		public void AddPerformer_ThrowsException_WhenPerformerIsUnder18()
		{
			Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(new Performer("Dennis", "Lloyd", 17)));
		}

		[Test]
		public void AddPerformer_AddsPerformer_WhenAddIsValidOperation()
		{
			this.stage.AddPerformer(performer);
			int expectedCount = 1;

			Assert.That(this.stage.Performers.Count, Is.EqualTo(expectedCount));
		}

		[Test]
		public void AddSong_ThrowsException_WhenSongIsNull()
		{
			Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(null));
		}

		[Test]
		public void AddSong_ThrowsException_WhenSongDurationIsUnder1Minute()
        {
			Assert.Throws<ArgumentException>(() => this.stage.AddSong(new Song("Nevermind", new TimeSpan(0, 0, 53))));
		}

		[Test]
		[TestCase(null, null)]
		public void AddSongToPerformer_ThrowsException_WhenPerformerNameIsNull(string songName, string performerName)
        {
			Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(songName, performerName));
		}

		[Test]
		public void AddSongToPerformer_AddsSong_WhenIsValidOperation()
        {
			this.stage.AddPerformer(performer);
			this.stage.AddSong(song);
			this.stage.AddSongToPerformer(song.Name, performer.FullName);

			int expectedPerformerSongsCount = 1;

			Assert.That(this.performer.SongList.Count, Is.EqualTo(expectedPerformerSongsCount));
        }

		[Test]
		public void AddSongToPerformer_ReturnsMessageCorrectly_WhenIsValidOperation()
		{
			this.stage.AddPerformer(performer);
			this.stage.AddSong(song);

			string expectedResult = $"{song} will be performed by {performer}";

			Assert.AreEqual(expectedResult, this.stage.AddSongToPerformer(song.Name, performer.FullName));
		}

		[Test]
		public void Play_ReturnsMessageCorrectly()
		{
			this.stage.AddPerformer(performer);
			this.stage.AddSong(song);
			this.stage.AddSongToPerformer(song.Name, performer.FullName);

			string expectedResult = $"{this.stage.Performers.Count} performers played {this.performer.SongList.Count} songs";

			Assert.That(this.stage.Play(), Is.EqualTo(expectedResult));
		}
	}
}
