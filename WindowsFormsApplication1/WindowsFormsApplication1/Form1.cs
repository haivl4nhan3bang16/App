using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pad
{
    public partial class Form1 : Form
    {
        string FilePath = ""; //tạo đường dẫn lưu hoặc mở tập tin
        int iCheck = 0; //tạo biến kiểm tra đã lưu hay chưa trước khi 
                        //thoát hay tạo mới
                        //0: chưa lưu
                        //giá trị khác (thường là 1): đã lưu

        public Form1()
        {
            InitializeComponent();
        }
        //menu item thoát
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iCheck == 0) //nếu chưa lưu
            {
                DialogResult Result2 = MessageBox.Show("Bạn có muốn lưu lại trước khi thoát ?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                //hỏi có muốn lưu hay không
                if (Result2 == DialogResult.Yes) //nếu muốn lưu
                {
                    if (FilePath.Equals("")) //nếu chưa có đường dẫn
                    {
                        DialogResult resVal = saveFileDialog.ShowDialog();
                        //tạo một biến kết quả từ việc lưu tập tin,
                        //nếu lưu trùng tập tin cũ thì
                        //hệ điều hành sẽ báo, lúc đó chọn Replace hay Cancel
                        //hay khi lưu thì cũng sẽ có 2 nút là Save và Cancel
                        if (resVal == DialogResult.Cancel) //nếu chọn Cancel
                        {
                            return; //trả về (rời khỏi sự kiện Thoát)
                        }

                        FilePath = saveFileDialog.FileName; //nếu không chọn Cancel
                        //thì lưu đường dẫn vào biến
                        try //thử
                        {
                            rtBox.SaveFile(FilePath); //lưu tập tin từ RichTextBox
                                                      //[file.rtf (Rich Text Format)]
                        }
                        catch (Exception Ex) //nếu có trường hợp ngoại lệ
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                            //thông báo lổi, rời khỏi sự kiện
                        }
                    }
                    else //nếu đã có đường dẫn
                    {
                        //tiền hành lưu tập tin mà không cần chọn đường dẫn
                        try
                        {
                            rtBox.SaveFile(FilePath); //lưu tập tin
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }

                    Application.Exit(); //thoát chương trình
                }
                else if (Result2 == DialogResult.No) //nếu không muốn lưu 
                                                     //trước khi thoát
                {
                    Application.Exit(); //thoát
                }
                else //nếu chọn nút thứ 3 (Cancel)
                {
                    return; //trả về, không lưu gì cả
                }
            }
            else //nếu đã lưu rồi
            {
                Application.Exit(); //thoát
            }
        }
        //menu item Mới
        private void mớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iCheck == 0) //nếu chưa lưu
            {
                DialogResult Result2 = MessageBox.Show("Bạn có muốn lưu lại trước khi tạo mới ?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                //tạo một biến kết quả trả về từ MessageBox
                if (Result2 == DialogResult.Yes) //nếu chọn Yes
                {
                    //tương tự menu item Thoát
                    if (FilePath.Equals(""))
                    {
                        DialogResult resVal = saveFileDialog.ShowDialog();
                        if (resVal == DialogResult.Cancel)
                        {
                            return;
                        }
                        FilePath = saveFileDialog.FileName;

                        try
                        {
                            rtBox.SaveFile(FilePath);
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    else
                    {
                        try
                        {
                            rtBox.SaveFile(FilePath);
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }

                    rtBox.Text = ""; //tạo mới
                }
                else if (Result2 == DialogResult.No)
                {
                    rtBox.Text = ""; //tạo mới
                }
                else
                {
                    return; //rời khỏi sự kiện
                }
            }
            else //nếu đã lưu
            {
                rtBox.Text = ""; //tạo mới
            }
        }
        //menu item Mở
        private void mởToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iCheck == 0) //nếu chưa lưu
            {
                DialogResult Result2 = MessageBox.Show("Bạn có muốn lưu lại trước khi tạo mới ?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                //tạo một biến kết quả trả về từ MessageBox
                if (Result2 == DialogResult.Yes) //nếu chọn Yes
                {
                    //tương tự menu item Thoát
                    if (FilePath.Equals(""))
                    {
                        DialogResult resVal = saveFileDialog.ShowDialog();
                        if (resVal == DialogResult.Cancel)
                        {
                            return;
                        }
                        FilePath = saveFileDialog.FileName;

                        try
                        {
                            rtBox.SaveFile(FilePath);
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    else
                    {
                        try
                        {
                            rtBox.SaveFile(FilePath);
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }

                    DialogResult Result = openFileDialog.ShowDialog();
                    //tạo một biến kết quả từ việc mở tập tin
                    //lúc đó hộp thoại mở tập tin sẽ có 2 nút là Open và Cancel
                    if (Result == DialogResult.Cancel) //nếu chọn Cancel
                    {
                        return; //rời khỏi sự kiện
                    }
                    else //hoặc chọn mở
                    {
                        try //thử
                        {
                            FilePath = openFileDialog.FileName; //lưu đường dẫn tập tin
                            //vào FilePath
                            rtBox.LoadFile(FilePath); //tải tập tin từ đường dẫn
                            //FilePath lên
                        }
                        catch (Exception Ex) //nếu có ngoại lệ
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //thông báo lổi
                        }
                    }
                }
                else if (Result2 == DialogResult.No)
                {
                    DialogResult Result = openFileDialog.ShowDialog();
                    //tạo một biến kết quả từ việc mở tập tin
                    //lúc đó hộp thoại mở tập tin sẽ có 2 nút là Open và Cancel
                    if (Result == DialogResult.Cancel) //nếu chọn Cancel
                    {
                        return; //rời khỏi sự kiện
                    }
                    else //hoặc chọn mở
                    {
                        try //thử
                        {
                            FilePath = openFileDialog.FileName; //lưu đường dẫn tập tin
                            //vào FilePath
                            rtBox.LoadFile(FilePath); //tải tập tin từ đường dẫn
                            //FilePath lên
                        }
                        catch (Exception Ex) //nếu có ngoại lệ
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //thông báo lổi
                        }
                    }
                }
                else
                {
                    return; //rời khỏi sự kiện
                }
            }
            else //nếu đã lưu
            {
                DialogResult Result = openFileDialog.ShowDialog();
                //tạo một biến kết quả từ việc mở tập tin
                //lúc đó hộp thoại mở tập tin sẽ có 2 nút là Open và Cancel
                if (Result == DialogResult.Cancel) //nếu chọn Cancel
                {
                    return; //rời khỏi sự kiện
                }
                else //hoặc chọn mở
                {
                    try //thử
                    {
                        FilePath = openFileDialog.FileName; //lưu đường dẫn tập tin
                        //vào FilePath
                        rtBox.LoadFile(FilePath); //tải tập tin từ đường dẫn
                        //FilePath lên
                    }
                    catch (Exception Ex) //nếu có ngoại lệ
                    {
                        MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //thông báo lổi
                    }
                }
            }
        }
        //menu item Lưu
        private void lưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tương tự như trên (menu item Thoát)
            if (FilePath.Equals(""))
            {
                DialogResult resVal = saveFileDialog.ShowDialog();
                if (resVal == DialogResult.Cancel)
                {
                    return;
                }
                FilePath = saveFileDialog.FileName;

                try
                {
                    rtBox.SaveFile(FilePath);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            else
            {
                try
                {
                    rtBox.SaveFile(FilePath);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            iCheck = 1; //đặt lại biến kiểm tra, lúc nào biến kiểm tra sẽ ở 
                        //trạng thái "đã lưu tập tin"
        }
        //menu item Lưu là (Save as)
        private void lưuLàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //giống như trên nhưng không cần biết đã lưu tập tin hay chưa
            DialogResult Result = saveFileDialog.ShowDialog();

            if (Result == DialogResult.Cancel)
            {
                return;
            }

            FilePath = saveFileDialog.FileName;

            try
            {
                rtBox.SaveFile(FilePath);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            iCheck = 1; //đặt lại trạng thái cho biến kiểm tra việc lưu
        }
        //menu item Không làm
        private void khôngLaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtBox.Undo(); //gọi phương thức Undo
        }
        //menu item Cắt
        private void saoChépToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtBox.Cut(); //gọi phương thức Cut
        }
        //menu item Sao chép
        private void saoChépToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rtBox.Copy(); //gọi phương thức Copy
        }
        //menu item Dán
        private void dánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtBox.Paste(); //gọi phương thức Paste
        }
        //menu item Xóa phần đã chọn
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtBox.SelectedText = ""; //gán giá trị rỗng cho phần đã chọn
        }
        //menu item Chọn hết
        private void chọnHếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtBox.SelectAll(); //gọi phương thức SelectAll
        }
        //menu item Chèn ngày
        private void chènNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strCurrText = rtBox.Text; //lưu nội dung đang có trong RTBox
            rtBox.Text = strCurrText + "\r\n" + DateTime.Now.ToString();
            //đặt lại nội dung cho RTBox là nội dung cũ + xuống dòng + ngày giờ
        }
        //menu item Phông (Font)
        private void phôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.Font = rtBox.Font; //đặt Font trong hộp thoại là Font đang dùng
            fontDialog.ShowDialog(); //hiện hộp thoại chọn Font
            rtBox.SelectionFont = fontDialog.Font; //đặt lại Font             
        }
        //nếu có thay đổi kí tự trong RTBox
        private void rtBox_TextChanged(object sender, EventArgs e)
        {
            iCheck = 0; //đặt lại biến trạng thái lưu thành "chưa lưu"

            if (iCheck == 0) //nếu chưa được lưu
            {
                this.Text = "Wordpad *"; //đặt tiêu đề cho Form chính có dấu *
            }
            else //nếu đã được lưu
            {
                this.Text = "Wordpad"; //đặt tiêu đề trở lại bình thường
            }

            int iDemDong = rtBox.GetLineFromCharIndex(rtBox.SelectionStart) + 1;
            //lấy số dòng hiện tại
            TSL_Dong.Text = iDemDong.ToString() + " dòng"; //đặt số dòng hiện tại 
                                                           //vào ToolStripLable Dòng

        }
        //menu item Giới thiệu
        private void giớiThiệuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 frmGioiThieu = new Form2(); //khai báo Form Giới thiệu (Form2: tự làm) 
            frmGioiThieu.Show(); //hiện Form Giới Thiệu
        }
        //menu item Giúp đở
        private void giúpĐởToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frmGiupDo = new Form3(); //khai báo Form Giúp đở
            frmGiupDo.Show(); //hiện Form Giúp đở
        }
        //ToolStrip Canh trái
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            rtBox.SelectionAlignment = HorizontalAlignment.Left; //canh trái
        }
        //ToolStrip Canh giữa
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            rtBox.SelectionAlignment = HorizontalAlignment.Center; //canh giữa
        }
        //ToolStrip Canh phải
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            rtBox.SelectionAlignment = HorizontalAlignment.Right; //canh phải
        }
        //ToolStrip Tô đậm
        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            rtBox.SelectionFont = new Font(rtBox.SelectionFont, FontStyle.Bold);
            //tô đậm
        }
        //ToolStrip In nghiêng
        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            rtBox.SelectionFont = new Font(rtBox.SelectionFont, FontStyle.Italic);
            //in nghiêng
        }
        //ToolStrip Gạch chân
        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            rtBox.SelectionFont = new Font(rtBox.SelectionFont, FontStyle.Underline);
            //gạch chân
        }
        //ToolStrip Chọn màu
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog(); //hiển thị hộp thoại chọn màu
            rtBox.SelectionColor = colorDialog.Color; //đặt lại màu
        }
        //Menu phải chuột Màu đỏ
        private void đỏToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtBox.SelectionColor = Color.Red; //đặt màu đỏ
        }
        //Menu phải chuột Màu xanh
        private void xanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtBox.SelectionColor = Color.Blue; //đặt màu xanh
        }
        //Menu phải chuột Màu đen
        private void đenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtBox.SelectionColor = Color.Black; //đặt màu đen
        }
        //ToolStrip Đánh dấu đầu câu
        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            rtBox.SelectionBullet = true; //đánh dấu
        }
        //ToolStrip Chèn hình
        private void hìnhẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Result = openFileDialog.ShowDialog();
            //khai báo biến kết quả cho việc mở tập tin
            if (Result == DialogResult.Cancel) //nếu chọn Cancel
            {
                return; //rời khỏi sự kiện
            }
            else //hoặc chọn Open
            {
                try //thử
                {
                    string ImagePath = openFileDialog.FileName; //lấy đường dẫn 
                                                                //của tập tin

                    Bitmap myBitmap = new Bitmap(ImagePath); //tạo một Bitmap

                    Clipboard.SetDataObject(myBitmap); //đặt đối tượng dử liệu vào Clipboard

                    DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    //lấy định dạng của hình
                    if (rtBox.CanPaste(myFormat)) //nếu có thể chèn vào RTBox
                    {
                        rtBox.Paste(myFormat); //chèn hình vào
                    }
                    else //nếu không thể chèn
                    {
                        MessageBox.Show("Không thể chèn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //hiển thị thông báo
                    }
                }
                catch (Exception ex) //nếu có ngoại lệ (mở tập tin không phải hình)
                {
                    MessageBox.Show(ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                    //thông báo và rời khỏi sự kiện
                }
            }
        }
        //ToolStrip Tìm kiếm
        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(); //tạo Form Tìm kiếm
            f4.ShowDialog(); //hiển thị Form Tìm kiếm            
            rtBox.Find(f4.strText); //Form Tìm kiếm sẽ trả về chuổi kí tự cẩn tìm
            //Gọi phương thức Find đễ tìm chuổi kí tự cần tìm
        }
        //ToolStrip Làm lại
        private void làmLạiHànhĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtBox.Redo(); //gọi phương thức Redo
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                rtBox.SelectionFont = new Font(rtBox.SelectionFont, FontStyle.Bold);
                //tô đậm
            }
            if (e.Control && e.KeyCode == Keys.N)
            {
                rtBox.SelectionFont = new Font(rtBox.SelectionFont, FontStyle.Italic);
                //in nghiêng
            }
            if (e.Control && e.KeyCode == Keys.G)
            {
                rtBox.SelectionFont = new Font(rtBox.SelectionFont, FontStyle.Underline);
                //gạch chân
            }
            if (e.Control && e.KeyCode == Keys.B)
            {
                rtBox.SelectionFont = new Font(rtBox.SelectionFont, FontStyle.Regular);
                //bình thường
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                //tương tự như trên (menu item Thoát)
                if (FilePath.Equals(""))
                {
                    DialogResult resVal = saveFileDialog.ShowDialog();
                    if (resVal == DialogResult.Cancel)
                    {
                        return;
                    }
                    FilePath = saveFileDialog.FileName;

                    try
                    {
                        rtBox.SaveFile(FilePath);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        rtBox.SaveFile(FilePath);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

                iCheck = 1; //đặt lại biến kiểm tra, lúc nào biến kiểm tra sẽ ở 
                //trạng thái "đã lưu tập tin"
            }
            if (e.Control && e.KeyCode == Keys.O)
            {
                if (iCheck == 0) //nếu chưa lưu
                {
                    DialogResult Result2 = MessageBox.Show("Bạn có muốn lưu lại trước khi tạo mới ?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    //tạo một biến kết quả trả về từ MessageBox
                    if (Result2 == DialogResult.Yes) //nếu chọn Yes
                    {
                        //tương tự menu item Thoát
                        if (FilePath.Equals(""))
                        {
                            DialogResult resVal = saveFileDialog.ShowDialog();
                            if (resVal == DialogResult.Cancel)
                            {
                                return;
                            }
                            FilePath = saveFileDialog.FileName;

                            try
                            {
                                rtBox.SaveFile(FilePath);
                            }
                            catch (Exception Ex)
                            {
                                MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                        else
                        {
                            try
                            {
                                rtBox.SaveFile(FilePath);
                            }
                            catch (Exception Ex)
                            {
                                MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }

                        DialogResult Result = openFileDialog.ShowDialog();
                        //tạo một biến kết quả từ việc mở tập tin
                        //lúc đó hộp thoại mở tập tin sẽ có 2 nút là Open và Cancel
                        if (Result == DialogResult.Cancel) //nếu chọn Cancel
                        {
                            return; //rời khỏi sự kiện
                        }
                        else //hoặc chọn mở
                        {
                            try //thử
                            {
                                FilePath = openFileDialog.FileName; //lưu đường dẫn tập tin
                                //vào FilePath
                                rtBox.LoadFile(FilePath); //tải tập tin từ đường dẫn
                                //FilePath lên
                            }
                            catch (Exception Ex) //nếu có ngoại lệ
                            {
                                MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //thông báo lổi
                            }
                        }
                    }
                    else if (Result2 == DialogResult.No)
                    {
                        DialogResult Result = openFileDialog.ShowDialog();
                        //tạo một biến kết quả từ việc mở tập tin
                        //lúc đó hộp thoại mở tập tin sẽ có 2 nút là Open và Cancel
                        if (Result == DialogResult.Cancel) //nếu chọn Cancel
                        {
                            return; //rời khỏi sự kiện
                        }
                        else //hoặc chọn mở
                        {
                            try //thử
                            {
                                FilePath = openFileDialog.FileName; //lưu đường dẫn tập tin
                                //vào FilePath
                                rtBox.LoadFile(FilePath); //tải tập tin từ đường dẫn
                                //FilePath lên
                            }
                            catch (Exception Ex) //nếu có ngoại lệ
                            {
                                MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //thông báo lổi
                            }
                        }
                    }
                    else
                    {
                        return; //rời khỏi sự kiện
                    }
                }
                else //nếu đã lưu
                {
                    DialogResult Result = openFileDialog.ShowDialog();
                    //tạo một biến kết quả từ việc mở tập tin
                    //lúc đó hộp thoại mở tập tin sẽ có 2 nút là Open và Cancel
                    if (Result == DialogResult.Cancel) //nếu chọn Cancel
                    {
                        return; //rời khỏi sự kiện
                    }
                    else //hoặc chọn mở
                    {
                        try //thử
                        {
                            FilePath = openFileDialog.FileName; //lưu đường dẫn tập tin
                            //vào FilePath
                            rtBox.LoadFile(FilePath); //tải tập tin từ đường dẫn
                            //FilePath lên
                        }
                        catch (Exception Ex) //nếu có ngoại lệ
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //thông báo lổi
                        }
                    }
                }
            }
            if (e.Control && e.KeyCode == Keys.M)
            {
                if (iCheck == 0) //nếu chưa lưu
                {
                    DialogResult Result2 = MessageBox.Show("Bạn có muốn lưu lại trước khi tạo mới ?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    //tạo một biến kết quả trả về từ MessageBox
                    if (Result2 == DialogResult.Yes) //nếu chọn Yes
                    {
                        //tương tự menu item Thoát
                        if (FilePath.Equals(""))
                        {
                            DialogResult resVal = saveFileDialog.ShowDialog();
                            if (resVal == DialogResult.Cancel)
                            {
                                return;
                            }
                            FilePath = saveFileDialog.FileName;

                            try
                            {
                                rtBox.SaveFile(FilePath);
                            }
                            catch (Exception Ex)
                            {
                                MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                        else
                        {
                            try
                            {
                                rtBox.SaveFile(FilePath);
                            }
                            catch (Exception Ex)
                            {
                                MessageBox.Show(Ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }

                        rtBox.Text = ""; //tạo mới
                    }
                    else if (Result2 == DialogResult.No)
                    {
                        rtBox.Text = ""; //tạo mới
                    }
                    else
                    {
                        return; //rời khỏi sự kiện
                    }
                }
                else //nếu đã lưu
                {
                    rtBox.Text = ""; //tạo mới
                }
            }
        }
        //ToolStrip chữ bình thường
        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            rtBox.SelectionFont = new Font(rtBox.SelectionFont, FontStyle.Regular);
            //bình thường
        }

        //những nút khác đăng kí chung sự kiện có sẵn
        //ví dụ: ToolStrip Mở đăng kí chung sự kiện với Menu item Mở
    }
}