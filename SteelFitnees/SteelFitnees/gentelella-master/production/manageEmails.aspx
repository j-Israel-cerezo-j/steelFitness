<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageEmails.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.manageEmails" MasterPageFile="~/gentelella-master/production/adminMaster.Master" %>

<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">
	<title>Gestionar Correos</title>
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
</asp:content> 

<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="x_panel">
		<div class="x_content">
			<h1 id="labelMsjAction">Redactar correo</h1>
			<br>
			<form id="form1" class="row g-3 needs-validation" novalidate>
				<div class="row ">
					<label class="form-label"><b>Asunto:</b></label>
					<div class="col-lg-6 col-md-6 col-sm-12 col-xsm-12 form-group" style="margin-top:15px;padding-right: 0px;padding-left:10px;">						
						<input  style="border-radius:6px" type="text" class="form-control has-feedback-left" required="required" name="asunto" id="asunto" placeholder="Asunto del correo"  onkeyup="onkeyupInputEmtyy('asunto')">
						<div class="valid-feedback">
								¡ Buen trabajo!
						</div>
						<div class="invalid-feedback">
							El asunto del correo es requerido
						</div>
						<span class="fa fa-envelope form-control-feedback left" aria-hidden="true"></span>
					</div>
				</div>
				<div class="row" style="justify-content:center">
					<div class="col-lg-12 col-md-12 col-sm-12 col-xsm-12 form-group" style="margin-top:15px;padding-right: 0px;padding-left:10px;">
						<textarea style="border-radius:6px" class="form-control" rows="12" required="required" name="info" id="info" placeholder="Redacte el correo a mandar aqui por favor"  onkeyup="onkeyupInputEmtyy('info')"></textarea>						
						<div class="valid-feedback">
								¡ Buen trabajo!
						</div>
						<div class="invalid-feedback">
							Favor de redactar el correo a mandar
						</div>
					</div>
				</div>
				<div class="row  justify-content-center" style="margin-top:30px" >
					<div class="col-md-6 col-sm-6">
						<div class="form-group row">
							<div class="col-md-6 col-sm-6" id="ctrl-principal">
								<button type="button" class="btn btnSuccesss reflejo" id="add" onclick="send()">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-send-check-fill" viewBox="0 0 16 16">
										<path d="M15.964.686a.5.5 0 0 0-.65-.65L.767 5.855H.766l-.452.18a.5.5 0 0 0-.082.887l.41.26.001.002 4.995 3.178 1.59 2.498C8 14 8 13 8 12.5a4.5 4.5 0 0 1 5.026-4.47L15.964.686Zm-1.833 1.89L6.637 10.07l-.215-.338a.5.5 0 0 0-.154-.154l-.338-.215 7.494-7.494 1.178-.471-.47 1.178Z"/>
										<path d="M16 12.5a3.5 3.5 0 1 1-7 0 3.5 3.5 0 0 1 7 0Zm-1.993-1.679a.5.5 0 0 0-.686.172l-1.17 1.95-.547-.547a.5.5 0 0 0-.708.708l.774.773a.75.75 0 0 0 1.174-.144l1.335-2.226a.5.5 0 0 0-.172-.686Z"/>
									</svg>
									Enviar
								</button>
							</div>
							<div class="col-lg-4 col-md-4 col-sm-9">
								<button style="padding:10px" class="btn btn-secondary reflejo" type="reset">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-counterclockwise" viewBox="0 0 16 16">
									  <path fill-rule="evenodd" d="M8 3a5 5 0 1 1-4.546 2.914.5.5 0 0 0-.908-.417A6 6 0 1 0 8 2v1z"/>
									  <path d="M8 4.466V.534a.25.25 0 0 0-.41-.192L5.23 2.308a.25.25 0 0 0 0 .384l2.36 1.966A.25.25 0 0 0 8 4.466z"/>
									</svg>
									Limpiar
								</button>
							</div>
						</div>
					</div>
				</div>
			</form>
			<%-- Tabla Inicio--%>
			<div class="clearfix"></div>
			<div id="containerTableBranches"></div>			
			<%-- Tabla Final--%>			
		</div>
	</div>
    <script src="js/personalizados/SendEmails/ajax/sendAjax.js"></script>
    <script src="js/personalizados/SendEmails/SendEmail.js"></script>

	<script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>	
	<script src="js/personalizados/utils/switchTableOnkeyup.js"></script>
    <script src="js/personalizados/utils/Ajax/onkeyupSearchCatalogos.js"></script>
	<script src="js/personalizados/utils/onkeyupInputEmpty.js"></script>
    <script src="js/personalizados/utils/buildMsjValidOrInvalid.js"></script>    
    <script src="js/personalizados/utils/onkeyupNoSelectInSlc.js"></script>
</asp:content> 