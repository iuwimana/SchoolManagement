<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeDetail.aspx.cs" Inherits="HomeDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
<tr>
	
       
     <td>

          
            <p style = "font-family:georgia,garamond,serif;font-size:20px;align-content:flex-start;font-style:italic;">
                CONTRIBUTION</p>
            <table>
                 <tr>
	                 <td><img src="contributions.JPG" width="125" height="85" border="0" alt=""> </td>
	                 <td><p style = "font-family:georgia,garamond,serif;font-size:14px;align-content:flex-end;font-style:italic;">
               Under This Part you will view all record concern to your contribution</p>
               <a href="contribution.aspx" target="mid_col"> Details</a>  </td></td>
               </tr>
            </table>
         


     </td>        
	<td>

         <p style = "font-family:georgia,garamond,serif;font-size:20px;align-content:flex-start;font-style:italic;">
                LOAN</p>
            <table>
                 <tr>
	                 <td><img src="Loan.JPG" width="125" height="85" border="0" alt=""> </td>
	                 <td><p style = "font-family:georgia,garamond,serif;font-size:14px;align-content:flex-end;font-style:italic;">
               Under This Part you will have access to all Loan you have requested for</p>
               <a href="Login.aspx" target="mid_col"> Details</a>  </td></td>
               </tr>
            </table>

	</td>
	<td>

         <p style = "font-family:georgia,garamond,serif;font-size:20px;align-content:flex-start;font-style:italic;">
                LOAN REPAYMENT</p>
            <table>
                 <tr>
	                 <td><img src="LoanRepayment.JPG" width="125" height="85" border="0" alt=""> </td>
	                 <td><p style = "font-family:georgia,garamond,serif;font-size:14px;align-content:flex-end;font-style:italic;">
               Under This Part you will view all record concern to your Loan Repayments</p>
               <a href="Login.aspx" target="mid_col"> Details</a> </td></td>
               </tr>
            </table>



	</td>
</tr>

</table>
        
    </div>
    </form>
</body>
</html>

