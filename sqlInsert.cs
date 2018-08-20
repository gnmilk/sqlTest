using System;

namespace sqlTest
{
    public class sqlInsert
    {
        static String SQL;
        
        public static String sqlInsert1()
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

        public static String sqlInsert2()
        {
            Console.WriteLine("1.create table 2.insert data");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    SQL = creTable();
                    break;

                case 2:
                    SQL = insData();
                    break;
            }


            SQL = sqlInsertCmp.cmp(coloum, table, where, orderBy);

            Console.WriteLine(SQL);

            return SQL;
        }


        public static String creTable()
        {
            
            
            return SQL;
        }

        public static String insData()
        {
            

            return SQL;
        }

    }
}