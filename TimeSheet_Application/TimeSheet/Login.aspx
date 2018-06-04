<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TimeSheet.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 40%;background-color: lightgrey;float: left;height: 200px;margin-left: 30%;margin-top: 10%;border-radius: 12px;">
    <div style=" width: 65%;float: left;margin-left: 24%;margin-top: 9%;font-size: 18px;font-family: sans-serif;">

        Username
        <asp:TextBox ID="TextBox1" runat="server" style="border-radius: 7px;"></asp:TextBox>
<br />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        Password&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" style="border-radius: 7px;"></asp:TextBox>
     </div>
        <br />
        <br />
        <div style="width: 30%;float: left;margin-left: 24%;margin-top: 4%;">
     <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" style="background-color: aliceblue;border-radius: 7px;font-size: 16px; margin-left: 72%;" />
        </div>
    </div>
       
    
        <asp:Button ID="createUser" runat="server" OnClick="createUser_Click" Text="Register" />

       
    </form>
</body>
</html>
