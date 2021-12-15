namespace DsaRules.GeneralRules
{
    public class RoleHistory
    {
        private List<RoleResult> _roleResults;

        public RoleHistory()
        {
            _roleResults = new List<RoleResult>();
        }

        internal void Add(RoleResult firstRoleResult)
        {
            _roleResults.Add(firstRoleResult);
        }

        public RoleResult this[int key]
        {
            get => _roleResults[key];
            set => _roleResults[key] = value;
        }

        public int Count => _roleResults.Count;
    }
}