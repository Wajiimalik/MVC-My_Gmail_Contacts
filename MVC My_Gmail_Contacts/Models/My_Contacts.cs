using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;


namespace MVC_My_Gmail_Contacts.Models
{
    public class My_Contacts
    {
        public static string connStr = "Data Source=WAJIHAALI\\SQLEXPRESS;Initial Catalog=ChatterBoxDB;Integrated Security=true";

        
        public int Contact_ID { get; set; }


        [Display(Name = "Contact Name")]
        [StringLength(20)]
        public string Name { get; set; }


        [Display(Name = "Email Address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(30)]
        public string Email { get; set; }


        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public string DOB { get; set; }



        public static void ExecuteCommand(string strsql)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            SqlCommand cmd = new SqlCommand(strsql, conn);
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Dispose();

            //return retvalue;
            return;
        }


        public static void ExecuteCommand(string procedure, Dictionary<string, object> parameters)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            SqlCommand cmd = new SqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }
            string msg = "";
            try
            {
                Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
            cmd.Dispose();
            conn.Dispose();

            return;
        }


        public static DataSet SendDataSet(string strsql)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            SqlCommand cmd = new SqlCommand(strsql, conn);
            cmd.CommandType = CommandType.Text;

            DataSet ds = new DataSet();

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);

            cmd.Parameters.Clear();
            cmd.Dispose();
            conn.Dispose();

            return ds;
        }


        public static DataSet SendDataSet(string procedure, Dictionary<string, object> parameters)
        {
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            SqlCommand cmd = new SqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);

            cmd.Parameters.Clear();
            cmd.Dispose();
            conn.Dispose();

            return ds;
        }


    }
}