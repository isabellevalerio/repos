using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recuperacao_uc11
{
    public partial class Tela_principal : Form
    {

        // Variaveis Publicas para o MySQL
        string servidor;
        MySqlConnection conexao;
        MySqlCommand comando;
        
        string id;

        public Tela_principal()
        {
            InitializeComponent();

            // Utilização das variaveis publicas para o MySQL

            servidor = "Server=localhost;Database=mydb;Uid=root;Pwd=";
            conexao = new MySqlConnection(servidor);
            comando = conexao.CreateCommand();

            ATUALIZA_CADASTRO();

        }

        private void ATUALIZA_CADASTRO()
        {
            try
            {
                conexao.Open();

                comando.CommandText = "SELECT * FROM tbl_cadastro;";
                MySqlDataAdapter adaptadorCadastro = new MySqlDataAdapter(comando);
                DataTable tableCadastro = new DataTable();
                adaptadorCadastro.Fill(tableCadastro);

                dataGridViewCADASTRO.DataSource = tableCadastro;
                dataGridViewCADASTRO.Columns["id"].HeaderText = "Código";
            }
            catch (Exception erro_mysql)
            {
                MessageBox.Show(erro_mysql.Message);
            }
            finally
            {
                conexao.Close();
            }

        }
        private void LIMPAR_FORMULARIO()
        {
            textBoxusuario.Clear();
            textBoxsenha.Clear();
            textBoxacesso.Clear();
            textBoxnome.Clear();
            textBoxemail.Clear();
            textBoxcelular.Clear();
            textBoxtelefone.Clear();

        }

        private void buttonSALVAR_Click(object sender, EventArgs e)
        {
            usuario.ForeColor = Color.Black;
            senha.ForeColor = Color.Black;
            try
            {
                if (textBoxusuario.Text != "" && textBoxsenha.Text != "")
                {
                    conexao.Open();
                    comando.CommandText = "INSERT INTO tbl_cadastro (usuario, senha, nivel_acesso, nome, email, celular, telefone) VALUES ('" + textBoxusuario.Text + "', '" + textBoxsenha.Text + "', '" + textBoxacesso.Text + "' , '" + textBoxnome.Text + "', '" + textBoxemail.Text + "', '" + textBoxcelular.Text + "', '" + textBoxcelular.Text + "');";
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastrado com sucesso!");

                    LIMPAR_FORMULARIO();

                }
                else
                {
                    MessageBox.Show("Usuário e/ou senha estão em BRANCO! Por favor preencha!");

                    if (textBoxusuario.Text == "" && textBoxsenha.Text == "")
                    {
                        textBoxusuario.Focus();
                        usuario.ForeColor = Color.Red;
                    }
                    else
                    {
                        textBoxsenha.Focus();
                        senha.ForeColor = Color.Red;
                    }
                }

            }
            catch (Exception erro_mysql)
            {
                // Mensagem de erro - MySQL
                MessageBox.Show(erro_mysql.Message);

                // Mensagem de erro - USUÁRIO
                //MessageBox.Show("Erro de Sistema. Solicite ajuda!");

            }
            finally
            {
                conexao.Close();

            }
            ATUALIZA_CADASTRO();
        }

        private void buttonALTERAR_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                comando.CommandText ="UPDATE tbl_cadastro SET usuario = '" + textBoxusuario.Text + "', senha = '" + textBoxsenha.Text + "', nivel_acesso = '" + textBoxacesso.Text + "', nome = '" + textBoxnome.Text + "', email = '" + textBoxemail.Text + "', celular = '" + textBoxcelular.Text + "', telefone = '" + textBoxtelefone.Text + "' WHERE  id = " + id + ";";               
                comando.ExecuteNonQuery();
                int resultado = comando.ExecuteNonQuery();
                if (resultado > 0)
                {
                    MessageBox.Show("Cadastro atualizado com sucesso! - " + resultado + " registros atualizados...");

                }
                else
                {
                    MessageBox.Show("Cadastro não encontrado!");
                }

            }
            catch (Exception erro_mysql)
            {
                // Mensagem de erro - MySQL
                MessageBox.Show(erro_mysql.Message);

                // Mensagem de erro - USUÁRIO
                // MessageBox.Show("Erro de Sistema. Solicite ajuda!");
            }
            finally
            {
                conexao.Close();
            }
            ATUALIZA_CADASTRO();
            LIMPAR_FORMULARIO();

        }

        private void buttonAPAGAR_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este registro?", "Atenção!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    conexao.Open();

                    comando.CommandText = "DELETE FROM tbl_cadastro WHERE id = " + id + ";";
                    int resultado = comando.ExecuteNonQuery();
                    if (resultado > 0)
                    {
                        MessageBox.Show("Cadastro removido com sucesso! - " + resultado + " registros removidos...");
                        LIMPAR_FORMULARIO();
                    }
                    else
                    {
                        MessageBox.Show("Cadastro não encontrado!");
                    }

                }
                catch (Exception erro_mysql)
                {
                    // Mensagem de erro - MySQL
                    MessageBox.Show(erro_mysql.Message);

                    // Mensagem de erro - USUÁRIO
                    //MessageBox.Show("Erro de Sistema. Solicite ajuda!");
                }
                finally
                {
                    conexao.Close();
                }
                ATUALIZA_CADASTRO();
            }
            else
            {
                // MessageBox.Show("NÃO");
            }
            LIMPAR_FORMULARIO();


        }

        private void buttonBUSCA_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxPESQUISA.Text == "")
                {
                    ATUALIZA_CADASTRO();

                }
                else
                {


                    conexao.Open();

                    comando.CommandText = "SELECT * FROM tbl_cadastro WHERE nome LIKE '%" + textBoxPESQUISA.Text + "%';";
                    MySqlDataAdapter adaptadorAgenda = new MySqlDataAdapter(comando);
                    DataTable tableAGENDA = new DataTable();
                    adaptadorAgenda.Fill(tableAGENDA);

                    dataGridViewCADASTRO.DataSource = tableAGENDA;
                    dataGridViewCADASTRO.Columns["id"].HeaderText = "Código";
                }
            }
            catch (Exception erro_mysql)
            {
                MessageBox.Show(erro_mysql.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void dataGridViewCADASTRO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = dataGridViewCADASTRO.CurrentRow.Cells[0].Value.ToString();

            textBoxusuario.Text = dataGridViewCADASTRO.CurrentRow.Cells[1].Value.ToString();
            textBoxsenha.Text = dataGridViewCADASTRO.CurrentRow.Cells[2].Value.ToString();
            textBoxacesso.Text = dataGridViewCADASTRO.CurrentRow.Cells[3].Value.ToString();
            textBoxnome.Text = dataGridViewCADASTRO.CurrentRow.Cells[4].Value.ToString();
            textBoxemail.Text = dataGridViewCADASTRO.CurrentRow.Cells[5].Value.ToString();
            textBoxcelular.Text = dataGridViewCADASTRO.CurrentRow.Cells[6].Value.ToString();
            textBoxtelefone.Text = dataGridViewCADASTRO.CurrentRow.Cells[7].Value.ToString();
        }
    }


}     



   


