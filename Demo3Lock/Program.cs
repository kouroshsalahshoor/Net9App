
List<int> numbers = Enumerable.Range(1, 1000000).ToList();
List<int> squares = new List<int>();

object lockObject = new object(); // Create a lock object for synchronization

Parallel.ForEach(numbers, (number) =>
{
    int square = number * number;

    lock (lockObject) // Acquire a lock to ensure synchronization
    {
        squares.Add(square); // Add the square to the synchronized list
    }
});