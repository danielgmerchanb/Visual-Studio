using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace EmuladorAutenticacion
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                HttpCookie parametrosAutenticacion = new HttpCookie("cookieSesion");

                parametrosAutenticacion.Values["signature"] = "uMXQTJ2bWT5qkEP6NdoAZG4m0Pw%3d";
                parametrosAutenticacion.Values["timestamp"] = DateTime.Now.ToString();
                parametrosAutenticacion.Values["UID"] = "e58dcef5-ea1b-43fd-895d-2761301619c2";
                parametrosAutenticacion.Values["portal"] = "publicar";
                parametrosAutenticacion.Values["nombre1"] = "Daniel";
                parametrosAutenticacion.Values["nombre2"] = "";
                parametrosAutenticacion.Values["apellido1"] = "Merchan";
                parametrosAutenticacion.Values["apellido2"] = "";
                parametrosAutenticacion.Values["idusuario"] = "33470";
                parametrosAutenticacion.Expires = DateTime.Now.AddHours(1);

                Response.Cookies.Add(parametrosAutenticacion);

                Response.Write("<script>alert('Usuario Autenticado.')</script>");
                //Response.Write("<meta http-equiv=\"Refresh\" content=\"5;url=http://www.mapaspublicar.com\">");
                //Response.Write("<meta http-equiv=\"Refresh\" content=\"5;url=http://localhost:27805/pagamanet/web/MyPA/MyDirectory.aspx?ipa=*&idi=1&mpy=JustView&eml=N\">");
                //Response.Write("<script>window.location=\"http://localhost:27805/pagamanet/web/MyPA/MyDirectory.aspx?ipa=*&idi=1&mpy=JustView&eml=N\";</script>");
                //Response.Redirect("http://localhost:27805/pagamanet/web/MyPA/MyDirectory.aspx?ipa=*&idi=1&mpy=JustView&eml=N", true);
                //Server.Transfer("http://localhost:27805/pagamanet/web/MyPA/MyDirectory.aspx?ipa=*&idi=1&mpy=JustView&eml=N", false);
            }
            catch (Exception exception)
            {
                Response.Write(string.Format("<script>alert('Se produjo una excepción. {0}')</script>", exception.Message));
            }
        }
    }
}
