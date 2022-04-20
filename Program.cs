using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            //employeeDetails.Add(new EmployeeDetails(EmployeeID: 1, EmployeeNumber: "Bruce", PhoneNumber: "675765677", Address: "Banglore", Department: "hr"));
            //employeeDetails.Add(new EmployeeDetails(EmployeeID: 2, EmployeeNumber: "Mac", PhoneNumber: "675765677", Address: "Banglore", Department: "hr"));
            //employeeDetails.Add(new EmployeeDetails(EmployeeID: 3, EmployeeNumber: "Juo", PhoneNumber: "675765677", Address: "Banglore", Department: "hr"));
            //employeeDetails.Add(new EmployeeDetails(EmployeeID: 1, EmployeeNumber: "Max", PhoneNumber: "675765677", Address: "Banglore", Department: "hr"));
            //employeeDetails.Add(new EmployeeDetails(EmployeeID: 4, EmployeeNumber: "Rita", PhoneNumber: "675765677", Address: "Banglore", Department: "hr"));
            //employeeDetails.Add(new EmployeeDetails(EmployeeID: 5, EmployeeNumber: "Joo", PhoneNumber: "675765677", Address: "Banglore", Department: "hr"));
            //employeeDetails.Add(new EmployeeDetails(EmployeeID: 6, EmployeeNumber: "John", PhoneNumber: "675765677", Address: "Banglore", Department: "hr"));
            //employeeDetails.Add(new EmployeeDetails(EmployeeID: 7, EmployeeNumber: "illi", PhoneNumber: "675765677", Address: "Banglore", Department: "hr"));
            //employeeDetails.Add(new EmployeeDetails(EmployeeID: 8, EmployeeNumber: "wing", PhoneNumber: "675765677", Address: "Banglore", Department: "hr"));


            //AddEmployee addEmployee = new AddEmployee();

            ////addEmployee.AddEmployeeToList(employeeDetails);

            //Console.WriteLine("---------------------------------");

            //addEmployee.AddEmployeeToListWithThread(employeeDetails);

            string[] words = CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");

            Parallel.Invoke(() =>
            {
                Console.WriteLine("Begin first task....");
                GetLongestWord(words);
            },

            () =>
            {
                Console.WriteLine("Begin Second task....");
                GetMostCommonWords(words);

            },

            () =>
            {
                Console.WriteLine("Begin third task.....");
                GetCountForWords(words, "sleep");
            }
             );
            Console.WriteLine("Returned from Parallel.Invoke");

        }

        private static void GetCountForWords(string[] words, string term)
        {
            var findword = from word in words
                           where word.ToUpper().Contains(term.ToUpper())
                           select word;

            Console.WriteLine("Tak 3 -- The word {0} occurns {1} times", term, findword.Count());

        }

        private static string GetLongestWord(string[] words)
        {
            var longestWord = (from w in words
                               orderby w.Length descending
                               select w).First();

            Console.WriteLine("Task 1 --- the longest word is {0}", longestWord);

            return longestWord;
        }

        static string[] CreateWordArray(string uri)
        {
            Console.WriteLine("Retreving from " + uri);

            string s = new WebClient().DownloadString(uri);

            return s.Split(new char[] { ' ', ',', '.', ':', '\u000A', ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static void GetMostCommonWords(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;

            var commonwords = frequencyOrder.Take(10);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Task 2 --- THe most common words are: ");
            foreach (var v in commonwords)
            {
                sb.AppendLine(" " + v);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}