<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productsByBranche.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.productsByBranche" MasterPageFile="~/gentelella-master/production/principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <meta charset="utf-8"/>
    <meta http-equiv="x-ua-compatible" content="ie=edge"/>    
    <meta name="description" content=""/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="manifest" href="site.webmanifest"/>
    <link rel="shortcut icon" type="templates/fitnessclub-master/image/x-icon" href="templates/fitnessclub-master/assets/img/favicon.ico"/>
	<!-- CSS here -->
	<link href="bootstrap-5.0.2-dist/css/bootstrap.min.css" rel="stylesheet" />
	
	<link rel="stylesheet" href="templates/fitnessclub-master/assets/css/style.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="home-blog-area section-padding30">
            <div class="container">
                
                <!-- Section Tittle -->
                <div class="row justify-content-center">
                    <div class="col-lg-7 col-md-9 col-sm-10">
                        <div class="section-tittle text-center mb-100">
                            <span>Productos de la sucursal</span>
                             <select class="form-select form-select-lg mb-3" id="branches" onchange="buildProductsByBranche()">
                            </select>
                            <h2 id="nameBranche"></h2>
                        </div>
                    </div>
                </div>
                <div class="row" style="justify-content: center;" id="containerCardsProducts">
                    <h2 style="text-align:center">Selecciona una sucursal por favor</h2>
                </div>
                 <div class="col-xl-2 col-lg-2 col-md-3">
                    <a href="index.aspx" class="btn wantToWork-btn f-right">Regresar</a>
                </div>
            </div>
        </section>
    <script src="js/personalizados/productByBranches/requestBranches.js"></script>
    <script src="js/personalizados/productByBranches/build/slc/buildBranchesSlc.js"></script>
    <script src="js/personalizados/productByBranches/requestProductByBranche.js"></script>
    <script src="js/personalizados/productByBranches/build/buildCardsProducts.js"></script>
    <script src="js/personalizados/utils/Ajax/request.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            requestBranches()
        }
    </script>

</asp:Content>