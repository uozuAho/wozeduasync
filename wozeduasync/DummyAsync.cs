using System.Threading;
using System.Threading.Tasks;

namespace wozeduasync
{
    class DummyAsync
    {
        public static Task<int> ReturnXAfterNms(int value, int milliseconds)
        {
            return Task.Factory.StartNew(() =>
            {
                Utils.Log($"Will return {value} in {milliseconds}ms...");
                Thread.Sleep(milliseconds);
                Utils.Log($"...returning {value}");
                return value;
            });
        }
    }
}
