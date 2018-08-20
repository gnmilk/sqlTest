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
        public static void Main(string[] args)
        {

            MySqlConnection conn = connection();

            String SQL = sqlInsert();

            result(SQL, conn);

        }

        public static MySqlConnection connection()
        {
            Console.WriteLine("please insert password");
            String pass = Console.ReadLine();
            String connString = "server=localhost;port=3306;uid=root;database=world;charset=utf8;SslMode=None;pwd=" + pass + ";";

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