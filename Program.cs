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
<<<<<<< HEAD
        static String pass;
        static String table;
=======
>>>>>>> b013fd99322e9ce1593a47f4eb7e28851303e61d
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
                    result(SQL, conn);
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
<<<<<<< HEAD
=======
            
>>>>>>> b013fd99322e9ce1593a47f4eb7e28851303e61d
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

<<<<<<< HEAD
=======
        public static String sqlInsert()
        {
            Console.WriteLine("Please insert coloum");
            String coloum = Console.ReadLine();

            Console.WriteLine("Please insert table");
            String table = Console.ReadLine();

            Console.WriteLine("Please insert serach rule /*null=0");
            String where = Console.ReadLine();


            Console.WriteLine("Please insert sort rule /*null=0");
            String orderBy = Console.ReadLine();


            sqlInsertCmp sqlInsertCmp = new sqlInsertCmp();

            String SQL = sqlInsertCmp.cmp(coloum, table, where, orderBy);

            Console.WriteLine(SQL);

            return SQL;
        }

>>>>>>> b013fd99322e9ce1593a47f4eb7e28851303e61d
        public static void result(String SQL, MySqlConnection conn)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                MySqlDataReader myData = cmd.ExecuteReader();

                if (!myData.HasRows)
                {
                    Console.WriteLine("no data");
                }
                else
                {
                    while (myData.Read())
                    {
                        for (int i = 0; i < myData.FieldCount; i++)
                        {
                            Console.Write(myData.GetName(i) + ":");
                            Console.Write(myData[i] + ".   ");
                        }
                        Console.WriteLine();
                    }
                    myData.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("error " + ex.Number + ": " + ex.Message);
            }
        }
    }
}