using System;
using System.Collections;
using MySql.Data.MySqlClient;

namespace sqlTest
{
    public class sqlInsertCmp
    {

        public static string cmp(string coloum, string table, string where, string orderBy)/*read */
        {
            string SQL = "";

            if (where == "0" && orderBy == "0")
                SQL = "SELECT " + coloum + " FROM " + table + ";";
            else if (orderBy != "0" && where != "0")
                SQL = "SELECT " + coloum + " FROM " + table + " WHERE " + where + " ORDER BY " + orderBy + "[ASC];";
            else if (where == "0")
                SQL = "SELECT " + coloum + " FROM " + table + " ORDER BY " + orderBy + ";";
            else if (orderBy == "0")
                SQL = "SELECT " + coloum + " FROM " + table + " WHERE " + where + ";";

            return SQL;
        }
        public static string cmpCreTable(string tablename, int amount)/*create table & set coloum*/
        {
            string SQL = "CREATE TABLE " + tablename + " (";

            string coloumName;

            int i;

            Console.WriteLine("please insert column name");

            for (i = 0; i < amount - 1; i++)
            {
                coloumName = Console.ReadLine();
                SQL += coloumName + " char(50),";
            }

            coloumName = Console.ReadLine();
            SQL += coloumName + " char(50));";

            return SQL;
        }

        public static string cmpColumnName(string tablename)/*catch column name*/
        {
            string SQL = "SELECT column_name FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name='" + tablename + "';";

            return SQL;
        }
        public static string cmpInsData(string tablename, MySqlConnection conn)/*insert data*/
        {
            string SQL = "";
            SQL += "INSERT INTO " + tablename + "(";

            ArrayList tableColumn = sqlInsert.catchTabColumn(conn);

            int i = tableColumn.Count;
            int j = 0;

            String[] value = new string[i]; for (int x = 0; x < tableColumn.Count; x++) Console.WriteLine(tableColumn);

            while (j != i)
            {
                SQL += tableColumn[j] + ",";

                Console.WriteLine("please insert" + j + ". values");
                value[j] = Console.ReadLine();

                j++;
            }
            SQL += tableColumn[j] + ")";

            Console.WriteLine("please insert" + j + ". values");
            value[j] = Console.ReadLine();

            SQL += "VALUES (";

            for (j = 0; j < i - 1; j++)
                SQL += "'" + tableColumn[j] + "',";

            j++;
            SQL += "'" + tableColumn[j] + "');";

            Console.WriteLine(SQL);

            return SQL;
        }
    }
}