using System;

namespace _1._85_Events_CustomEventAccessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Pub();
            p.OnChange += (sender, e) => Console.WriteLine(e.Value);
            p.Raise();

            Console.ReadLine();
        }
    }

    public class Pub
    {
        private event EventHandler<MyArgs> onChange = delegate { };
        public event EventHandler<MyArgs> OnChange
        {
            add
            {
                lock(onChange)
                    onChange += value;
            }
            remove
            {
                lock(onChange)
                    onChange -= value;
            }
        }
        public void Raise()
        {
            onChange(this, new MyArgs(42));
        }
    }

    public class MyArgs : EventArgs
    {
        public int Value { get; set; }

        public MyArgs(int value)
        {
            Value = value;
        }
    }
    }