using System;
using System.Collections.Generic;

namespace Colors
{
    class Program
    {
        static void Main(string[] args)
        {
            var retriever = new UserListRetriever("What are your favorite colors?");

            var collector = new List<string>();
            foreach (var answer in retriever)
            {
                collector.Add(answer);
            }

            Console.WriteLine("You said your favorite colors are:");
            Console.WriteLine(string.Join(",", collector));
        }

        public class ReadLineEnumerator
        {
            public string Current { get; private set; }
            private readonly string _question;

            public ReadLineEnumerator(
                string question)
            {
                _question = question;
                Reset();
            }

            public bool MoveNext()
            {
                Console.Out.Write("> ");
                Current = Console.ReadLine();
                return !string.IsNullOrWhiteSpace(Current);
            }

            public void Reset()
            {
                Console.WriteLine(_question);
                Current = null;
            }
        }

        public class UserListRetriever
        {
            private readonly string _question;

            public UserListRetriever(string question)
            {
                _question = question;
            }

            public ReadLineEnumerator GetEnumerator()
            {
                return new ReadLineEnumerator($"{_question}\n(Enter one answer per line and empty line to stop");
            }
        }
    }
}