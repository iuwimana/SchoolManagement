using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Security;
using WebApp;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////Ease the pain of testing!!!
        if (Environment.MachineName.Contains("DESKTOP"))
        {
            TextBox1.Text = "admin";
            TextBox2.Text = "Uw551239";
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //try
        //{
        bool loggedIn = SecurityFactory.Login(TextBox1.Text, TextBox2.Text);

        if (loggedIn)
        //if(textBoxUsername.Text.ToString()=="admin" && textBoxPassword.Text.ToString() == "horizonadmin")
        {
            //Label1.Text="Authentify";
            Response.Redirect("HomeDetail.aspx");
        }
        else
        {
            Label1.Text = "ERROR!: The username and/or password are incorrect. Please try again";
        }



        //}
        //catch
        //{
        //    Label1.Text = "ERROR!: connection Brocken";
        //}
    
}
}