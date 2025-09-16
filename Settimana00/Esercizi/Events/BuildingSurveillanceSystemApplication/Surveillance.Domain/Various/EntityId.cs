namespace Surveillance.Domain.Various
{
    public sealed class EntityId
    {
        private string _value = null!;
        public string Value
        {
            get => _value ?? throw new InvalidOperationException();
            private set => _value = value;
        }

        private EntityId(string value)
        {
            Value = value;
        }

        public static EntityId Create(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            return new EntityId(id);
        }
    }
}