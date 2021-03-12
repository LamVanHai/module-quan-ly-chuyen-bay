using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BTLCSharp
{
    public partial class Manage : Form
    {

        public Manage()
        {
            InitializeComponent();
        }

        SqlConnection con;
        private void Form1_Load(object sender, EventArgs e)
        {
            String conString = @"Data Source=LAPTOP-ELCAD05P\SQLEXPRESS;Initial Catalog=Session2;Integrated Security=True";
            con = new SqlConnection(conString);
            hienthiFormLoad();
            hienThiCBOFrom();
            hienThiCBOTo();
            cboSort.SelectedIndex =0;
            cboFrom.SelectedIndex = -1;
            cboTo.SelectedIndex = -1;
            DS.Columns[0].DefaultCellStyle.Format = "Custom";
            DS.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.DS.Sort(this.DS.Columns["Date"], ListSortDirection.Descending);
            btnEditFlight.Enabled = false;
            btnCancelFlight.Enabled = false;
            confirmed();
        }
        
        private String Outbound(String s)
        {           
            int c = s.IndexOf("/");
            int c1 = s.LastIndexOf("/");
            String s2 = s.Substring(c + 1, c1 - 2) +s.Substring(0, c + 1) +s.Substring(6, 4);
            return s2;         
        }

        private void hienThiCBOFrom()
        {
            con.Open();
            String sql = "Select * from [dbo].[Airports]";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();           
            dt.Load(dr);          
            cboFrom.DataSource = dt;
            cboFrom.DisplayMember = "IATACode";
            cboFrom.ValueMember = "IATACode"; 
            con.Close();

        }
        private void hienThiCBOTo()
        {
            con.Open();
            String sql = "Select * from [dbo].[Airports]";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cboTo.DataSource = dt;
            cboTo.DisplayMember = "IATACode";
            cboTo.ValueMember = "IATACode";
            con.Close();
        }
        DataTable dt;
        private void hienthiFormLoad()
        {
            
            con.Open();
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            DS.DataSource = dt;
            con.Close();
            confirmed();

        }
        private void confirmed()
        { 
            DS.Columns["ID"].Visible = false;
            DS.Columns["Confirmed"].Visible = false;
            int count = DS.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count - 1; i++)
                {

                    if (DS.Rows[i].Cells["Confirmed"].Value.ToString().Equals("False"))
                    {
                        DS.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                    }
                }
            }
        }

        private void SearchFormTo()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where ai.IATACode=@from and a.IATACode=@to";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("from", cboFrom.SelectedValue);
            cmd.Parameters.AddWithValue("to", cboTo.SelectedValue);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DS.DataSource = dt;
        }
        private void SearchFromToOutbound()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where ai.IATACode=@from and a.IATACode=@to and Date=@date";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("from", cboFrom.SelectedValue);
            cmd.Parameters.AddWithValue("to", cboTo.SelectedValue);
            cmd.Parameters.AddWithValue("Date", Outbound(mtbOutbound.Text));
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DS.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Ngày hoặc tháng bạn nhập không đúng định dạng \n Vui lòng nhập lại!");
            }
        }
        private void SearchFromToOutboundFightNumber()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where ai.IATACode=@from and a.IATACode=@to and Date=@date and FightNumber=@FightNumber";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("from", cboFrom.SelectedValue);
            cmd.Parameters.AddWithValue("to", cboTo.SelectedValue);
            cmd.Parameters.AddWithValue("Date", mtbOutbound.Text);
            cmd.Parameters.AddWithValue("FightNumber", txtFlightNumber.Text);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DS.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Ngày hoặc tháng bạn nhập không đúng định dạng \n Vui lòng nhập lại!");
            }
        }
        private void SearchFromToFightNumber()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where ai.IATACode=@from and a.IATACode=@to and FlightNumber=@FightNumber";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("from", cboFrom.SelectedValue);
            cmd.Parameters.AddWithValue("to", cboTo.SelectedValue);
            cmd.Parameters.AddWithValue("FightNumber", txtFlightNumber.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DS.DataSource = dt;
        }
        private void SearchOutbound()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where Date=@date";
            SqlCommand cmd = new SqlCommand(sql, con); 
            try
            {
                
                cmd.Parameters.AddWithValue("date",Outbound(mtbOutbound.Text));
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DS.DataSource = dt;               
            }
            catch
            {
                MessageBox.Show("Ngày hoặc tháng bạn nhập không đúng định dạng \n Vui lòng nhập lại!");
            }
        }
        private void SearchFlightNumber()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where FlightNumber=@FightNumber";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("FightNumber", txtFlightNumber.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DS.DataSource = dt;
        }
        private void SearchFrom()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where ai.IATACode=@from";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("from", cboFrom.SelectedValue);          
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DS.DataSource = dt;
        }
        private void SearchTo()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where a.IATACode=@to";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("to", cboTo.SelectedValue);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DS.DataSource = dt;
        }
        private void SearchFromOutbound()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where ai.IATACode=@from and Date=@Outbound";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("from", cboFrom.SelectedValue);
            cmd.Parameters.AddWithValue("Outbound", Outbound(mtbOutbound.Text));
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DS.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Ngày hoặc tháng bạn nhập không đúng định dạng \n Vui lòng nhập lại!");
            }
        }
        private void SearchToOutbound()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where a.IATACode=@to and Date=@Outbound";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("to", cboTo.SelectedValue);
            cmd.Parameters.AddWithValue("Outbound", Outbound(mtbOutbound.Text));
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DS.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Ngày hoặc tháng bạn nhập không đúng định dạng \n Vui lòng nhập lại!");
            }
        }
        private void SearchFromFlightNumber()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where ai.IATACode=@from and FlightNumber=@FlightNumber";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("from", cboFrom.SelectedValue);
            cmd.Parameters.AddWithValue("FlightNumber",txtFlightNumber.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DS.DataSource = dt;
        }
        private void SearchToFlightNumber()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where a.IATACode=@to and FlightNumber=@FlightNumber";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("to", cboTo.SelectedValue);
            cmd.Parameters.AddWithValue("FlightNumber", txtFlightNumber.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DS.DataSource = dt;
        }
         private void SearchFromOutboundFlightNumber()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where ai.IATACode=@from and Date=@Outbound and FlightNumber=@FlightNumber ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("from", cboFrom.SelectedValue);
            cmd.Parameters.AddWithValue("Outbound", Outbound(mtbOutbound.Text));
            cmd.Parameters.AddWithValue("FlightNumber", txtFlightNumber.Text);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DS.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Ngày hoặc tháng bạn nhập không đúng định dạng \n Vui lòng nhập lại!");
            }
        }
        private void SearchToOutboundFlightNumber()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where a.IATACode=@to and Date=@Outbound and FlightNumber=@FlightNumber";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("to", cboTo.SelectedValue);
            cmd.Parameters.AddWithValue("Outbound", Outbound(mtbOutbound.Text));
            cmd.Parameters.AddWithValue("FlightNumber", txtFlightNumber.Text);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DS.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Ngày hoặc tháng bạn nhập không đúng định dạng \n Vui lòng nhập lại!");
            }

        }
        private void SearchOutboundFlightNumber()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where Date=@date and FlightNumber=@FlightNumber";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("date", Outbound(mtbOutbound.Text));
            cmd.Parameters.AddWithValue("FlightNumber", txtFlightNumber.Text);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DS.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Ngày hoặc tháng bạn nhập không đúng định dạng \n Vui lòng nhập lại!");
            }
        }
        private void SearchFromToOutboundFlightNumber()
        {
            String sql = "SELECT Date,time,ai.IATACode as FROMS,a.IATACode as TOS,FlightNumber,c.Name as Aircraft,EconomyPrice,(EconomyPrice*1.35) as BusinessPrice, (EconomyPrice*1.35*1.3) as FirstClassPrice ,s.ID,s.Confirmed from [dbo].Airports a join [dbo].Routes r on a.ID = r.ArrivalAirportID join[dbo].Airports ai on ai.ID = r.DepartureAirportID join[dbo].Schedules s on s.RouteID = r.ID join[dbo].Aircrafts c on c.ID = s.AircraftID  where ai.IATACode=@from and a.IATACode=@to and Date=@Outbound and FlightNumber=@FlightNumber";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("from", cboFrom.SelectedValue);
            cmd.Parameters.AddWithValue("to", cboTo.SelectedValue);
            cmd.Parameters.AddWithValue("Outbound", Outbound(mtbOutbound.Text));
            cmd.Parameters.AddWithValue("FlightNumber", txtFlightNumber.Text);
            try { 
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DS.DataSource = dt;               
                }
            catch
            {
                MessageBox.Show("Ngày hoặc tháng bạn nhập không đúng định dạng \n Vui lòng nhập lại!");
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            con.Open();
            if (cboFrom.Text.Equals("") && cboTo.Text.Equals("")&& mtbOutbound.Text.Equals("dd/MM/yyyy") && txtFlightNumber.Text.Equals("[xx]"))
            {
                MessageBox.Show("Vui lòng nhập thông tin để tìm kiếm ");
                Form1_Load(sender, e);
            }
            if (!cboFrom.Text.Equals("") && cboTo.Text.Equals("") && mtbOutbound.Text.Equals("dd/MM/yyyy") && txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchFrom();
                confirmed();
            }
            if (cboFrom.Text.Equals("") && !cboTo.Text.Equals("") && mtbOutbound.Text.Equals("dd/MM/yyyy") && txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchTo();
                confirmed();
            }
            if (cboFrom.Text.Equals("") && cboTo.Text.Equals("") && !mtbOutbound.Text.Equals("dd/MM/yyyy") && txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchOutbound();
                confirmed();
            }
            if (cboFrom.Text.Equals("") && cboTo.Text.Equals("") && mtbOutbound.Text.Equals("dd/MM/yyyy") && !txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchFlightNumber(); confirmed();
            }
            if (!cboFrom.Text.Equals("") && !cboTo.Text.Equals("") && mtbOutbound.Text.Equals("dd/MM/yyyy") && txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchFormTo(); confirmed();
            }
            if (!cboFrom.Text.Equals("") && cboTo.Text.Equals("") && !mtbOutbound.Text.Equals("dd/MM/yyyy") && txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchFromOutbound(); confirmed();
            }
            if (!cboFrom.Text.Equals("") && cboTo.Text.Equals("") && mtbOutbound.Text.Equals("dd/MM/yyyy") && !txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchFromFlightNumber(); confirmed();
            }
            if (cboFrom.Text.Equals("") && !cboTo.Text.Equals("") && !mtbOutbound.Text.Equals("dd/MM/yyyy") && txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchToOutbound(); confirmed();
            }
            if (cboFrom.Text.Equals("") && !cboTo.Text.Equals("") && mtbOutbound.Text.Equals("dd/MM/yyyy") && !txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchToFlightNumber(); confirmed();
            }
            if (cboFrom.Text.Equals("") && cboTo.Text.Equals("") && !mtbOutbound.Text.Equals("dd/MM/yyyy") && !txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchOutboundFlightNumber(); confirmed();
            }
            if (!cboFrom.Text.Equals("") && !cboTo.Text.Equals("") && !mtbOutbound.Text.Equals("dd/MM/yyyy") && txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchFromToOutbound(); confirmed();
            }
            if (!cboFrom.Text.Equals("") && !cboTo.Text.Equals("") && mtbOutbound.Text.Equals("dd/MM/yyyy") && !txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchFromToFightNumber(); confirmed();
            }
            if (!cboFrom.Text.Equals("") && cboTo.Text.Equals("") && !mtbOutbound.Text.Equals("dd/MM/yyyy") && !txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchFromOutboundFlightNumber(); confirmed();
            }
            if (cboFrom.Text.Equals("") && !cboTo.Text.Equals("") && !mtbOutbound.Text.Equals("dd/MM/yyyy") && !txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchToOutboundFlightNumber(); confirmed();
            }
            if (!cboFrom.Text.Equals("") && !cboTo.Text.Equals("") && !mtbOutbound.Text.Equals("dd/MM/yyyy") && !txtFlightNumber.Text.Equals("[xx]"))
            {
                SearchFromToOutboundFlightNumber(); confirmed();
            }
            this.DS.Sort(this.DS.Columns["Date"], ListSortDirection.Descending);
            con.Close();
        }
        Updates update;
        private void btnEditFlight_Click(object sender, EventArgs e)
        {
            update = new Updates();
            update.ShowDialog();
            dt.Clear();
            Form1_Load(sender, e);
            
        }

        private void btnImportChange_Click(object sender, EventArgs e)
        {
            ApplyScheduleChange apply = new ApplyScheduleChange();
           // Form1 apply = new Form1();
            apply.ShowDialog();
            this.Hide();
        }
        // kiểm tra điểm đi điểm đến không được trùng nhau
        private void cboFrom_SelectedValueChanged(object sender, EventArgs e)
        {        
                con.Close();
                con.Open();
                ComboBox cb = sender as ComboBox;
                String value = cb.Text;
                String sql = "Select * from [dbo].[Airports] Where IATACode!=@to";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("to", value);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                cboTo.DataSource = dt;
                cboTo.DisplayMember = "IATACode";
                cboTo.ValueMember = "IATACode";                
                con.Close();
        }
        // gán giá trị từ bản ghi ra thuộc tính
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = DS.CurrentCell.RowIndex;
            Edits.from = DS.Rows[row].Cells[2].Value.ToString();
            Edits.to = DS.Rows[row].Cells[3].Value.ToString();
            Edits.air = DS.Rows[row].Cells["Aircraft"].Value.ToString();
            Edits.date = DateTime.Parse(DS.Rows[row].Cells["Date"].Value.ToString());
            Edits.time = TimeSpan.Parse(DS.Rows[row].Cells["Time"].Value.ToString());
            Edits.economyprice =decimal.Parse( DS.Rows[row].Cells[6].Value.ToString());
            Edits.ID = int.Parse(DS.Rows[row].Cells["ID"].Value.ToString());
            Edits.confirmed = DS.Rows[row].Cells["Confirmed"].Value.ToString();
            if (Edits.confirmed.ToString().Equals("False")){
                btnCancelFlight.Text = "Confirm Flight";
                this.btnCancelFlight.Image = global::BTLCSharp.Properties.Resources.icons8_verified_account_28;
            }
            else
            {
                btnCancelFlight.Text = "Cancel Flight";
                this.btnCancelFlight.Image = global::BTLCSharp.Properties.Resources._117176389_763522694447860_8125836641994537154_n;
            }
            btnCancelFlight.Enabled = true;
            btnEditFlight.Enabled = true;
           
        }
        // Hàm xác nhận chuyến bay
        private void btnCancelFlight_Click(object sender, EventArgs e)
        {
            // DS.Rows[row].DefaultCellStyle.BackColor = Color.Red;  
            String sql = "UPDATE [dbo].[Schedules] set Confirmed=@ma where ID=@id";
            int ma = 0;
            int ma1 = 1;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("id", Edits.ID);
            if (Edits.confirmed.ToString().Equals("True")) {
                
                cmd.Parameters.AddWithValue("ma", ma);
                DialogResult dia = MessageBox.Show("Xác nhận hủy! ", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dia == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Hủy chuyến bay thành công !");
                }
            }
            else
            {
                cmd.Parameters.AddWithValue("ma", ma1);
                DialogResult dia = MessageBox.Show("Xác nhận chuyến bay! ", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dia == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xác nhận chuyến bay thành công !");
                }
            }
            
            con.Close();
            
            dt.Clear();
            Form1_Load(sender, e);

        }
        
        private void cboSort_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSort.SelectedIndex == 0)
            {
                this.DS.Sort(this.DS.Columns["Date"], ListSortDirection.Descending);
                confirmed();

            }
            else if (cboSort.SelectedIndex == 1)
            {
                this.DS.Sort(this.DS.Columns["EconomyPrice"], ListSortDirection.Descending);
                confirmed();
            }
            else
            {
                this.DS.Sort(this.DS.Columns[10], ListSortDirection.Descending);
                confirmed();
            }
        }
        
        private void mtbOutbound_Enter(object sender, EventArgs e)
        {
            if (mtbOutbound.Mask == "dd/MM/yyyy")
            {

                mtbOutbound.Mask= "00/00/0000";
                mtbOutbound.ForeColor = Color.Black;
            }
        }

        private void mtbOutbound_Leave(object sender, EventArgs e)
        {
            if (mtbOutbound.Text == "  /  /")
            {
                mtbOutbound.Mask = "dd/MM/yyyy";
            }
        }
        private void txtFlightNumber_Enter(object sender, EventArgs e)
        {
            if (txtFlightNumber.Text == "[xx]")
            {
                txtFlightNumber.Text = "";

            }
        }

        private void txtFlightNumber_Leave(object sender, EventArgs e)
        {
            if (txtFlightNumber.Text == "")
            {
                txtFlightNumber.Text = "[xx]";
            }
        }
    }
}
