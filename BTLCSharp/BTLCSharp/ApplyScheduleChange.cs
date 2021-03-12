using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BTLCSharp
{
    public partial class ApplyScheduleChange : Form
    {
        SqlConnection con;

        public ApplyScheduleChange()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Hàm truy cập file có sẵn trên máy tính
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            openFileDialog1.FileName = "Select a text file";
            openFileDialog1.Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*";
           // openFileDialog1.Title = "Open text file";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                btnImport.Enabled = true;
                txtSelect.Text = openFileDialog1.FileName;

            }
            else 
            {
                btnImport.Enabled = false;
                txtSelect.Text = "";
            }
        }

        private void ApplyScheduleChange_Load(object sender, EventArgs e)
        {
            String conString = @"Data Source=LAPTOP-ELCAD05P\SQLEXPRESS;Initial Catalog=Session2;Integrated Security=True";
            con = new SqlConnection(conString);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            loadData();
            selectRouter();
            ADD_EDIT();

        }
        DataTable dt;
        DataTable routeDT;
        DataTable checkDT;
        // Load dữ liệu từ file excel lên dataTable
        private void loadData()
        {
            dt = new DataTable();
            string[] data = System.IO.File.ReadAllLines(txtSelect.Text);
            string[] data1 = null;
            int x = 0;
            foreach (String text in data)
            {
                data1 = text.Split(',');
                if (x == 0)
                {
                    for (int i = 0; i < data1.Count(); i++)
                    {
                        dt.Columns.Add(data1[i]);
                        x++;
                    }
                }
                dt.Rows.Add(data1);

            } 
        }
        Change change;
        // Thêm sửa dữ liệu vào database
        private void ADD_EDIT()
        {
            String sql = "INSERT INTO [dbo].[Schedules](Date,Time,AircraftID,RouteID,EconomyPrice,Confirmed,FlightNumber) VALUES(@date,@time,@aircraftID,@routeID,@economyPrice,@confirmed,@flightNumber)";
            String sqlUpdate = "UPDATE [dbo].[Schedules] set Time=@time,AircraftID=@aircraftID, RouteID=@routeID,EconomyPrice=@economyPrice,Confirmed=@confirmed where Date=@date and FlightNumber=@flightNumber";
            SqlCommand cmd;         
            change = new Change();
            int duplicate = 0;
            int missing = 0;
            int add = 0;
            for (int i = 0; i < dt.Rows.Count ; i++)
            {
                if (dt.Rows[i][0].ToString().Equals("ADD"))
                {
                    cmd = new SqlCommand(sql, con);
                }
                else { cmd = new SqlCommand(sqlUpdate, con);                    
                }                  
                    try
                    {
                        if(dt.Rows[i][1].ToString().Equals("")|| dt.Rows[i][2].ToString().Equals("") || dt.Rows[i][3].ToString().Equals("") || dt.Rows[i][4].ToString().Equals("") || dt.Rows[i][5].ToString().Equals("") || dt.Rows[i][7].ToString().Equals("") || dt.Rows[i][8].ToString().Equals("")|| dt.Rows[i][6].ToString().Equals(""))
                        {
                            missing++;
                        }
                        else { 
                        change.id = 0;
                        change.date = DateTime.Parse(dt.Rows[i][1].ToString());
                        change.time = TimeSpan.Parse(dt.Rows[i][2].ToString());
                        change.flightNumber = int.Parse(dt.Rows[i][3].ToString());
                        change.from = dt.Rows[i][4].ToString();
                        change.to = dt.Rows[i][5].ToString();
                        change.economyPrice = decimal.Parse(dt.Rows[i][7].ToString());
                        if (dt.Rows[i][8].ToString().Equals("OK"))
                        {
                            change.confirmed = 1;
                        }
                        else
                        {
                            change.confirmed = 0;
                        }
                        change.airCode = int.Parse(dt.Rows[i][6].ToString());
                        change.id = -1;
                        for (int j = 0; j < routeDT.Rows.Count; j++)
                        {                           
                            if (change.from.Equals(routeDT.Rows[j]["froms"].ToString()) && change.to.Equals(routeDT.Rows[j]["tos"].ToString()))
                            {
                                change.id = int.Parse(routeDT.Rows[j]["ID"].ToString());
                                break;

                            }
                            
                        }
                        if (change.id == -1)
                        {
                            missing++;
                        }
                        try
                        {
                            if (dt.Rows[i][0].ToString().Equals("ADD"))
                            {
                                if (check(change.date, change.flightNumber))
                                {
                                    cmd.Parameters.AddWithValue("date", change.date);
                                    cmd.Parameters.AddWithValue("time", change.time);
                                    cmd.Parameters.AddWithValue("aircraftID", change.airCode);
                                    cmd.Parameters.AddWithValue("routeID", change.id);
                                    cmd.Parameters.AddWithValue("economyPrice", change.economyPrice);
                                    cmd.Parameters.AddWithValue("confirmed", change.confirmed);
                                    cmd.Parameters.AddWithValue("flightNumber", change.flightNumber);

                                }
                                else
                                {
                                    duplicate++;
                                    // MessageBox.Show(i.ToString());                                           
                                    continue;
                                }
                            }
                            else
                            {
                                if (!check(change.date, change.flightNumber))
                                {
                                    cmd.Parameters.AddWithValue("date", change.date);
                                    cmd.Parameters.AddWithValue("time", change.time);
                                    cmd.Parameters.AddWithValue("aircraftID", change.airCode);
                                    cmd.Parameters.AddWithValue("routeID", change.id);
                                    cmd.Parameters.AddWithValue("economyPrice", change.economyPrice);
                                    cmd.Parameters.AddWithValue("confirmed", change.confirmed);
                                    cmd.Parameters.AddWithValue("flightNumber", change.flightNumber);

                                }
                                else
                                {
                                    missing++;
                                }
                            }
                            con.Open();

                            cmd.ExecuteNonQuery();

                          
                                add++;
                            


                            con.Close();
                            //MessageBox.Show(add.ToString());

                        }
                        catch { }

                    }
                       // if(j== routeDT.Rows.Count - 1)
                       // {
                       // count++;
                       // }

                    }
                    catch
                    {
                        missing++;
                    }

            }

            lblDuplicate.Text = duplicate.ToString();
            lblRecord.Text = missing.ToString();
            lblChange.Text = add.ToString();
           // MessageBox.Show("Số bản ghi không thêm do sai định dạng: " + count);

        }
        // Kiểm tra date và flightNumber xem có trùng nhau không
        private Boolean check(DateTime date, int flightNumber)
        {
            con.Close();
            con.Open();
            String sql = "SELECT Date,FlightNumber FROM [dbo].[Schedules]";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            checkDT = new DataTable();
            checkDT.Load(dr);
            con.Close();
            for (int i = 0; i < checkDT.Rows.Count ; i++)
            {
                if (date.ToString().Equals(checkDT.Rows[i]["Date"].ToString()) && flightNumber.ToString().Equals(checkDT.Rows[i]["FlightNumber"].ToString()))
                {
                    return false;
                }
            }
            return true;
        }
        // load dữ liệu từ bảng Routes lên datatable RouteDT
        private void selectRouter()
        {
            con.Close();
            con.Open();
            String sql = "select r.ID,a.IATACode as froms,ai.IATACode as tos from [dbo].Airports a join [dbo].Routes r on a.ID=r.DepartureAirportID join[dbo].Airports ai on ai.ID = r.ArrivalAirportID ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            routeDT = new DataTable();
            routeDT.Load(dr);
            con.Close();
        }
    }
}
