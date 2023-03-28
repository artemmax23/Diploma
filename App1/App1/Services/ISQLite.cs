using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Services
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
