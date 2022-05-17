<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        欢迎使用 ASP.NET!
    </h2>
    <p>
        若要了解关于 ASP.NET 的详细信息，请访问 <a href="http://www.asp.net/cn" title="ASP.NET 网站">www.asp.net/cn</a>。
        <%=str1 %>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        <%=str2 %>
    </p>
    <p> 
    <asp:Repeater ID="dataRepeater" runat="server">
    <HeaderTemplate>
        销售订单列表<div id="accordion">
    </HeaderTemplate>
    <ItemTemplate>
        <h3>
            <a href="/Detail.aspx?orderid=<%# DataBinder.Eval(Container.DataItem, "code")%>" style="background-color: gray; height: 25px; color: White; text-decoration: none;">
                <%# DataBinder.Eval(Container.DataItem, "code")%></a></h3>
        <div>
            <ul>
                <li><span>Date:
                    <%# DataBinder.Eval(Container.DataItem, "date")%></span></li>
                <li><span>类型:
                    <%# DataBinder.Eval(Container.DataItem, "businesstype")%></span>    </li>
                <li><span>客户名称:
                    <%# DataBinder.Eval(Container.DataItem, "cusname")%></span></li>
                <li><span>部门:
                    <%# DataBinder.Eval(Container.DataItem, "deptname")%></span></li>
                <li><span>业务员:
                    <%# DataBinder.Eval(Container.DataItem, "personname")%></span></li>
                <li><span>制单人:
                    <%# DataBinder.Eval(Container.DataItem, "maker")%></span></li>
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
