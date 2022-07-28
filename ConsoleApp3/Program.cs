using System.Linq;
using System.Xml.Linq;
namespace ConsoleApp3
{
    public class program
    {
       /* public static void calltochildthread()
        {
            try
            {
                Console.WriteLine("child thread begins :");
                int i = 0;
                for (i = 0; i < 10; i++)
                {
                    Thread.Sleep(500);
                    Console.Write(i + " ");
                }
                Console.WriteLine("child thread completed ");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("thread abort exception");
            }

            finally
            {
                Console.WriteLine();
                Console.WriteLine("this is finaly block");
            }
        }
            
        public static void thread2()
        {
            Console.WriteLine("thread 2 starts working :");
        }
        */
        public static void Main()
        {

            /* double d = 2.34;
             int n = (int)d;
             Type t = n.GetType();
             Console.WriteLine(n);
             Console.WriteLine(t);

             string s = "124";
             int sn = int.Parse(s);
             Console.WriteLine(sn * 12);

             // Convert 
             string str = Convert.ToString(sn);
             Console.WriteLine(str);

             double dd = Convert.ToDouble(sn);
             Console.WriteLine(sn);

             bool b = Convert.ToBoolean(sn);
             Console.WriteLine("convert to boolean : " + b);

             // struct 
             employee emp = new employee(5,"bhaveen");
             Console.WriteLine(emp.id);
             Console.WriteLine(emp.str);

             // new1 class 
             new1 emm = new new1();
             emm.name = "bhaveen";
             Console.WriteLine("name is :" + emm.name);

             new1 emm2 = emm;
             emm2.name = "bhavan";
             Console.WriteLine("name is :" + emm.name);
             string str1 = "bhaveen";
             string str2 = "bhavan";
             string str3 = string.Concat(str1, str2);
             Console.WriteLine(str3);
             Boolean b1 = str1.Equals(str3);
             Console.WriteLine(b1);
 */
            /*
                        int i = 10;
                        Boolean res = i.greaterthan(100);
                        string rev = "bhaveen";
                        string ans = rev.reversing();
                        Console.WriteLine("actual string  :" + rev);
                        Console.WriteLine("after revresing using IExtension method :" + ans);




                        int x, y, z;
                        Console.WriteLine("ENTER TWO INTEGER NUMBERS:");
                        x = int.Parse(Console.ReadLine());
                        y = int.Parse(Console.ReadLine());
                        try
                        {
                            if (y % 2 > 0)
                            {
                                //OddNumberException ONE = new OddNumberException();
                                //throw ONE;
                                throw new OddNumberException();
                            }
                            z = x / y;
                            Console.WriteLine(z);
                        }
                        catch (OddNumberException one)
                        {
                            Console.WriteLine(one.Message);
                        }
                        Console.WriteLine("End of the program");
                        Console.ReadKey();
                    }


                    // p1 
                    List<int> intlist = new List<int> { 2, 4, 3, 1, 11, 9, 5 };
                    */

            /* ThreadStart childref = new ThreadStart(calltochildthread);
             Console.WriteLine("something in main");
             Thread th = new Thread(childref);


             Console.WriteLine("checking fastness b/w child thread and in main");
             Console.WriteLine("Aborting the child thread");
             //  th.Abort();

             ThreadStart childref2 = new ThreadStart(thread2);
             Thread th2 = new Thread(thread2);
             th.Start();
             // th.Join();
             th2.Start();
             Console.ReadKey();*/

            String[] names = { "bhaveen", "bhavan", "shivam", "vamsi", "tarun", "venkat","abdul","amar" };

            // UsingLinqExtensions(names);
            //  UsingLinqFunctions(names);
            // UsingAnonomyousFunctions(names);
            // usingLinqExample(names);
            LINQReadXML();
        }

       /* public static void usingLinq(string[] names)
        {
            IEnumerable<string> query = from i in names
                                        where i.Length == 6
                                        orderby i
                                        select i.ToUpper();
            foreach(string s in query)
            {
                Console.WriteLine(s);
            }*/

        public static void UsingLinqExtensions(string[] names)
        {
            IEnumerable<string> query = names
                                        .Where(s => s.Length == 6)
                                        .OrderBy(s => s)
                                        .Select(s => s.ToUpper());
            foreach (string s in query)
            {
                Console.WriteLine(s);
            }
        }

        public static void UsingLinqFunctions(string[] names)
        {
            Func<string, bool> filter = s => s.Length == 6;
            Func<string, string> extract = s => s;
            Func<string,string> project = s => s.ToUpper();

            IEnumerable<string> query = names.Where(filter)
                                             .OrderBy(extract)
                                             .Select(project);
            foreach (string s in query)
            {
                Console.WriteLine(s);
            }

        }

        public static void UsingAnonomyousFunctions(string[] names)
        {
            Func<string, bool> filter = delegate (string s)
            {
                return s.Length == 6;
            };
            Func<string, string> extract = delegate (string s)
            {
                return s;
            };
            Func<string, string> project = delegate (string s)
             {
                 return s.ToUpper();
             };

            IEnumerable<string> query = names.Where(filter)
                                            .OrderBy(extract)
                                            .Select(project);
            foreach (string s in query)
            {
                Console.WriteLine(s);
            }

        }

        public static void usingLinqExample(string[] names)
        {
            IEnumerable<string> answer = names
                                         .Where(s =>  s.StartsWith('A') || s.StartsWith('a'))
                                         .OrderBy(s => s);
                                         
            foreach (string s in answer)
            {
                Console.WriteLine(s);
            }


        }
        public static void LINQReadXML()
        {
            string myxml = @"<Departments>
                       <Department>Account</Department>
                       <Department>Sales</Department>
                       <Department>Pre-Sales</Department>
                       <Department>Marketing</Department>
                       </Departments>";

            XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(myxml);

            xdoc.Element("Departments").Add(new XElement("Department", "Finanace"));

           foreach(XElement item in xdoc.Descendants())
            {
                Console.WriteLine("Departments - " + item.Value);
            }

            xdoc.Descendants().Where(s => s.Value == "Sales").Remove();

            Console.WriteLine("after removing sales from xml string");
            var result = xdoc.Element("Departments").Descendants();

            Console.WriteLine();
            foreach (XElement item in result)
            {
                Console.WriteLine("Departments - " + item.Value);

            }

            Console.ReadKey();





        }





        }






        public class OddNumberException : Exception
        {
            //Overriding the Message property
            public override string Message
            {
                get
                {
                    return "divisor cannot be odd number";
                }
            }
        }




        struct employee
        {
            public int id;
            public string str;
            public void getid(int x)
            {
                Console.WriteLine("value :" + x);
            }

            public employee(int x, string name)
            {
                id = x;
                str = name;
            }

        }
    
    }
