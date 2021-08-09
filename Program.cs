using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace Lesson_13
{
    public class User
    {
      public string Firstname { get; set; }
      public string Secondname { get; set; }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            if(user==null)
            {
                return false;
            }
            return Firstname == user.Firstname && Secondname == user.Secondname;
        }

        public override int GetHashCode()
        {
            int FirstnameHashCode = Firstname?.GetHashCode() ?? 0;
            int SecondNameHashCode = Secondname?.GetHashCode() ?? 0;
            return FirstnameHashCode ^ SecondNameHashCode;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

            Random random = new Random();
            string ran = random.Next(1, 10000).ToString();
            var HasSet = new HashSet<User>();
            var user = new User() { Firstname = ran, Secondname = ran };
            HasSet.Add(user);

            var searchUsser = new User() { Firstname = ran, Secondname = ran };

            Console.WriteLine($"contains user {HasSet.Contains(user)}, contains searchUsser {HasSet.Contains(searchUsser)}");



     }  }

    public class BenchmarKlass:User
    {
        public override bool Equals(object obj)
        {
            var user = obj as User;
            if (user == null)
            {
                return false;
            }
            return Firstname == user.Firstname && Secondname == user.Secondname;
        }
        public override int GetHashCode()
        {
            int FirstnameHashCode = Firstname?.GetHashCode() ?? 0;
            int SecondNameHashCode = Secondname?.GetHashCode() ?? 0;
            return FirstnameHashCode ^ SecondNameHashCode;
        }

        [Benchmark]
        public void TestTime()
        {
            GetHashCode();

        }
       
    }
}

