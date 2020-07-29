namespace _4._39_WCF
{
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyService.svc or MyService.svc.cs at the Solution Explorer and start debugging.
    public class MyService : IMyService
    {
        public string DoWork(string left, string right)
        {
            return left + right;
        }
    }
}
