namespace DsaRules
{
    public class Character
    {
        public int Courage { get; private set; }

        public Character WithCourage(int courageValue)
        {
            this.Courage = courageValue;
            return this;
        }
    }
}