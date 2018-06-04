<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="TimeSheet.MainPage" %>

<%@ Register assembly="DevExpress.Web.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxScheduler.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: lightcyan;">
<head runat="server">
    <title></title>
   
</head>
<body>
      <form id="form1" runat="server">
         
    <div style="background-color: mintcream;margin-left: 9%;margin-right: 10%;height: 600px;">  
        <div style="margin-left: 20%;margin-top: 2%;">  
        
     
        
        <dx:ASPxButton ID="logOut" runat="server" OnClick="logOut_Click" Text="Logout" style="-webkit-user-select:none;border-width: inherit;float: right;margin-top: 1%;background-color: whitesmoke;margin-right: 3%; border-radius: 7px;">
        </dx:ASPxButton>
        
      
        
        <br />
            <dx:ASPxDateEdit ID="dtpTimeSheet" runat="server"  AutoPostBack="True" DisplayFormatString="dd-MMM-yyyy" OnDateChanged="dtpTimeSheet_DateChanged" style="margin-left: 5%;margin-bottom: -2%;border-width:medium;border-color:lightslategray ">
        </dx:ASPxDateEdit>
   Date : 
      <br />
        <br />

        <dx:ASPxGridView ID="timeSheetGrid" style="border-collapse:separate;margin-top:5%;border-color: gray;border-width: medium;border-radius: 6px;" runat="server"  EnableCallBacks="false"  SettingsEditing-Mode="PopupEditForm"  AutoGenerateColumns="False" KeyFieldName="TaskId" OnRowDeleting="timeSheetGrid_RowDeleting" OnRowUpdating="timeSheetGrid_RowUpdating"  OnRowValidating="timeSheetGrid_RowValidating">
       
             <SettingsEditing Mode="PopupEditForm"   EditFormColumnCount="2" >
            </SettingsEditing>
            

            <Columns>
                 <dx:GridViewCommandColumn  ShowDeleteButton="True" Caption="Delete"  VisibleIndex="10" >
                 </dx:GridViewCommandColumn>
                 <dx:GridViewCommandColumn  Caption="Edit" VisibleIndex="0" ShowEditButton="True">
                 </dx:GridViewCommandColumn>
                 <dx:GridViewDataTextColumn Caption="Emp Id" FieldName="EmpId"  EditFormSettings-Visible="False" VisibleIndex="1">
<EditFormSettings Visible="False"></EditFormSettings>
                 </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="User Name" FieldName="UserName"  EditFormSettings-Visible="False" VisibleIndex="2">
<EditFormSettings Visible="False"></EditFormSettings>
                 </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn FieldName="Date" ReadOnly="true" Caption="Date"  VisibleIndex="3"></dx:GridViewDataTextColumn>                
                 <dx:GridViewDataTimeEditColumn Caption="From Time"  FieldName="FromTime" VisibleIndex="4">
                      <PropertiesTimeEdit DisplayFormatString="h:mm tt">
    </PropertiesTimeEdit>
                 </dx:GridViewDataTimeEditColumn>
                 <dx:GridViewDataTimeEditColumn Caption="To Time" FieldName="ToTime" VisibleIndex="5">
                     <PropertiesTimeEdit DisplayFormatString="h:mm tt">
    </PropertiesTimeEdit>
                 </dx:GridViewDataTimeEditColumn>             
                 <dx:GridViewDataTextColumn Caption="Task Id" FieldName="TaskId" ReadOnly="true" VisibleIndex="6"></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="Description" FieldName="Description" VisibleIndex="7"></dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn Caption="First Name" FieldName="FirstName"  EditFormSettings-Visible="False" VisibleIndex="8">
<EditFormSettings Visible="False"></EditFormSettings>
                 </dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="Last Name" FieldName="LastName"  EditFormSettings-Visible="False" VisibleIndex="9">
<EditFormSettings Visible="False"></EditFormSettings>
                 </dx:GridViewDataTextColumn>               
                  </Columns>
        </dx:ASPxGridView>
      <dx:ASPxButton ID="ASPxButton1"  runat="server" AutoPostBack="false" Text="Add" style="border-width: inherit;margin-top: 3%;border-radius: 7px;width: 47px;">
        </dx:ASPxButton>
       <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" HeaderText="Add User" PopupElementID="ASPxButton1" PopupHorizontalAlign="LeftSides"  PopupVerticalAlign="Below">
            <ContentCollection>
         <dx:PopupControlContentControl runat="server">
               
              
              
             <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="From Time"></dx:ASPxLabel>         <dx:ASPxTimeEdit ID="ASPxTimeEdit1" runat="server"  ></dx:ASPxTimeEdit>
             <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="To Time"></dx:ASPxLabel>            <dx:ASPxTimeEdit ID="ASPxTimeEdit2" runat="server" ></dx:ASPxTimeEdit>
               <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Description"></dx:ASPxLabel>    <dx:ASPxTextBox ID="ASPxTextBox5" runat="server" Width="170px"></dx:ASPxTextBox> 

                    <dx:ASPxButton ID="addTask" runat="server" Text="Add Details" OnClick="addTask_Click" >
                       
                    </dx:ASPxButton>
                
</dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
       
       

<asp:Label ID="Label1" runat="server"  Text="Label"></asp:Label>                             
       
       

        <br />
        <br />
            </div>
    
    </div>
    </form>
</body>
</html>
