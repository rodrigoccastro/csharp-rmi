using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Remoting.Channels.Http;
using System.Xml;
using System.Xml.XPath;
using System.Net;


namespace Cliente
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                iGerenciador obj = (iGerenciador) Activator.GetObject(typeof(iGerenciador), "tcp://192.168.6.151:8085/Gerenciador");
                string stringXml = obj.getXml(textBox1.Text);
                XmlObject xml = new XmlObject(stringXml, "lista");

                string texto = "";
                for (int i = 0; i < xml.getSize(); i++)
                {
                    for (int j = 0; j < xml.getListaCampos().Count; j++)
                    {
                        texto += xml.getNameCampo(j) + ": " + xml.getValueByIndex(i, j) + " - ";
                    }
                    texto += "\n";
                }
                MessageBox.Show(texto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}