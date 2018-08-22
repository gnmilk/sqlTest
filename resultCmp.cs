using System;
using System.Collections;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace sqlTest
{
    public class resultCmp
    {
        public static void resultOut(string SQL, MySqlConnection conn)
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

        public static void resultIn(string SQL, MySqlConnection conn)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                /*conn.Close();*/
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("error " + ex.Number + ": " + ex.Message);
            }
        }

        public static ArrayList resultConec(string SQL, MySqlConnection conn)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                MySqlDataReader myData = cmd.ExecuteReader();

                ArrayList tableColumn = new ArrayList();

                while (myData.Read())
                {
                    for (int i = 0; i < myData.FieldCount; i++)
                    {
                        Console.Write(myData.GetName(i) + ":");

                        Console.Write(myData[i] + ".   ");

                        tableColumn.Add(myData[i]);
                    }

                    Console.WriteLine();
                }

                myData.Close();

                return tableColumn;

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("error " + ex.Number + ": " + ex.Message);
                return null;
            }
        }
    }
}