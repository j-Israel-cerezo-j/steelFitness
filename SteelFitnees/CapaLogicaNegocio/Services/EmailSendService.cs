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
namespace CapaLogicaNegocio.Services
{
    public  class EmailSendService
    {
        private ContactList contactList = new ContactList();
        public bool send(Dictionary<string, string> request)
        {

            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            if (camposEmptysOrNull.Count == 0)
            {
                try
                {
                    string affair = RetrieveAtributes.values(request, "asunto");
                    string bodyEmail = RetrieveAtributes.values(request, "info");
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

                    // Configurar los demás campos del mensaje (asunto, cuerpo, etc.)
                    mensaje.From = new MailAddress("correo remitente");
                    mensaje.Subject = affair;
                    mensaje.Body = bodyEmail;

                    // Crear un objeto SmtpClient para enviar el correo
                    SmtpClient cliente = new SmtpClient("smtp-mail.outlook.com");
                    cliente.Port = 587; // Puerto del servidor SMTP
                    cliente.Credentials = new NetworkCredential("correo remitente", "contraseña");
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
