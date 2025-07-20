namespace ToDoAPI
{
    public class Todo
    {

        //A model is  class that represents the data in the app.
        public int Id { get; set; }

        public string? Name { get; set; }

        public bool IsComplete { get; set; }
    }
}
