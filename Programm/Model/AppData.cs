using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programm.Model
{
    public static class AppData
    {
        public static dnevnikBDEntities db = new dnevnikBDEntities();
        public static Users currentUser;
        public static Teachers currentTeacher;
    }
}
