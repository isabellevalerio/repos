using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recuperacao_uc11
{
    public partial class Tela_inicial : Form
    {
        int tentativas = 1;
        

        public Tela_inicial()
        {
            InitializeComponent();
        }

        private void ButtonENTRAR_Click(object sender, EventArgs e)
        {
            string usuario = "isabelle";
            string senha = "0908";   

            if (usuario == textBoxUSUARIO.Text && senha == textBoxSENHA.Text )
            {
                this.Hide();
                Form TelaMenu = new Tela_principal();
                TelaMenu.Closed += (s, args) => this.Close();
                TelaMenu.Show();

                // Form TelaMenu = new tela_principal();
                //TelaMenu.Closed += (s, args) => this.Close();
                // TelaMenu.Show();

            }
            else
            {
                MessageBox.Show("Usuário e/ou Senha incorretos!\n\nVocê utilizou " + tentativas + "  tentativas");
                tentativas++;

                {
  
                    if (tentativas > 3)
                    {
                        MessageBox.Show("Número máximo de tentativas excedido. O programa será encerrado.");
                        Application.Exit();
                    }
                }
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
    }
 

