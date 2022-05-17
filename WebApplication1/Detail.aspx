<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Detail.aspx.cs" Inherits="WebApplication1.Detail" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        欢迎使用 ASP.NET!
    </h2>
    <p>
        若要了解关于 ASP.NET 的详细信息，请访问 <a href="http://www.asp.net/cn" title="ASP.NET 网站">www.asp.net/cn</a>。
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    </p>
    <p> 
    <asp:Repeater ID="dataRepeater" runat="server">
    <HeaderTemplate>
        销售订单列表<div id="accordion">
    </HeaderTemplate>
    <ItemTemplate>
        <h3>
            <a href="#" style="background-color: gray; height: 25px; color: White; text-decoration: none;">
                <%# DataBinder.Eval(Container.DataItem, "inventorycode")%></a></h3>
        <div>
            <ul>
                <li><span>Date:
                    <%# DataBinder.Eval(Container.DataItem, "inventorycode")%></span></li>
                <li><span>类型:
                    <%# DataBinder.Eval(Container.DataItem, "inventoryname")%></span>    </li>
                <li><span>客户名称:
                    <%# DataBinder.Eval(Container.DataItem, "invstd")%></span></li>
                <li><span>部门:
                    <%# DataBinder.Eval(Container.DataItem, "unitname")%></span></li>
                <li><span>业务员:
                    <%# DataBinder.Eval(Container.DataItem, "quantity")%></span></li>
                <li><span>制单人:
                    <%# DataBinder.Eval(Container.DataItem, "unitprice")%></span></li>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div></FooterTemplate>
</asp:Repeater>
</p>
    <p>
        您还可以找到 <a href="http://go.microsoft.com/fwlink/?LinkID=152368"
            title="MSDN ASP.NET 文档">MSDN 上有关 ASP.NET 的文档</a>。
    </p>
</asp:Content>