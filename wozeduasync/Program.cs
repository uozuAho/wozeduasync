using System.Threading.Tasks;

namespace wozeduasync
{
    class Program
    {
        private static void Main(string[] args) 
        { 
            Utils.Log("In Main, before SumAsync call"); 
            Task<int> task = SumAsync(); 
            Utils.Log("In Main, after SumAsync returned");

            int result = task.Result;
            Utils.Log("Final result: " + result); 
        }

        private static async Task<int> SumAsync()
        {
            Task<int> task1 = DummyAsync.ReturnXAfterNms(10, 500);
            Task<int> task2 = DummyAsync.ReturnXAfterNms(5, 750);

            Utils.Log("In SumAsync, before awaits"); 
            
            int value1 = await task1; 
            int value2 = await task2;

            Utils.Log("In SumAsync, after awaits");

            return value1 + value2; 
        }
    }
}

