using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLCSharp
{
    public partial class Updates : Form
    {

        public Updates()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-ELCAD05P\SQLEXPRESS;Initial Catalog=Session2;Integrated Security=True");

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Update_Load(object sender, EventArgs e)
        {
            Refresh();
        }
        public void Refresh()
        {
            labelFrom.Text = Edits.from;
            labelTo.Text = Edits.to;
            labelAircraft.Text = Edits.air;
            mtbDate.Text =Outbound( Edits.date.ToString());
            mtbTime.Text = Edits.time.ToString();
            txtPrice.Text = Edits.economyprice.ToString();
        }
        private String Outbound(String s)
        {
            int c = s.IndexOf("/");
            int c1 = s.LastIndexOf("/");
            String s2 = s.Substring(c + 1, c1 - 2) + s.Substring(0, c + 1) + s.Substring(6, 4);
            return s2;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String sql = "UPDATE [dbo].[Schedules] set date=@date,time=@time,EconomyPrice=@economyprice WHERE ID=@id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("date", Outbound( mtbDate.Text));
            cmd.Parameters.AddWithValue("time", mtbTime.Text);
            cmd.Parameters.AddWithValue("economyprice", txtPrice.Text);
            cmd.Parameters.AddWithValue("id", Edits.ID);
            
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công! ");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại! \n Vui lòng kiểm tra lại thời gian mà bạn muốn cập nhật");
            }
            
            con.Close();
            

        }

    }
}
