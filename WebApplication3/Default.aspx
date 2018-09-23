<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
	<style>
		td input[name^=ImageButton]
		{
			width:25px;	
		}
		table, td
		{
			border: 1px solid black;
		}
	</style>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<asp:Table runat="server" ID="tbl"></asp:Table>
		<table>
			<tr>
				<td>
					<asp:ImageButton runat="server" id="ImageButton1" OnClick="Secondary_Click" ImageUrl="one.png" />
				</td>
				<td>
					<asp:ImageButton runat="server" id="ImageButton2" OnClick="Secondary_Click" ImageUrl="two.png" />
				</td>
				<td>
					<asp:ImageButton runat="server" id="ImageButton3" OnClick="Secondary_Click" ImageUrl="three.png" />
				</td>
				<td>
					<asp:ImageButton runat="server" id="ImageButton4" OnClick="Secondary_Click" ImageUrl="four.png" />
				</td>
				<td>
					<asp:ImageButton runat="server" id="ImageButton5" OnClick="Secondary_Click" ImageUrl="five.png" />
				</td>
				<td>
					<asp:ImageButton runat="server" id="ImageButton6" OnClick="Secondary_Click" ImageUrl="six.png" />
				</td>
				<td>
					<asp:ImageButton runat="server" id="ImageButton7" OnClick="Secondary_Click" ImageUrl="seven.png" />
				</td>
				<td>
					<asp:ImageButton runat="server" id="ImageButton8" OnClick="Secondary_Click" ImageUrl="eight.png" />
				</td>
				<td>
					<asp:ImageButton runat="server" id="ImageButton9" OnClick="Secondary_Click" ImageUrl="nine.png" />
				</td>
			</tr>
		</table>
	</div>
	</form>
</body>
</html>
