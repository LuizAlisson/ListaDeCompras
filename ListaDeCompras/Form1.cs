using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDeCompras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdiocionar_Click(object sender, EventArgs e)
        {
            //Verificar se txbProduto está vázio:
            //.Lenght dimensiona o tamanho da string
            if (txbProduto.Text.Length == 0)

            {
                MessageBox.Show("O nome do produto não pode estar vazio!", 
                    "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Mudar a cor do fundo e a cor da letra:
                txbProduto.BackColor = Color.Red;
                txbProduto.ForeColor = Color.White;
            } 
            else if (txbProduto.Text.Length < 2)
            {
                MessageBox.Show("O nome do produto precisar ter no minimo duas letras", 
                    "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Mudar a cor de fundo e a cor da letra:
                txbProduto.BackColor = Color.Red;
                txbProduto.ForeColor = Color.White;
            }
            else
            {
                //Verificar se o item está na lista:
                if (libCompras.Items.Contains(txbProduto.Text))
                {
                    MessageBox.Show($"Já Existe {txbProduto.Text} na lista!",
                    "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Adicionar o item na lista:
                    libCompras.Items.Add(txbProduto.Text);
                    //Mostrar a mensagem de sucesso:
                    MessageBox.Show($"{txbProduto.Text} foi adicionado na lista de compras!",
                        "Show!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Retornar o txbProduto a cor normal:
                    txbProduto.BackColor = Color.White;
                    txbProduto.ForeColor = Color.Black;
                    //Limpar o campo:
                    txbProduto.Clear();
                }

            }
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Perguntar se realmente quer apagar
           DialogResult resposta = MessageBox.Show("Você tem certeza que quer apagar",
               "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Se optar por "sim", apagar
            if (resposta == DialogResult.Yes)
            {
                libCompras.Items.Clear();
                //Mensagem confirmando se a lista de comprar foi limpa
                MessageBox.Show("Sua lista de compra foi limpa!",
                    "OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Verificar se o usuário não selecionou nada:
            if(libCompras.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um item para remover!",
                    "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { //Salvar temporariamente o nome do item que será removido: 
                string itemRemovido = libCompras.SelectedItem.ToString();

                //Remover o item selecionado:
                libCompras.Items.RemoveAt(libCompras.SelectedIndex);

                MessageBox.Show($"O {itemRemovido} foi removido da lista!",
                    "Show!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
        private void txbProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //"Pressionar" o btnAdiocionar
                btnAdiocionar.PerformClick();
            }
        }
    }
}
