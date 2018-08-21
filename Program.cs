using System;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
namespace sqlTest
{
    class Program
    {
        static String pass;
        static String database;

        static MySqlConnection conn;
        public static void Main(string[] args)
        {

            Console.WriteLine("choose(1.database read 2.database write)");
            int i = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("please insert password");
            pass = Console.ReadLine();

            switch (i)
            {
                case 1:
                    conn = connection();
                    
                    String SQL = sqlInsert.sqlInsert1();
                    
                    resultCmp.resultOut(SQL, conn);
                    
                    break;
                case 2:
                    Console.WriteLine("please insert database");
                    database = Console.ReadLine();
                    
                    conn = connection2();
                    
                    sqlInsert.sqlInsert2(conn);
                    
                    break;
            }

        }

        public static MySqlConnection connection()
        {

            String connString = "";

            connString = "server=localhost;port=3306;uid=root;database=world;charset=utf8;SslMode=None;pwd=" + pass + ";";

            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("can't connect to database");
                        break;

                    case 1045:
                        Console.WriteLine("id or password error");
                        break;

                    default:
                        Console.WriteLine("error " + ex.Number + ": " + ex.Message);
                        break;
                }
            }
            return conn;
        }

        public static MySqlConnection connection2()
        {
            String connString = "";

            connString = "server=localhost;port=3306;uid=root;database=" + database + ";charset=utf8;SslMode=None;pwd=" + pass + ";";

            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("can't connect to database");
                        break;

                    case 1045:
                        Console.WriteLine("id or password error");
                        break;

                    default:
                        Console.WriteLine("error " + ex.Number + ": " + ex.Message);
                        break;
                }
            }
            return conn;
        }
    }
}