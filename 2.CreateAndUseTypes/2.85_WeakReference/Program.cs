using System;

namespace _2._85_WeakReference
{
    class Program
    {
        static WeakReference data;

        public static void Run()
        {
            object result = GetData();
            //GC.Collect(); uncommenting this line will make data.Target null
            result = GetData();
        }

        private static object GetData()
        {
            if (data == null)
                data = new WeakReference(LoadLargeList());

            if (data.Target == null)
                data.Target = LoadLargeList();

            return data.Target;
        }

        private static object LoadLargeList()
        {
            throw new NotImplementedException();
        }

        static void Main(string[] args)
        {
        }
    }
}
