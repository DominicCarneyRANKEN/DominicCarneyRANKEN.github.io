namespace CarInventory
{
    public class CarDTO
    {
        //Auto implemented properties
        //The Id property is the primary key

        public int Id { get; set; }

        //What properties should a car have?

        public string Make { get; set; }

        public string Model { get; set; }

        public bool IsAvailable { get; set; }

        public CarDTO() { }

        public CarDTO(Car car)
        {
            Id = car.Id;
            Make = car.Make;
            Model = car.Model;
            IsAvailable = car.IsAvailable;
        }
    }
}
