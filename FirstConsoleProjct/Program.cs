//Ebrahim Shahid
using System;

namespace FirstConsoleProject
{
	class MainClass
	{
		interface IItem
		{
			string name { get; set; }
			int goldValue { get; set; }

			void Equip();
			void Sell();
		}

		interface IDamagabe
		{
			int durability { get; set; }

			void TakeDamage(int _amount);
		}

		interface IPartofQuest
		{
			void TurnIn();
		}

		class Sword : IItem, IDamagabe, IPartofQuest
		{
			public string name { get; set; }
			public int goldValue { get; set; }

			public int durability { get; set; }

			public Sword(string _name)
			{
				name = _name;
				goldValue = 100;
				durability = 30;
			}

			public void Equip()
			{
				Console.WriteLine(name + " equipped");
			}

			public void Sell()
			{
				Console.WriteLine(name + " sold for " + goldValue + " Imaginary Dollars!");
			}

			public void TakeDamage(int _dmg)
			{
				durability -= _dmg;
				Console.WriteLine(name + " damaged by " + _dmg + ". It now has a durability of " + durability);
			}

			public void TurnIn()
			{
				Console.WriteLine(name + " turned in.");
			}
		}

		class Axe : IItem, IDamagabe, IPartofQuest
		{
			public string name { get; set; }
			public int goldValue { get; set; }

			public int durability { get; set; }

			public Axe(string _name)
			{
				name = _name;
				goldValue = 70;
				durability = 50;
			}

			public void Equip()
			{
				Console.WriteLine(name + " equipped");
			}

			public void Sell()
			{
				Console.WriteLine(name + " sold for " + goldValue + " Imaginary Dollars!");
			}

			public void TakeDamage(int _dmg)
			{
				durability -= _dmg;
				Console.WriteLine(name + " damaged by " + _dmg + ". It now has a durability of " + durability);
			}

			public void TurnIn()
			{
				Console.WriteLine(name + " turned in (it was an axe).");
			}
		}

		static void Main(string[] args)
		{
			Sword sword = new Sword("Sword of Destiny");
			sword.Equip();
			sword.TakeDamage(20);
			sword.Sell();

			Console.WriteLine();

			Axe axe = new Axe("Fury Axe");
			axe.Equip();
			axe.TakeDamage(10);
			axe.Sell();

			Console.WriteLine();

			//Create an Inventory
			IItem[] inventory = new IItem[2];
			inventory[0] = sword;
			inventory[1] = axe;

			//Loop thru and turn in all quest items
			for (int i = 0; i < inventory.Length; i++)
			{

				IPartofQuest questItem = inventory[i] as IPartofQuest;
				if (questItem != null)
				{
					questItem.TurnIn();
				}
				Console.ReadKey();
			}
		}
	}
}
