using System;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace sqlTest
{
    public class sqlInsert
    {
        static String SQL;
        static Boolean determine;/*判斷是否正確的變數*/
        public static String sqlInsert1()/*output interface*/
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

            SQL = sqlInsertCmp.cmp(coloum, table, where, orderBy);

            Console.WriteLine(SQL);

            return SQL;
        }

        public static void sqlInsert2(MySqlConnection conn)/*input interface*/
        {
            Console.WriteLine("1.create table 2.insert data");
            int i = Convert.ToInt32(Console.ReadLine());

            switch (i)
            {
                case 1:
                    creTable(conn);/*先創建table與欄位再輸入內容 */
                    insData(conn);
                    break;

                case 2:
                    insData(conn);/*直接輸入內容*/
                    break;
            }

        }

        public static String creTable(MySqlConnection conn)/*create table */
        {

            Console.WriteLine("please write table name");
            String tablename = Console.ReadLine();

            Console.WriteLine("please write coloum amount");
            int amount = Convert.ToInt32(Console.ReadLine());

            SQL = sqlInsertCmp.cmp(tablename, amount);

            Console.WriteLine(SQL);
            Console.WriteLine("data correct?/*true=continue false=try again");
            determine = Convert.ToBoolean(Console.ReadLine());

            switch (determine)
            {
                case true:/*go to next*/
                    resultCmp.resultIn(SQL, conn);
                    break;
                case false:
                    creTable(conn);/*return set coloum*/
                    break;
            }

            return SQL;

        }

        public static void insData(MySqlConnection conn)
        {


            return SQL;
        }

    }
}