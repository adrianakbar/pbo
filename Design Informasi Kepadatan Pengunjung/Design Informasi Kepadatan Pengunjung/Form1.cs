using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Informasi_Kepadatan_Pengunjung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=Jecation; User Id=postgres; Password=Akbar_29102005"))
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select count(id_pmsn_tiket) from pemesanan_tiket where jadwal_pmsn_tiket = @now";
                cmd.Parameters.AddWithValue("@now", dateTimePicker1.Value);
                cmd.CommandType = CommandType.Text;

                // Mengambil hasil eksekusi perintah sebagai objek
                object result = cmd.ExecuteScalar();

                // Memeriksa apakah hasilnya tidak null
                if (result != null)
                {
                    // Mengkonversi hasil ke string dan menetapkannya ke label4.Text
                    label4.Text = "Pada tanggal " + dateTimePicker1.Value.ToString("dd MMMM yyyy") + ", terdapat " + result.ToString() + " orang yang sedang menikmati wisata kami.";
                }

                cmd.Dispose();
                connection.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=Jecation; User Id=postgres; Password=Akbar_29102005"))
            {
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select count(id_pmsn_tiket) from pemesanan_tiket where jadwal_pmsn_tiket = @now";
                cmd.Parameters.AddWithValue("@now", dateTimePicker1.Value);
                cmd.CommandType = CommandType.Text;

                // Mengambil hasil eksekusi perintah sebagai objek
                object result = cmd.ExecuteScalar();

                // Memeriksa apakah hasilnya tidak null
                if (result != null)
                {
                    // Mengkonversi hasil ke string dan menetapkannya ke label4.Text
                    label4.Text = "Pada tanggal " + dateTimePicker1.Value.ToString("dd MMMM yyyy") + ", terdapat " + result.ToString() + " orang yang sedang menikmati wisata kami.";
                }

                cmd.Dispose();
                connection.Close();
            }
        }
            //using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=Jecation; User Id=postgres; Password=Akbar_29102005"))
            //{
            //    connection.Open();
            //    NpgsqlCommand cmd = new NpgsqlCommand();
            //    cmd.Connection = connection;
            //    cmd.CommandText = "select count(id_pmsn_tiket) from pemesanan_tiket where jadwal_pmsn_tiket = '12-06-2023';";
            //    cmd.CommandType = CommandType.Text;
            //    cmd.ExecuteNonQuery();
            //    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    cmd.Dispose();
            //    connection.Close();

            //    label4.Text = dt;
            //}
        
    }
}
