<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexUser.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.indexUser" MasterPageFile="~/gentelella-master/production/adminMaster.Master" %>

<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">
	<title>Steel fitness - Inicio</title>
	<script src="../vendors/validator/multifield.js"></script>
    <script src="../vendors/validator/validator.js"></script>
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
</asp:content> 
<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-7 col-md-9 col-sm-10">
                <div class="section-tittle text-center mb-100">
                    <h2><span>Selecciona una sucursal para checar sus comentarios dados por lus usuarios</span></h2>
                    <select class="form-select form-select-lg mb-3 mt-5" id="branches" onchange="requestComments()" >
                    </select>
                    <h2 style="margin:10px" class="mt-3" id="nameBranche"></h2>                    
                </div>
            </div>
        </div>
        <div class="row" style="display:none;margin-top:10px" id="containerSlcWeeks">
            <div class="col-lg-3 col-md-3 col-sm-10">
                <div class="section-tittle mb-100">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-filter-left" viewBox="0 0 16 16">
					    <path d="M2 10.5a.5.5 0 0 1 .5-.5h3a.5.5 0 0 1 0 1h-3a.5.5 0 0 1-.5-.5zm0-3a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5zm0-3a.5.5 0 0 1 .5-.5h11a.5.5 0 0 1 0 1h-11a.5.5 0 0 1-.5-.5z"/>
				    </svg>
                    <label class="control-label">Filtrar comentarios por semana...</label>                    
                    <select class="form-select" id="weeks" onchange="requestFilterByDates()" >
                    </select>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-10 ml-3">
                <h2 style="text-align:center" id="weekSelectedText"></h2>
            </div>
        </div>
        <div id="containerCardsComments" class="row mt-3" style="width: 100%;"></div>
    </div>
    <div id="carouselExampleDark" class="carousel carousel-dark slide" data-bs-ride="carousel">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="1" aria-label="Slide 2"></button>
            <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="2" aria-label="Slide 3"></button>
        </div>
        <div class="carousel-inner">
            <div class="carousel-item active" data-bs-interval="4000">
                <img src="sources/slide2.jpg" class="d-block w-100" alt="..." width="100">
                <div class="carousel-caption d-none d-md-block">
                    <h2 style="color:white" class="section-heading text-uppercase">INSTALACIONES DE PRIMER NIVEL</h2>
                    <p style="color:white">Some representative placeholder content for the first slide.</p>
                </div>
            </div>
            <div class="carousel-item" data-bs-interval="4000">
                <img src="sources/runn.jpg" class="d-block w-100" alt="...">
                <div class="carousel-caption d-none d-md-block">
                    <h2 style="color:white" class="section-heading text-uppercase">ENTRENADORES CERTIFICADOS</h2>
                    <p style="color:white">Some representative placeholder content for the second slide.</p>
                </div>
            </div>
            <div class="carousel-item" data-bs-interval="4000">
                <img src="sources/slide1.jpg" class="d-block w-100" alt="...">
                <div class="carousel-caption d-none d-md-block">
                    <h2 style="color:white" class="section-heading text-uppercase">EXCELENTE UBICACION</h2>
                    <p style="color:white">Some representative placeholder content for the third slide.</p>
                </div>
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span style="color:white" class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span style="color:white" class="visually-hidden">Next</span>
        </button>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
    <!-- Core theme JS-->
    <script src="frontend/js/scriptIndex.js"></script>
    <!-- * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *-->
    <!-- * *                               SB Forms JS                               * *-->
    <!-- * * Activate your form at https://startbootstrap.com/solution/contact-forms * *-->
    <!-- * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *-->
    <script src="https://cdn.startbootstrap.com/sb-forms-latest.js"></script>
    <script src="js/personalizados/productByBranches/requestBranches.js"></script>
    <script src="js/personalizados/productByBranches/build/slc/buildBranchesSlc.js"></script>
    <script src="js/personalizados/indexUser/requestComments.js"></script>
    <script src="js/personalizados/indexUser/build/buildCardsComments.js"></script>
    <script src="js/personalizados/indexUser/requestFilterByDates.js"></script>

    <script src="js/personalizados/utils/Ajax/request.js"></script>
    <script src="js/personalizados/indexUser/build/buildWeeksSlc.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            requestBranches()

        }
    </script>
        
</asp:content> 