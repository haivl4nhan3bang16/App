using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace WindowsFormsApplication16
{
    public partial class Form1 : Form
    {
        Dictionary<string, List<Diem>> data = new Dictionary<string, List<Diem>>();
        Graphics g;
        TamGiac tg = new TamGiac();
        Pen pen = new Pen(Color.Red, 2);
        bool canDraw = false;
        Diem begin = new Diem();
        Diem end = new Diem();
        Line line = new Line();
        Rectangle rec = new Rectangle();
        bool Point, isLine, istg;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            isLine = false;
            Point = false;
        }
        new void Update()
        {
            for (int i = 0; i < line.diem.Count - 1; i += 2)
            {
                line.Draw(g, pen);
            }
            for(int i = 0; i < tg.diem.Count - 1; i += 2)
            {
                tg.Draw(g, pen);
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            isLine = true;
            Point = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Point = true;  
            isLine = false;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "json| *.json";
            save.ShowDialog();
            data.Add("line", line.SaveData());           
            StreamWriter writer = new StreamWriter(save.FileName);
            var json = JsonConvert.SerializeObject(data);
            writer.Write(json);
            writer.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Point = true;        
            isLine = false;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "json| *.json";
            open.ShowDialog();
            StreamReader reader = new StreamReader(open.FileName);
            var json = reader.ReadToEnd();
            data = JsonConvert.DeserializeObject<Dictionary<string, List<Diem>>>(json);
            line.Load(data, "line");
            reader.Close();
            Update();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Point == false)
            {
                canDraw = true;
                begin = new Diem(e.X, e.Y);
                rec.X = begin.x;
                rec.Y = begin.y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (canDraw == true)
            {
                end = new Diem(e.X, e.Y);
                g.Clear(pictureBox1.BackColor);
                if (Point == true)
                {
                    return;
                }
                else if (isLine == true)
                {
                    g.DrawLine(pen, begin.x, begin.y, e.X, e.Y);
                }
                else if (istg == true)
                {
                    rec.Size = new Size(end.x - begin.x, end.y - begin.y);
                    g.DrawEllipse(pen, rec);
                }
                Update();
            }
        }

        private void duong_Click(object sender, EventArgs e)
        {
            isLine = true;
            istg = false;
            Point = false;
        }

        private void luu_Click(object sender, EventArgs e)
        {
            try
            {
                Point = true;
                istg = false;
                isLine = false;
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "json| *.json";
                save.ShowDialog();
                data.Add("line", line.SaveData());
                data.Add("TamGiac", tg.SaveData());
                StreamWriter writer = new StreamWriter(save.FileName);
                var json = JsonConvert.SerializeObject(data);
                writer.Write(json);
                writer.Close();
            }
            catch
            {

            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            try
            {
                Point = true;
                istg = false;
                isLine = false;
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "json| *.json";
                open.ShowDialog();
                StreamReader reader = new StreamReader(open.FileName);
                var json = reader.ReadToEnd();
                data = JsonConvert.DeserializeObject<Dictionary<string, List<Diem>>>(json);
                line.Load(data, "line");
                tg.Load(data, "TamGiac");
                reader.Close();
                Update();
            }
            catch
            {

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Point = false;
            isLine = false;
            istg = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Point == false)
            {
                end.x = e.X;
                end.y = e.Y;
                canDraw = false;
                if (isLine == true)
                {
                    line.str = begin;
                    line.end = end;
                    line.AddPoint();
                }
                if (istg == true)
                {
                    line.str = begin;
                    line.end = end;
                    line.AddPoint();
                }               
            }
        }
    }
}
