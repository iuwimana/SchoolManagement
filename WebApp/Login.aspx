<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html >
<head >
    <title>Login</title>
 <style type="text/css">
    fieldSet 
    {
        width: 97%; 
        margin-left: 10px;
        border:10px solid;
        margin:1;
        border: 10px solid rgb(234, 234, 234);
       background: rgb(244, 244, 244);
    }
     input[type='text'] {
         color: lightblack;
         border: 2px solid black;
         margin-left: 0px;
     }
     input[type='password'][name='password'] {
    
    color: lightblack;
    border: 2px solid black;
         width: 229px;
     }

    legend
    {

        border-style:none;
        background-color: #003366;
        font-family: Tahoma, Arial, Helvetica;
        font-weight: bold;
        font-size: 12pt;
        Color: White;
        width:100%;
        height:100%;
        padding-left:10px;

    }

   

    </style>
</head>
<body>
    <div style="height:10px;"></div>

<div class="panel panel-primary">

    
    <div class="panel-body">
        <form id="form1" runat="server">
        <center><fieldset style="align-self:center">
                        <legend>Log in Form</legend>
                        <table class="table table-condensed">
                            <tr>
                                <td style="border: none; width:180px;">
                                    UserName</td>
                                <td style="border: none">
                                    &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="234px"></asp:TextBox>
                                </td>
                            </tr>
                            <br></br>
                            <tr>
                                <td style="border: none; width:180px;">
                                    PassWord </td>
                                <td style="border: none">
                                    &nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="234px" TextMode="Password"></asp:TextBox>
                                    <br>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="border: none">
                                    <asp:Label ID="Label1" runat="server" ForeColor="#FF0066"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            
                        </table>
                        

                        <div class="pull-right col-xs-2">
                            &nbsp;<asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click"></asp:Button>
                            <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logi In" Width="69px" />--%>
                        </div>
                    </fieldset>  </center>
        </form>
                    <div class="spacer"></div>                 
            
        
    </div>l
     </div>




</body>
</html>
