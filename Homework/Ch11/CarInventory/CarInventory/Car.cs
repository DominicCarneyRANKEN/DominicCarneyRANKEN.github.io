namespace CarInventory
{
    public class Car
    {
        //Auto-implemented properties
        //The id property is the primary key
        public int Id { get; set; }

        //What properties should a car have?

        public string Make { get; set; }

        public string Model { get; set; }

        public bool IsAvailable { get; set; }

        public string? Secret { get; set; }
    }
}
