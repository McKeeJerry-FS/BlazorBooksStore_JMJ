using Microsoft.JSInterop;

namespace BlazorBooksStore;

public class JsSample
{
  [JSInvokable("AddTwoNumbers")]
  public static int Sum(int firstNumber, int secondNumber)
  {
    return firstNumber + secondNumber;
  }


  [JSInvokable]
  public void OnWindowResized(int width, int height)
  {
    Console.WriteLine($"Window resized to {width} x {height}");
  }
}