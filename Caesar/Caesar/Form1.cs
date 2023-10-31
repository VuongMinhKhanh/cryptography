using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caesar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChuyenCaesar_Click(object sender, EventArgs e)
        {
            if (txtCaesar.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập văn bản", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCaesar.Focus();
                return;
            }
            if (cbAlgo.SelectedIndex == 0)
                txtMaCaesar.Text = Caesar.Mahoa(txtCaesar.Text,int.Parse(cbxKeyCaesar.Text));
            else
                txtMaCaesar.Text = Vigenere.Mahoa(txtCaesar.Text, Vigenere.taokhoa(txtCaesar.Text, Vigenere.chuyenmakey(txtKey.Text)));
        }

        private void BtnDichCaesar_Click(object sender, EventArgs e)
        {
            if (txtMaCaesar.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập văn bản mã hóa",
                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCaesar.Focus();
                return;
            }
            if (cbAlgo.SelectedIndex == 0)
                txtCaesar.Text = Caesar.GiaiMa(txtMaCaesar.Text, int.Parse(cbxKeyCaesar.Text));
            else
                txtCaesar.Text = Vigenere.Giaima(txtMaCaesar.Text, Vigenere.taokhoa(txtMaCaesar.Text, Vigenere.chuyenmakey(txtKey.Text)));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
