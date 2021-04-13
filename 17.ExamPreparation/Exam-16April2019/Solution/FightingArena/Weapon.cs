namespace FightingArena
{
    public class Weapon
    {
        private int size;
        private int solidity;
        private int sharpness;

        public Weapon(int size, int solidity, int sharpness)
        {
            this.Size = size;
            this.Solidity = solidity;
            this.Sharpness = sharpness;
        }

        public int Sharpness
        {
            get { return sharpness; }
            set { sharpness = value; }
        }


        public int Solidity
        {
            get { return solidity; }
            set { solidity = value; }
        }


        public int Size
        {
            get { return size; }
            set { size = value; }
        }

    }
}
