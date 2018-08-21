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
        static String table;
        public static void Main(string[] args)
        {

            MySqlConnection conn;
            Console.WriteLine("choose(1.database read 2.database write)");
            int i = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("please insert password");
            pass = Console.ReadLine();

            switch (i)
            {
                case 1:
                    conn = connection(i);
                    String SQL = sqlInsert.sqlInsert1();
                    resultCmp.resultOut(SQL, conn);
                    break;
                case 2:
                    Console.WriteLine("please insert database");
                    table = Console.ReadLine();
                    conn = connection(i);
                    SQL = sqlInsert.sqlInsert2();
                    break;
            }

        }

        public static MySqlConnection connection(int i)
        {

            String connString = "";

            if (i == 1)
                connString = "server=localhost;port=3306;uid=root;database=world;charset=utf8;SslMode=None;pwd=" + pass + ";";
            else if (i == 2)
            {
                String database = Console.ReadLine();
                connString = "server=localhost;port=3306;uid=root;database=test;charset=utf8;SslMode=None;pwd=" + pass + ";";
            }
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