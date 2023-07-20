namespace TodoList
{
    class Program
    {
        static List<string> Todos = new List<string>();

        static void Main(string[] args)
        {
            description();
            var shallExit = false;

            while (!shallExit)
            {
                var userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "s":
                    case "S":
                        SeeAllTodos();
                        break;
                    case "a":
                    case "A":
                        AddTodo();
                        Console.WriteLine("Todo has been added.");
                        break;
                    case "r":
                    case "R":
                        RemoveTodos();
                        break;
                    case "e":
                    case "E":
                        shallExit = true;
                        break;
                }
                description();
            }
        }
        public static void description()
        {
            Console.WriteLine("Hello \r\n");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[S]ee all todos.");
            Console.WriteLine("[A]dd a todo.");
            Console.WriteLine("[R]emove a todo.");
            Console.WriteLine("[E]xit");
            Console.Write("> ");
        }
        public static void SeeAllTodos()
        {
            if(Todos.Count == 0)
            {
                ShowNoToDosMessage();
                return;
            }
            for(int i = 0; i < Todos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Todos[i]}");
            }
        }
        public static void AddTodo()
        {
            string description;
            do
            {
                Console.WriteLine("Enter a Todo description.");
                description = Console.ReadLine();
            } while (!IsDescriptionValid(description));
            Todos.Add(description);
        }
        public static bool IsDescriptionValid(string description)
        {
            if(description == "")
            {
                Console.WriteLine("This description cannot be empty.");
                return false;
            }
            // Checks to see if there is already a similar description.
            if (Todos.Contains(description))
            {
                Console.WriteLine("The description must be unique.");
                return false;
            }
            return true;
        } 
        public static void RemoveTodos()
        {
            if(Todos.Count == 0)
            {
                ShowNoToDosMessage();
                return;
            }
            int index;
            do
            {
                Console.WriteLine("Select the index of the todo you want to remove.");
                SeeAllTodos();
            } while (!TryReadIndex(out index));
            RemoveTodoAtIndex(index - 1);
        }
        public static void RemoveTodoAtIndex(int index)
        {
            var todoToBeRemoved = Todos[index];
            Todos.RemoveAt(index);
            Console.WriteLine($"Todo removed : {todoToBeRemoved}");
        }
        public static bool TryReadIndex(out int index)
        {
            var userInput = Console.ReadLine();
            if(userInput == "")
            {
                index = 0;
                Console.WriteLine("Index cannot be empty");
                return false;
            }
            if(int.TryParse(userInput, out index) &&
                index >= 1 &&
                index <= Todos.Count)
            {
                return true;
            }
            Console.WriteLine("The given index does not exist");
            return false;
        }
        public static void ShowNoToDosMessage()
        {
            Console.WriteLine("No todos have been added");
        }
    }
}