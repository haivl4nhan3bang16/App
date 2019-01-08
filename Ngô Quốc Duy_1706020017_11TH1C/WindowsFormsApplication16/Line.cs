using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication16
{
    class Line : Hinh
    {
        public Diem str = new Diem();
        public Diem end = new Diem();
        public Line()
        {
            str = new Diem(0, 0);
            end = new Diem(0, 0);
        }
        public Line(Diem A, Diem B)
        {
            str = A;
            end = B;
        }
        public void Draw(Graphics g, Pen pen)
        {
            foreach (var item in diem)
            {
                for (int i = 0; i < diem.Count - 1; i += 2)
                {
                    g.DrawLine(pen, diem[i].x, diem[i].y, diem[i + 1].x, diem[i + 1].y);
                }
            }
        }
        public void AddPoint()
        {
            try
            {
                diem.Add(str);
                diem.Add(end);
            }
            catch
            {

            }
        }
    }
}
