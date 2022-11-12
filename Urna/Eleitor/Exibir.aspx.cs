using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Urna.Eleitor
{
    public partial class Exibir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            var eleitor = new Negocio.Eleitor().Read("", txtNome.Text, "", "", "");
            Session["dados"] = eleitor;
            grdEleitor.DataSource = eleitor;
            grdEleitor.DataBind();
        }

        protected void btnCadastrarEleitor_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastrarEleitor.aspx");
        }

        protected void grdEleitor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var eleitor = (List<Classes.Eleitor>)Session["dados"];

            if(e.CommandName == "excluir")
            {
                if(new Negocio.Eleitor().Delete(eleitor[index].Id))
                {
                    SiteMaster.AlertPersonalizado(this, "Eleitor exluído com sucesso.");
                }
                else
                {
                    SiteMaster.AlertPersonalizado(this, "Deu merda");
                }
                btnPesquisar_Click(null, null);
            }
            if(e.CommandName == "editar")
            {
                Response.Redirect("AtualizarEleitor.aspx?id=" + eleitor[index].Id);
            }
        }
    }
}