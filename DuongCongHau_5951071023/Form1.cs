using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DuongCongHau_5951071023
{
    public partial class Form1 : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RJ5ATGR\SQLEXPRESS;Initial Catalog=DemoCRUD;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
            GetStudentsRecord();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentsRecord();
        }
        private void GetStudentsRecord()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentsTb", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            StudentRecordData.DataSource = dt;



        }
        private bool IsValidData()
        {
            if (txtNName.Text == string.Empty || txtRoll.Text == string.Empty || txtAddress.Text == string.Empty || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtHName.Text))
            {
                MessageBox.Show("Có chỗ chưa nhập dữ liệu", "Lỗ dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            return true;
        }
        public int StudentID;
        private void StudentRecordData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentID = Convert.ToInt32(StudentRecordData.Rows[0].Cells[0].Value);
            txtHName.Text = StudentRecordData.SelectedRows[0].Cells[1].Value.ToString();
            txtNName.Text = StudentRecordData.SelectedRows[0].Cells[2].Value.ToString();
            txtAddress.Text = StudentRecordData.SelectedRows[0].Cells[3].Value.ToString();
            txtPhone.Text = StudentRecordData.SelectedRows[0].Cells[4].Value.ToString();
            txtRoll.Text = StudentRecordData.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void ADDButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT into StudentsTb VALUES" + "(@Name,@FatherName,@RollNumber,@Address,@Mobile)", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtHName.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtNName.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtRoll.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtPhone.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();
            }
        }

        private void txtRoll_TextChanged(object sender, EventArgs e)
        {

        }


        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (StudentID > 0)
            {
                con.Open();


                SqlCommand cmd = new SqlCommand("UPDATE StudentsTb SET" + " Name=(@Name,FatherName=@FatherName," + "RollNumber=@RollNumber,Address=@Address," + "Mobile=@Mobile WHERE StudentID=@ID)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtHName.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtNName.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtRoll.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtPhone.Text);
                cmd.Parameters.AddWithValue("@ID", this.StudentID);

               
                cmd.ExecuteNonQuery();
                con.Close();

                GetStudentsRecord();
            }
            else {
                MessageBox.Show("Cập nhật bị lỗi!!!", "lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (StudentID > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE * FROM StudentsTb WHERE StudentID=@ID)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.StudentID);
                
                con.Close();
                cmd.ExecuteNonQuery();
                GetStudentsRecord();
            }
            else
            {
                MessageBox.Show("Cập nhật bị lỗi!!!", "lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ffd(object sender, EventArgs e)
        {

        }
    }
}

