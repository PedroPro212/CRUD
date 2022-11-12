using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Urna.Eleitor
{
    public partial class CadastrarEleitor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var eleitor = new Classes.Eleitor();
            eleitor.Nome = txtNome.Text;
            eleitor.Titulo = txtTitulo.Text;
            eleitor.Zona = txtZona.Text;
            eleitor.Secao = txtSecao.Text;
            new Negocio.Eleitor().Create(eleitor);

            SiteMaster.AlertPersonalizado(this, "Cadastrado com sucesso");

            txtNome.Text = "";
            txtTitulo.Text = "";
            txtZona.Text = "";
            txtSecao.Text = "";
        }
    }
}