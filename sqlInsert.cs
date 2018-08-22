using System;
using System.Collections;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace sqlTest
{
    public class sqlInsert
    {
        static string SQL;
        static Boolean determine;/*判斷是否正確的變數*/

        static string tablename;

        static ArrayList tableColumn = new ArrayList();
        public static string sqlInsert1()/*output interface*/
        {
            Console.WriteLine("Please insert coloum");
            string coloum = Console.ReadLine();

            Console.WriteLine("Please insert table");
            string table = Console.ReadLine();

            Console.WriteLine("Please insert serach rule /*null=0");

            string where = Console.ReadLine();


            Console.WriteLine("Please insert sort rule /*null=0");
            string orderBy = Console.ReadLine();


            sqlInsertCmp sqlInsertCmp = new sqlInsertCmp();

            SQL = sqlInsertCmp.cmp(coloum, table, where, orderBy);

            Console.WriteLine(SQL);

            return SQL;
        }

        public static void sqlInsert2(MySqlConnection conn)/*input interface*/
        {
            Console.WriteLine("1.create table 2.insert data");
            int i = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("please write table name");
            tablename = Console.ReadLine();

            switch (i)
            {
                /*先創建table與欄位再輸入內容 */
                case 1:
                    creTable(conn);
                    insData(conn);
                    break;

                /*直接輸入內容*/
                case 2:
                    insData(conn);
                    break;
            }

        }

        public static string creTable(MySqlConnection conn)/*create table */
        {

            Console.WriteLine("please write coloum amount");
            int amount = Convert.ToInt32(Console.ReadLine());

            SQL = sqlInsertCmp.cmpCreTable(tablename, amount);

            /*輸入資料檢查*/
            Console.WriteLine(SQL);
            Console.WriteLine("data correct?/*true=continue false=try again");
            determine = Convert.ToBoolean(Console.ReadLine());

            switch (determine)
            {
                case true:/*載入輸入的 table SQL碼*/
                    resultCmp.resultIn(SQL, conn);
                    break;
                case false:
                    creTable(conn);/*重新創建 table*/
                    break;
            }

            return SQL;

        }

        public static ArrayList catchTabColumn(MySqlConnection conn)
        {
            SQL = sqlInsertCmp.cmpColumnName(tablename);

            Console.WriteLine("debugCodeView");
            Console.WriteLine(SQL);

            return tableColumn = resultCmp.resultConec(SQL, conn);
        }
        public static void insData(MySqlConnection conn)
        {
            SQL = sqlInsertCmp.cmpInsData(tablename, conn);
        }
    }
}