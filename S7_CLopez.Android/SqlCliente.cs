using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using S7_CLopez.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SqlCliente))]
namespace S7_CLopez.Droid
{
    public class SqlCliente : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var DocumenthPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(DocumenthPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}