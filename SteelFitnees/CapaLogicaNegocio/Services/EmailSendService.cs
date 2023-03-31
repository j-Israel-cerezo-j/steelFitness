using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaLogicaNegocio.Adds;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.Inserts;
using CapaLogicaNegocio.utils;
using Validaciones.utils;
using CapaLogicaNegocio.Lists;
using System.Net.Mime;
using System.IO;
using System.Web;

namespace CapaLogicaNegocio.Services
{
    public  class EmailSendService
    {
        private ContactList contactList = new ContactList();
        public bool send(Dictionary<string, string> request, HttpPostedFile file)
        {

            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            if (camposEmptysOrNull.Count == 0)
            {
                try
                {
                    string affair = RetrieveAtributes.values(request, "asunto");
                    string bodyEmail = RetrieveAtributes.values(request, "info");
                    string senderMail = RetrieveAtributes.values(request, "senderMail");
                    string senderPassword = RetrieveAtributes.values(request, "senderPassword");
                    string smpEmailSend = "";
                    int portSmp = 0;
                    if (senderMail.Contains("outlook")|| senderMail.Contains("hotmail"))
                    {
                        smpEmailSend = "smtp-mail.outlook.com";
                        portSmp = 587;
                    }
                    else if (senderMail.Contains("gmail"))
                    {
                        smpEmailSend = "smtp.gmail.com";
                        portSmp = 25;
                    }
                    if (smpEmailSend == "")
                    {
                        throw new ServiceException(MessageErrors.MessageErrors.invalidSmpEmail);
                    }
                    // Direcciones de correo electrónico de los destinatarios
                    var contacts = contactList.contacts();
                    if (contacts.Count == 0)
                    {
                        throw new ServiceException(MessageErrors.MessageErrors.empetyContacts);
                    }
                    // Crear un objeto MailMessage
                    MailMessage mensaje = new MailMessage();

                    // Agregar los destinatarios al mensaje
                    foreach (var contact in contacts)
                    {
                        mensaje.To.Add(contact.email);
                    }
                    // Obtener el archivo cargado mediante el control HttpPostedFile
                    if (file != null && file.ContentLength > 0)
                    {
                        // Convertir el archivo a un arreglo de bytes
                        byte[] fileData = null;
                        using (var binaryReader = new BinaryReader(file.InputStream))
                        {
                            fileData = binaryReader.ReadBytes(file.ContentLength);
                        }

                        // Adjuntar el archivo al mensaje de correo electrónico
                        MemoryStream stream = new MemoryStream(fileData);
                        Attachment attachment = new Attachment(stream, file.FileName);
                        mensaje.Attachments.Add(attachment);
                    }
                    // Configurar los demás campos del mensaje (asunto, cuerpo, etc.)
                    mensaje.From = new MailAddress(senderMail);
                    mensaje.Subject = affair;
                    mensaje.Body = bodyEmail;

                    // Crear un objeto SmtpClient para enviar el correo
                    SmtpClient cliente = new SmtpClient(smpEmailSend);
                    cliente.Port = portSmp; // Puerto del servidor SMTP
                    cliente.Credentials = new NetworkCredential(senderMail, senderPassword);
                    cliente.EnableSsl = true; // Usar SSL para conexión segura

                    // Enviar el mensaje
                    cliente.Send(mensaje);
                    ban = true;
                }
                catch (ServiceException se)
                {
                    throw new ServiceException(se.getMessage());
                }
                catch (Exception e)
                {                    
                    throw new ServiceException("Error al enviar el correo");
                }
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException(item.Key + " esta vacío");
                    }
                }
            }
            return ban;
        }
    }
}
