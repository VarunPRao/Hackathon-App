using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;

namespace Hackathon_App
{
    class INVtrack
    {
        private static int cINV = 0;
        public static void AddtoInv(int order, DateTime dt)
        {
            cINV += order;
        }

        public static void TakefromInv(int scan, DateTime dt)
        {
            cINV -= scan;
            PutToDB(dt);
        }

        [Table("date")]
        public class stuff
        {
            [PrimaryKey, AutoIncrement, Column("inventory")]
            public int amount { get; set; }
            public DateTime date;
            public stuff(int amt, DateTime dt)
            {
                amount = amt;
                date = dt;
            }
            public stuff()
            {
                ;
            }
        }

        private static void PutToDB(DateTime dt)
        {
            //Path string for the database file
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Order_Table.db3");

            //Setup the db connection
            var db = new SQLiteConnection(dbPath);

            stuff obj = new stuff(cINV, dt);

            //Setup a table
            db.CreateTable<stuff>();

            Console.WriteLine("Object amt= {0}", obj.amount);
            //Store Object in table
            db.Insert(obj);

        }
        public static DateTime Now { get; }
        public static int function()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Order_Table.db3");
            var db = new SQLiteConnection(dbPath);

            var table = db.Table<stuff>();
            int Newnum, num = 0, count = 0;

            DateTime D2;
            foreach (var item in table)
            {	
		stuff obj = new stuff(item.amount, item.date);
		if(count == 0)
		{
			D2 = obj.date;
			++count;
		}

                num += obj.amount;
		Newnum = obj.amount;
            }

            DateTime D1 = Now;
	    int days = 0, val = 10;
            //val = num / (D2.DayOfYear - D1.DayOfYear);
	    //days = Newnum / val;
	    return days;

        }

          
    }

           
            
}           

      
