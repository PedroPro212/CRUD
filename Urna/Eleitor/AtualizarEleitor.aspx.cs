using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Urna.Eleitor
{
    public partial class AtualizarEleitor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = Request.QueryString["id"].ToString();
                var eleitor = new Negocio.Eleitor().Read(id);
                if(eleitor == null)
                {
                    SiteMaster.AlertPersonalizado(this, "Deu B.O", "Exibir.aspx");
                    return;
                }

                txtNome.Text = eleitor.Nome;
                txtTitulo.Text = eleitor.Titulo;
                txtZona.Text = eleitor.Zona;
                txtSecao.Text = eleitor.Secao;
            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            var eleitor = new Classes.Eleitor();
            eleitor.Id = Convert.ToInt32(Request.QueryString["id"].ToString());
            eleitor.Nome = txtNome.Text;
            eleitor.Titulo = txtTitulo.Text;
            eleitor.Zona = txtZona.Text;
            eleitor.Secao = txtSecao.Text;

            new Negocio.Eleitor().Update(eleitor);
            SiteMaster.AlertPersonalizado(this, "Eleitor Atualizado com sucesso!", "Exibir.aspx");
        }
    }
}