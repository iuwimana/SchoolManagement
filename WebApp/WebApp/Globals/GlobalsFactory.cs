using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
//using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using Security;

namespace Globals
{
    //public static class GlobalsFactory
    //{
    //    public static int UserID { get; set; }
    //    public static void InitializeListView(ListView listView)
    //    {
    //        listView.View = View.Details;
    //        listView.LabelEdit = false;
    //        listView.AllowColumnReorder = false;
    //        listView.FullRowSelect = true;
    //        listView.Sorting = SortOrder.None;
    //    }

    //    public static int GetCurrentUserId()
    //    {
    //        return Ticket.Instance.User.UserID;
    //    }

    //    public static Boolean DateCompare(DateTime startDate, DateTime endDate)
    //    {
    //        try
    //        {
    //            if (DateTime.Compare(startDate, endDate) <= 0) { return true; }
    //            else { return false; }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }

    //    public static string GetConnectionString()
    //    {
    //        return ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
    //    }

    //    public enum Report : byte
    //    {
    //        Visa
    //    }

    //    public static Bitmap ByteToImage(byte[] blob)
    //    {
    //        MemoryStream mStream = new MemoryStream();
    //        byte[] pData = blob;
    //        mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
    //        Bitmap bm = new Bitmap(mStream, false);
    //        mStream.Dispose();
    //        return bm;
    //    }

    //    public static bool IsValidEmail(string email)
    //    {
    //        try
    //        {
    //            var addr = new System.Net.Mail.MailAddress(email);
    //            return addr.Address == email;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }

    //    public static void SendMail(MailMessage mail)
    //    {
    //        SmtpClient SmtpServer = new SmtpClient("xx.xx.xx.xx", 25);
    //        SmtpServer.Send(mail);
    //    }

    //}
}
