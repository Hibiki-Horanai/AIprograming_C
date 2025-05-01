using System;

namespace RecursiceCallApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new RecursiveCallApp();
            Console.WriteLine("階乗=" + app.Fact(5));
            Console.ReadKey();
        }


    }

    public class RecursiveCallApp
    {
        int level = 0;

        T Trace<T>(string fname, string[] args,Func<T> fun)
        {
            var s = new string(new char[level]).Replace("\0", "- ") + level + ": " + fname;
            Console.WriteLine(s + "(" + string.Join(",", args) + ")");
            level++;
            var ret = fun();
            level--;
            Console.WriteLine(s + " =" + ret);
            return ret;
        }
        public int Fact(int x)
        {
            return Trace("Fact", new string[] { x.ToString() }, () =>
            {
                if (x == 1) return 1;
                else return x * Fact(x - 1);
            });
        }
    }


}
