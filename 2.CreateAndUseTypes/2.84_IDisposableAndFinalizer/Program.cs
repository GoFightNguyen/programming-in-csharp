using System;
using System.IO;
using System.Runtime.InteropServices;

namespace _2._84_IDisposableAndFinalizer
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class UnmanagedWrapper : IDisposable
    {
        private IntPtr unmanagedBuffer;
        public FileStream Stream { get; private set; }

        public UnmanagedWrapper()
        {
            CreateBuffer();
            this.Stream = File.Open("temp.dat", FileMode.Create);
        }

        private void CreateBuffer()
        {
            byte[] data = new byte[1024];
            new Random().NextBytes(data);
            unmanagedBuffer = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, unmanagedBuffer, data.Length);
        }

        ~UnmanagedWrapper()
        {
            Dispose(false);
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            //This is the IDisposable one
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            Marshal.FreeHGlobal(unmanagedBuffer);
            if (disposing)
                if (Stream != null)
                    Stream.Close();
        }

        /*
         * The Dispose method with the boolean arg does the real work:
         *      *If called by the finalizer, only release the unmanaged buffer. The Stream also implements a finalizer and the garbage collector
         *       will call the finalizer of the Stream instance.
         *      *If Dispose is called explicitely, you also close the underlying Stream. It is important to be defensive in coding this method 
         *       and check for sources of exceptions. It could be that Dispose was called multiple times
         *       
         * The IDisposable.Dispose() method calls GC.SuppressFinalize(this) to ensure the object is removed from the finalization queue. If this 
         * method has been called, then the instance has already cleaned up after itself, so it is unnecessary for the garbage collector to call
         * the finalizer.
         */
    }
}
