<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="TimeSheet.CreateUser" %>

<%@ Register assembly="DevExpress.Web.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"  style="background-color: gainsboro;">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 200px;
            height: 34px;
        }
        .auto-style9 {
            width: 163px;
            height: 34px;
        }
        .auto-style10 {
            width: 163px;
            height: 41px;
        }
        .auto-style11 {
            width: 200px;
            height: 41px;
        }
        .auto-style12 {
            width: 163px;
            height: 42px;
        }
        .auto-style13 {
            width: 200px;
            height: 42px;
        }
        .auto-style14 {
            width: 163px;
            height: 50px;
        }
        .auto-style15 {
            width: 200px;
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Field cannot be blank">
        </dx:ASPxLabel>
    
 <br /><table>
     <tr>
         <td class="auto-style10">
              Create Username&nbsp;&nbsp; :
         </td>
         <td class="auto-style11">
              <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px"   >
        </dx:ASPxTextBox>
         </td>
     </tr>
     <tr>
         <td class="auto-style12">
  Create Password&nbsp;&nbsp; :
         </td>
         <td class="auto-style13">
             <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Width="170px" Password="true" >
        </dx:ASPxTextBox>
         </td>
     </tr>
     <tr>
         <td class="auto-style14">
              Confirm Password :
         </td>
         <td class="auto-style15">
               <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" Width="170px" Password="true" >
        </dx:ASPxTextBox>
         </td>
     </tr>
     <tr>
         <td class="auto-style9">
             <dx:ASPxButton ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click"></dx:ASPxButton>
         </td>
         <td class="auto-style3">
             <dx:ASPxButton ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" style="-webkit-user-select:none;border-radius: 25%;">
        </dx:ASPxButton>
         &nbsp;</td>
     </tr>
       </table>
       
       
      
       
</div>
    </form>
</body>
</html>
