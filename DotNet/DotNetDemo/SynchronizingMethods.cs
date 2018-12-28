using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace DotNetDemo
{
    class SynchronizingMethods
    {
        public void WithdrawAmount(int num)
        {

            lock (this)
            {
                Console.WriteLine("test");
            }

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void WithdrawAmount()
        {
            Console.WriteLine("hello world");
        }
    }
}
