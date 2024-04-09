<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Sitio.Master" AutoEventWireup="true" CodeBehind="Despegue.aspx.cs" Inherits="Frontend.Pages.webforms.Despegue" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../css/prueba.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <div class="card">
            <div class="card-header">
                <h3>Controlador de indicadores</h3>
            </div>
            <div class="card-body">
                <h4>Recopilacion de datos</h4>
                <asp:Label ID="Label1" runat="server" Text="✔Informacion meteorologica" CssClass="textos"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="✔Coordinacion" CssClass="textos"></asp:Label>
                <h4>Separacion inicial</h4>
                <asp:Label ID="Label8" runat="server" Text="✔Se garantizo el espacio correcto entre aereonaves" CssClass="textos"></asp:Label>
                <h4>Embarcamiento</h4>
                <asp:Label ID="Label9" runat="server" Text="✔Equipaje y pasajeros segun los parametros del avion" CssClass="textos"></asp:Label>
                <asp:Button ID="btmValidar" runat="server" Text="Validar" CssClass="botonvalidar" OnClick="btmValidar_Click"/>
            </div>
        </div>
    </div>
    <div class="centrocontent">
        <div class="cardcentro">
            <div class="cardcentro-header">
                <img src="../assets/logo.png" style="width:150px; height:125px; position:absolute; left:415px;"/>
                <h1>Panel de control de despegue</h1>
            </div>
            <div class="cardcentro-body">
                <div class="cardadentro">
                    <h4>Avion</h4>
                    <asp:Label ID="lblIdentificacionAvion" runat="server" Text="N.Vuelo: " CssClass="textos"></asp:Label>
                    <asp:Label ID="lblModelo" runat="server" Text="Identificacion del avion: " CssClass="textos"></asp:Label>
                    <asp:Label ID="lblPesoMaximo" runat="server" Text="Peso maximo: " CssClass="textos"></asp:Label>
                    <asp:Label ID="lblCapacidadPasajeros" runat="server" Text="Alcance: " CssClass="textos"></asp:Label>
                    <asp:Label ID="lblCapacidadCombustible" runat="server" Text="Velocidad: " CssClass="textos"></asp:Label>
                    <asp:Label ID="lblUltimaRevision" runat="server" Text="Capacidad: " CssClass="textos"></asp:Label>
                    <asp:Label ID="lblProximaRevision" runat="server" Text="Combustible: " CssClass="textos"></asp:Label>
                    <asp:Label ID="lblCompaniaAerea" runat="server" Text="Combustible: " CssClass="textos"></asp:Label>
                    <asp:Label ID="lblObservaciones" runat="server" Text="Combustible: " CssClass="textos"></asp:Label>
                    <asp:Label ID="lblEstado" runat="server" Text="Combustible: " CssClass="textos"></asp:Label>

                </div>
                <div class="carderecha">
                    <h1>Informacion del vuelo</h1>
                    <asp:Label ID="lblVuelo" runat="server" Text="N.Vuelo: " CssClass="textos"></asp:Label>
                    <asp:Label ID="lblOrigen" runat="server" Text="Hora de salida: " CssClass="textos"></asp:Label>
                    <asp:Label ID="lblDestino" runat="server" Text="Hora de llegada: " CssClass="textos"></asp:Label>
                    <asp:Label ID="lblHoraSalida" runat="server" Text="Cantidad de pasajeros: " CssClass="textos"></asp:Label>
                    <asp:Label ID="lblHoraLlegada" runat="server" Text="Duracion del vuelo: " CssClass="textos"></asp:Label>

                </div>
                <div class="botones">
                    <asp:Button ID="btmAutorizar" runat="server" Text="Autorizar Despegue" CssClass="botonautorizar" OnClick="btmAutorizar_Click"/>
                    <asp:Button ID="btmDenegar" runat="server" Text="Denegar Despegue" CssClass="botondenegar" OnClick="btmDenegar_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
