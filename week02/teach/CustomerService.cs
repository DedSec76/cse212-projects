/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        //var cs = new CustomerService(10);
        //Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create a customer service queue with a capacity of 5.
        // Expected Result: The queue should have a maximum size of 5.
        // Defect(s) Found: None.
        Console.WriteLine("Test 1");

        var test1 = new CustomerService(5);
        Console.WriteLine(test1);

        

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Create a customer service queue with a capacity of 0.
        // Expected Result: The queue should use the default capacity of 10.
        // Defect(s) Found: None.
        Console.WriteLine("Test 2");

        var test2 = new CustomerService(0);
        Console.WriteLine(test2);

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Create a customer service queue with a negative capacity.
        // Expected Result: The queue should use the default capacity of 10.
        // Defect(s) Found: None.
        Console.WriteLine("Test 3");

        var test3 = new CustomerService(0);
        Console.WriteLine(test3);

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Add a new customer to an empty queue.
        // Expected Result: The customer should be added successfully.
        // Defect(s) Found: None.
        Console.WriteLine("Test 4");

        var test4 = new CustomerService(5);
        test4.AddNewCustomer();
        test4.ServeCustomer();

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Add a customer when the queue has reached its maximum capacity.
        // Expected Result: The customer should not be added, and an error message should be displayed.
        // Defect(s) Found: The original condition used > instead of >=,
        // allowing the queue to exceed its maximum capacity.
        Console.WriteLine("Test 5");

        var test5 = new CustomerService(1);
        test5.AddNewCustomer();
        test5.AddNewCustomer();
                
        Console.WriteLine(test5);

        Console.WriteLine("=================");

        // Test 6
        // Scenario: Serve a customer when multiple customers are waiting.
        // Expected Result: The first customer added should be served and removed from the queue.
        // Defect(s) Found: The original implementation removed the first customer
        // before retrieving it, causing it to display the next customer instead.       
        Console.WriteLine("Test 6");

        var test6 = new CustomerService(3);
        test6.AddNewCustomer();
        test6.AddNewCustomer();
        test6.AddNewCustomer();

        test6.ServeCustomer();
                
        Console.WriteLine(test6);

        Console.WriteLine("=================");

        // Test 7
        // Scenario: Serve a customer when the queue is empty.
        // Expected Result: An error message should be displayed without throwing an exception.
        // Defect(s) Found: The original implementation did not check
        // whether the queue was empty before removing an element.
        Console.WriteLine("Test 7");

        var test7 = new CustomerService(3);
        test7.ServeCustomer();
                
        Console.WriteLine(test7);
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if(_queue.Count == 0)
        {
            Console.WriteLine("Queue empty. Cannot process.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}