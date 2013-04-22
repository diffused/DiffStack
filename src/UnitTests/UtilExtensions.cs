using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public static class UtilExtensions
    {
        public static void Times(this int count, Action<int> action)
        {
            for (int i = 0; i < count; i++)
                action(i);

        }

    }
}
