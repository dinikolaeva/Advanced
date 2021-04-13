using System;

namespace FightingArena
{
    public class Stat
    {
        private int strength;
        private int flexibility;
        private int agility;
        private int skills;
        private int intelligence;

        public Stat(int strength, int flexibility, int agility, int skills, int intelligence)
        {
            this.Strength = strength;
            this.Flexibility = flexibility;
            this.Agility = agility;
            this.Skills = skills;
            this.Intelligence = intelligence;
        }
        
        public int Intelligence
        {
            get { return intelligence; }
            set { intelligence = value; }
        }


        public int Skills
        {
            get { return skills; }
            set { skills = value; }
        }


        public int Agility
        {
            get { return agility; }
            set { agility = value; }
        }


        public int Flexibility
        {
            get { return flexibility; }
            set { flexibility = value; }
        }


        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }

    }
}
