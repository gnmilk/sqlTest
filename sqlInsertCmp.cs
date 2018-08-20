using System;

namespace sqlTest
{
    public class sqlInsertCmp
    {
        public static String cmp(string coloum, string table, string where, string orderBy)
        {
            String SQL = "";

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
    }
}