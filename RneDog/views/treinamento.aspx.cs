using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RneDog.views
{
    public partial class treinamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTreinar_Click(object sender, EventArgs e)
        {
            Rna rna = new Rna();
            List<double[]> dados = new List<double[]>();

            try
            {
                StreamReader rd = new StreamReader(fileUpTreinamento.PostedFile.FileName);
                string linha = string.Empty;
                string[] reg;

                bool cabecalho = false;

                while ((linha = rd.ReadLine()) != null)
                {
                    if (!cabecalho)
                    {
                        cabecalho = true;
                    }
                    else
                    {
                        reg = linha.Split(',');

                        double[] dado = new double[5];

                        dado[0] = Convert.ToDouble(reg[0]);
                        dado[1] = Convert.ToDouble(reg[1]);
                        dado[2] = Convert.ToDouble(reg[2]);
                        dado[3] = Convert.ToDouble(reg[3]);
                        dado[4] = Convert.ToDouble(reg[5]);

                        dados.Add(dado);
                    }
                }
            }
            catch (Exception ex)
            {
                mssg.MessageFalse("Treinamento RNA", "Erro: " + ex.ToString(), this);
            }

            rna.Treinar(dados.ToArray());

            Session["rna"] = rna;

            grvFuncao.DataSource = rna.FuncaoNeuronio;
            grvFuncao.DataBind();
        }

        private bool Valida()
        {
            if (Parse.ToInt(txtVida.Text) == 0)
            {
                mssg.MessageFalse("Treinamento RNA", "Erro: Valor Para (Expectativa de Vida) não é valido", this);
                return false;
            }
            if (Parse.ToInt(txtAltura.Text) == 0)
            {
                mssg.MessageFalse("Treinamento RNA", "Erro: Valor Para (Altura do Cachorro) não é valido", this);
                return false;
            } if (Parse.ToInt(txtPeso.Text) == 0)
            {
                mssg.MessageFalse("Treinamento RNA", "Erro: Valor Para (Peso do Cachorro) não é valido", this);
                return false;
            }
            return true;
        }

        protected void btnDescobrir_Click(object sender, EventArgs e)
        {

            if (!Valida())
            {
                return;
            }

            Cachorro cao = new Cachorro(Parse.ToInt(txtVida.Text), Parse.ToInt(txtAltura.Text), Parse.ToInt(txtPeso.Text), Parse.ToInt(dpdInteligencia.SelectedValue));

            Rna rna = (Rna)Session["rna"];

            if (rna == null)
            {
                mssg.MessageFalse("Treinamento RNA", "Erro: É necessário fazer o treinamento", this);
                return;
            }

            string[] result = rna.Resultado(cao.Fator());

            lbNomeRaca.Text = "Raça: " + result[0];
            lbPorcentagem.Text = "Precisao: " + (Parse.ToDouble(result[1]) * 100).ToString("0.00");

            img_cao.ImageUrl = "~/image/" + result[0] + ".jpg";
        }
    }
}