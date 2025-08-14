<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="ASP_Projects.Assignments.Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validator</title>
    <style>
        body { font-family: Arial; }
        .label { width: 120px; display: inline-block; }
        .input { background-color: lightcyan; }
        .req { color: red; }
        .hint { font-size: 12px; color: gray; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h3>Insert your details :</h3>

        <div class="form-group">
            <span class="label">Name:</span>
            <asp:TextBox ID="txtName" runat="server" CssClass="input" />
            <span class="req">*</span>
            <asp:RequiredFieldValidator ID="rfvName" runat="server"
                ControlToValidate="txtName"
                ErrorMessage="Name is required." CssClass="aspNet-Error"
                Display="Dynamic" ValidationGroup="UserForm" />
        </div>

        <div class="form-group">
            <span class="label">Family Name:</span>
            <asp:TextBox ID="txtFamily" runat="server" CssClass="input" />
            <span class="req">*</span>
            <asp:RequiredFieldValidator ID="rfvFamily" runat="server"
                ControlToValidate="txtFamily"
                ErrorMessage="Family Name is required." CssClass="aspNet-Error"
                Display="Dynamic" ValidationGroup="UserForm" />
            <span class="hint">differs from name</span>
            <asp:CompareValidator ID="cvDiff" runat="server"
                ControlToCompare="txtName" ControlToValidate="txtFamily"
                Operator="NotEqual" Type="String"
                ErrorMessage="Family name must differ from name."
                CssClass="aspNet-Error" Display="Dynamic" ValidationGroup="UserForm" />
        </div>

        <div class="form-group">
            <span class="label">Address:</span>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="input" />
            <span class="req">*</span>
            <asp:RequiredFieldValidator ID="rfvAddress" runat="server"
                ControlToValidate="txtAddress"
                ErrorMessage="Address is required." CssClass="aspNet-Error"
                Display="Dynamic" ValidationGroup="UserForm" />
            <span class="hint">at least 2 chars</span>
            <asp:RegularExpressionValidator ID="revAddress" runat="server"
                ControlToValidate="txtAddress"
                ValidationExpression="^.{2,}$"
                ErrorMessage="Address must be at least 2 characters."
                CssClass="aspNet-Error" Display="Dynamic" ValidationGroup="UserForm" />
        </div>

        <div class="form-group">
            <span class="label">City:</span>
            <asp:TextBox ID="txtCity" runat="server" CssClass="input" />
            <span class="req">*</span>
            <asp:RequiredFieldValidator ID="rfvCity" runat="server"
                ControlToValidate="txtCity"
                ErrorMessage="City is required." CssClass="aspNet-Error"
                Display="Dynamic" ValidationGroup="UserForm" />
            <span class="hint">at least 2 chars</span>
            <asp:RegularExpressionValidator ID="revCity" runat="server"
                ControlToValidate="txtCity"
                ValidationExpression="^[A-Za-z\s]{2,}$"
                ErrorMessage="City must be at least 2 letters."
                CssClass="aspNet-Error" Display="Dynamic" ValidationGroup="UserForm" />
        </div>

        <div class="form-group">
            <span class="label">Zip Code:</span>
            <asp:TextBox ID="txtZip" runat="server" CssClass="input" MaxLength="5" />
            <span class="req">*</span>
            <asp:RequiredFieldValidator ID="rfvZip" runat="server"
                ControlToValidate="txtZip"
                ErrorMessage="Zip code is required." CssClass="aspNet-Error"
                Display="Dynamic" ValidationGroup="UserForm" />
            <span class="hint">(xxxxx)</span>
            <asp:RegularExpressionValidator ID="revZip" runat="server"
                ControlToValidate="txtZip"
                ValidationExpression="^\d{5}$"
                ErrorMessage="Zip must be 5 digits."
                CssClass="aspNet-Error" Display="Dynamic" ValidationGroup="UserForm" />
        </div>

        <div class="form-group">
            <span class="label">Phone:</span>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="input" />
            <span class="req">*</span>
            <asp:RequiredFieldValidator ID="rfvPhone" runat="server"
                ControlToValidate="txtPhone"
                ErrorMessage="Phone is required." CssClass="aspNet-Error"
                Display="Dynamic" ValidationGroup="UserForm" />
            <span class="hint">(XX-XXXXXXX / XXX-XXXXXXX)</span>
            <asp:RegularExpressionValidator ID="revPhone" runat="server"
                ControlToValidate="txtPhone"
                ValidationExpression="^(\d{2}-\d{7}|\d{3}-\d{7})$"
                ErrorMessage="Invalid phone format."
                CssClass="aspNet-Error" Display="Dynamic" ValidationGroup="UserForm" />
        </div>

        <div class="form-group">
            <span class="label">E-Mail:</span>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="input" />
            <span class="req">*</span>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="Email is required." CssClass="aspNet-Error"
                Display="Dynamic" ValidationGroup="UserForm" />
            <asp:RegularExpressionValidator ID="revEmail" runat="server"
                ControlToValidate="txtEmail"
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                ErrorMessage="Invalid email address."
                CssClass="aspNet-Error" Display="Dynamic" ValidationGroup="UserForm" />
        </div>

        <div style="margin-top:15px;">
            <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" ValidationGroup="UserForm" />
        </div>

        <asp:ValidationSummary ID="vs" runat="server"
            HeaderText="Please fix the following errors:"
            ShowMessageBox="true"
            ShowSummary="false"
            ValidationGroup="UserForm" />
    </form>
</body>
</html>
