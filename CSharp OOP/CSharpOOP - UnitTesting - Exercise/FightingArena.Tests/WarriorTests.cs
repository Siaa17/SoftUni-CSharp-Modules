using System;
using NUnit.Framework;
//using FightingArena;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Biana", 100, 250);
        }

        [Test]
        [TestCase("", 100, 250)]
        [TestCase("  ", 100, 250)]      
        [TestCase(null, 100, 250)]      
        [TestCase("Biana", 0, 250)]      
        [TestCase("Biana", -150, 250)]   
        [TestCase("Biana", 100, -200)]   
        public void Ctor_ThrowsException_WhenDataIsInvalid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void Ctor_SetInitialValues_WhenArgumentsAreValid()
        {
            Assert.That(this.warrior.Name, Is.EqualTo("Biana"));
            Assert.That(this.warrior.Damage, Is.EqualTo(100));
            Assert.That(this.warrior.HP, Is.EqualTo(250));
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void Attack_ThrowException_WhenAttackerHPIsLessThanMinHP(int attackerHP)
        {
            Warrior attacker = new Warrior("Biana", 100, attackerHP);
            Warrior warrior = new Warrior("Warrior", 80, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void Attack_ThrowException_WhenWarriorHPIsLessThanMinHP(int warriorHP)
        {
            Warrior attacker = new Warrior("Biana", 100, 250);
            Warrior warrior = new Warrior("Warrior", 80, warriorHP);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Attack_ThrowsException_WhenWarriorKillsAttacker()
        {
            Warrior attacker = new Warrior("Biana", 100, 250);
            Warrior warrior = new Warrior("Warrior", 300, 250);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Attack_DecreasesAttackerHPByWarriorDamage()
        {
            int initialAttackerHP = 250;
            Warrior attacker = new Warrior("Biana", 100, initialAttackerHP);
            Warrior warrior = new Warrior("Warrior", 110, 250);
            attacker.Attack(warrior);

            Assert.That(attacker.HP, Is.EqualTo(initialAttackerHP - warrior.Damage));
        }

        [Test]
        public void Attack_SetWarriorHPToZero_WhenAttackerDamageIsGreaterThanWarriorHP()
        {
            Warrior attacker = new Warrior("Biana", 350, 250);
            Warrior warrior = new Warrior("Warrior", 110, 250);
            attacker.Attack(warrior);

            Assert.That(warrior.HP, Is.EqualTo(0));
        }

        [Test]
        public void Attack_DecreasesWarriorHPByAttackerDamage()
        {
            int initialWarriorHP = 250;
            Warrior attacker = new Warrior("Biana", 100, 250);
            Warrior warrior = new Warrior("Warrior", 110, initialWarriorHP);
            attacker.Attack(warrior);

            Assert.That(warrior.HP, Is.EqualTo(initialWarriorHP - attacker.Damage));
        }
    }
}
