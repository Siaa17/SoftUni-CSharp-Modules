using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> characters;
		private List<Item> items;

		public WarController()
		{
			this.characters = new List<Character>();
			this.items = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			Character character = null;

            if (characterType == nameof(Warrior))
            {
				character = new Warrior(name);
            }
            else if (characterType == nameof(Priest))
            {
				character = new Priest(name);
			}
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}

			this.characters.Add(character);

			return string.Format(SuccessMessages.JoinParty, name);
        }

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			Item item = null;

			if (itemName == nameof(HealthPotion))
			{
				item = new HealthPotion();
			}
			else if (itemName == nameof(FirePotion))
			{
				item = new FirePotion();
			}
			else
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
			}

			this.items.Add(item);

			return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			Character character = this.characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

            if (this.items.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}

			Item lastItem = this.items.TakeLast(this.items.Count).LastOrDefault();
			character.Bag.AddItem(lastItem);

			return string.Format(SuccessMessages.PickUpItem, characterName, lastItem.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = this.characters.FirstOrDefault(c => c.Name == characterName);

			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

			List<Character> orderedCharacters = this.characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health).ToList();

            foreach (Character character in orderedCharacters)
            {
				sb.AppendLine(string.Format(SuccessMessages.CharacterStats, character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, character.IsAlive ? "Alive" : "Dead"));
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = this.characters.FirstOrDefault(c => c.Name == attackerName);
			Character receiver = this.characters.FirstOrDefault(c => c.Name == receiverName);

			if (attacker == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}

			if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}

			Warrior warrior = attacker as Warrior;

			if (warrior == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
			}	

			warrior.Attack(receiver);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
				sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			Character healer = this.characters.FirstOrDefault(c => c.Name == healerName);
			Character receiver = this.characters.FirstOrDefault(c => c.Name == healingReceiverName);

			if (healer == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}

			if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
			}

			Priest priest = healer as Priest;

            if (priest == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
			}

			priest.Heal(receiver);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine(string.Format(SuccessMessages.HealCharacter, healerName, healingReceiverName, healer.AbilityPoints, healingReceiverName, receiver.Health));

			return sb.ToString().TrimEnd();
		}
	}
}
