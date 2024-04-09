<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Sitio.Master" AutoEventWireup="true" CodeBehind="Embarcamiento.aspx.cs" Inherits="Frontend.Pages.webforms.Embarcamiento" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../css/Embarcamiento.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <div class="card">
            <div class="card-header">
                <h3>Seleccionar Avión</h3>
            </div>
            <div class="card-body">
                <asp:Button ID="btmSelecionarAvion" runat="server" Text="Seleccionar" CssClass="btmSelecionarAvion"/>
                <asp:Image ID="AvionImagen" runat="server" src="../assets/Avion.png" CssClass="AvionImagen" />
                <div class="info-avion">
                    <asp:Label ID="Label1" runat="server" Text="Identificacion del avion: "></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Modelo: "></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="Peso maximo: "></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="Alcance: "></asp:Label>
                    <asp:Label ID="Label5" runat="server" Text="Velocidad: "></asp:Label>
                    <asp:Label ID="Label6" runat="server" Text="Capacidad: "></asp:Label>
                    <asp:Label ID="Label7" runat="server" Text="Combustible: "></asp:Label>
                </div>
                                
            </div>
        </div>
    </div>
    <div class="centrocontent">
        <div class="cardcentro">
            <div class="cardcentro-header">
                <img src="../assets/logo.png" style="width:150px; height:125px; position:absolute; left:415px;"/>
                <h1>Embarcamiento</h1>
            </div>
            <div class="cardcentro-body">
                <div class="cardadentro">
                    <h2>Embarcamiento del avión</h2>


                    <h3>Numero de pasajeros</h3>

                    <div class="carderecha" style="align-items:center; margin-left:250px; display:flex; flex-direction:column">
                    <div class="card-body gridview-container">
                        <asp:MultiView ID="mvVuelos" runat="server">
                            <asp:View ID="View1" runat="server">
                                <!-- Contenedor para GridView y botones -->
                                <div class="gridview-y-botones-container">
                                    <div class="gridview-wrapper">
                                        <asp:GridView ID="GvEquipaje" runat="server" CssClass="styled-gridview"></asp:GridView>
                                    </div>
                                    <div class="botones-wrapper">
                                        <asp:Button ID="Button1" runat="server" Text="Añadir" CssClass="btmAnadir"/>
                                        <asp:Button ID="Button2" runat="server" Text="Añadir" CssClass="btmAnadir"/>
                                        <asp:Button ID="Button3" runat="server" Text="Añadir" CssClass="btmAnadir"/>
                                    </div>
                                </div>
                            </asp:View>
                        </asp:MultiView>
                    </div>
                </div>
                    <asp:Button ID="btmEquipar" runat="server" Text="Equipar" CssClass="btmSelecionarAvion" />
                </div>
                
                <%--<div class="botones">
                    <asp:Button ID="btmAutorizar" runat="server" Text="Autorizar Despegue" CssClass="botonautorizar" />
                    <asp:Button ID="btmDenegar" runat="server" Text="Denegar Despegue" CssClass="botondenegar" />
                </div>--%>
            </div>
        </div>
    </div>
</asp:Content>
