using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    public class Character
    {
        public Character(string _name, int _health, int _strength, int _luck)
        {
            name = _name;
            maxHealth = _health;
            stregth = _strength;
            luck = _luck;
        }

        private string name; 
        private int maxHealth;
        private int stregth;
        private int luck;


        public void PrintCharacterInfo()
        {
            Console.WriteLine("*********");
            Console.WriteLine("Character name: " + name);
            Console.WriteLine("Character health: " + maxHealth);
            Console.WriteLine("Character strength: " + stregth);
            Console.WriteLine("Character luck: " + luck);
            Console.WriteLine("*********");
        }


        #region Getters
        public string Name { get => name; }
        public int MaxHealth { get => maxHealth; }
        public int Stregth { get => stregth; }
        public int Luck { get => luck; }
        #endregion
    }
}
