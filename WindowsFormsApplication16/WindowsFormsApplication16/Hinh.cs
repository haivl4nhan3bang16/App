using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication16
{

    class Hinh
    {
        public List<Diem> diem = new List<Diem>();
        public Hinh()
        {

        }
        public void Load(Dictionary<string, List<Diem>> save, string saveName)
        {
            foreach(var item in save)
            {
                if(item.Key == saveName)
                {
                    diem = item.Value;
                }
            }
        }
        public List<Diem> SaveData()
        {
            List<Diem> temp = new List<Diem>();
            temp = diem;
            return temp;
        }

    }
}
