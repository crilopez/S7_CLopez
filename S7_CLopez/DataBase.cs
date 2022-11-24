using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace S7_CLopez
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();


    }
}
