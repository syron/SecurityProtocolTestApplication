using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityProtocolTestClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var securityProtocols = Enum.GetValues(typeof(SecurityProtocolType)).Cast<SecurityProtocolType>();
            comboBoxSecurityProtocols.Items.AddRange(securityProtocols.Select(sp => sp.ToString()).ToArray());
            pictureBox1.Image.RotateFlip((RotateFlipType.Rotate90FlipNone));
            pictureBox1.Refresh();
        }

        private async void buttonSendRequest_Click(object sender, EventArgs e)
        {
            var securityProtocol = comboBoxSecurityProtocols.SelectedItem;
            var url = textBoxUrl.Text;
            if (securityProtocol == null || string.IsNullOrWhiteSpace(securityProtocol.ToString()))
            {
                MessageBox.Show("Please select a security protocol.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Please provide an URL.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try { 
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)Enum.Parse(typeof(SecurityProtocolType), securityProtocol.ToString());
                    using (var client = new HttpClient())
                    {
                        var t_response = await client.GetAsync(url);

                        labelStatusCodeValue.Text = $"{t_response.StatusCode.ToString()} ({(int)t_response.StatusCode})";

                        var content = await t_response.Content.ReadAsStringAsync();
                        textBoxContent.Text = content;
                        textBoxException.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    textBoxException.Text = ex.ToString();
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var dialogRslt = MessageBox.Show("ROBERT MAYER AWESOMENESS!!!!", "AWESOMENESS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (dialogRslt == DialogResult.Yes)
            {

            }
            else if (dialogRslt == DialogResult.No)
            {

            }
            else if (dialogRslt == DialogResult.Cancel)
            {

            }
            else
            {

            }
        }
    }
}