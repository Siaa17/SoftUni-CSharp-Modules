using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
//using FightingArena;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior = new Warrior("Biana", 100, 250);
        }

        [Test]
        public void Ctor_InitializesCollectionCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void Prop_ReturnsCount()
        {
            Assert.That(this.arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void Prop_ReturnsCollectionAsReadOnly()
        {
            Assert.IsInstanceOf<IReadOnlyCollection<Warrior>>(this.arena.Warriors);
        }

        [Test]
        public void Enroll_ThrowsException_WhenWarriorIsAlreadyEnrolled()
        {
            this.arena.Enroll(this.warrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(this.warrior));
        }

        [Test]
        public void Enroll_IncreasesArenaCount()
        {
            this.arena.Enroll(this.warrior);
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.arena.Count);
        }

        [Test]
        public void Enroll_AddsWarriorsOrWarrior()
        {
            string name = "Biana";
            this.arena.Enroll(this.warrior);

            Assert.IsTrue(this.arena.Warriors.Any(w => w.Name == name));
        }

        [Test]
        public void Fight_ThrowsException_WhenDefenderDoesNotExist()
        {
            Warrior attacker = this.warrior;
            this.arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attacker.Name, "DefenderName"));
        }

        [Test]
        public void Fight_ThrowsException_WhenAttackerDoesNotExist()
        {
            Warrior defender = this.warrior;
            this.arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("AttackerName", defender.Name));
        }

        [Test]
        public void Fight_ThrowsException_WhenBothDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("AttackerName", "DefenderName"));
        }

        [Test]
        public void Fight_BothWarriorsLoseHPInFight_WhenFightIsValidOperation()
        {
            Warrior attacker = this.warrior;
            Warrior defender = new Warrior("Defender", 100, 250);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP, Is.EqualTo(250 - defender.Damage));
            Assert.That(defender.HP, Is.EqualTo(250 - attacker.Damage));
        }
    }
}
