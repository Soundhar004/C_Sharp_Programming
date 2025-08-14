<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductViewer.aspx.cs" Inherits="ASP_Projects.Assignments.ProductViewer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Viewer</title>
     <style>
        body { font-family: Arial; padding: 20px; }
        .container { max-width: 500px; margin: auto; }
        .label { font-weight: bold; margin-top: 10px; display: block; }
        .product-image { width: 300px; height: 200px; object-fit: contain; margin-top: 10px; }
        .price-label { font-size: 18px; color: green; margin-top: 10px; }
    </style>
</head>
<body>
     <form id="form1" runat="server">
        <div class="container">
            <h2>Select a Product</h2>

            <asp:Label ID="lblSelect" runat="server" Text="Choose a product:" CssClass="label" />
            <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
            </asp:DropDownList>

            <asp:Image ID="imgProduct" runat="server" CssClass="product-image" />

            <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" OnClick="btnGetPrice_Click" />

            <asp:Label ID="lblPrice" runat="server" CssClass="price-label" />
        </div>
    </form>
</body>
</html>
