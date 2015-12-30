<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaAdmin.Master" AutoEventWireup="true" CodeBehind="IndexAdmin.aspx.cs" Inherits="SiGMA.IndexAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="slider-container">
            <div class="container">
                <div class="row">
                    <div class="col-sm-10 col-sm-offset-1 slider">
                        <div class="flexslider">
                            <ul class="slides">
                                <li data-thumb="base/img/slider/sliderRegistrarMascota.jpg">
                                    <img src="base/img/slider/sliderRegistrarMascota.jpg">
                                    <div class="flex-caption">
                                    	Registrando tu mascota aumentaras considerablemente la posibilidad de recuperación en caso de robo o extravío.
                                    </div>
                                </li>
                                <li data-thumb="base/img/slider/sliderPerdida.jpg">
                                    <img src="base/img/slider/sliderPerdida.jpg">
                                    <div class="flex-caption">
                                    	En caso de extravío de tu mascota, brindaremos un mapa con su posible localización para patrullas de busqueda más eficaces.
                                    </div>
                                </li>
                                <li data-thumb="base/img/slider/sliderHallazgo.jpg">
                                    <img src="base/img/slider/sliderHallazgo.jpg">
                                    <div class="flex-caption">
                                    	Nuestros voluntarios se encargaran de darte aviso al hallar tu mascota perdida y de cuidarla hasta tu reencuentro con ella.
                                    </div>
                                </li>
                                <li data-thumb="base/img/slider/sliderAdoptacion.jpg">
                                    <img src="base/img/slider/sliderAdoptacion.jpg">
                                    <div class="flex-caption">
                                    	Un perro o gato rescatado es facil de adaptar, son mas receptivos y agradecidos. ¡ Adopta una mascota ! 
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

