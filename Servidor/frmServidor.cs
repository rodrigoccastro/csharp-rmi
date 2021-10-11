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

namespace Servidor
{
    public partial class frmServidor : Form
    {
        public frmServidor()
        {
            InitializeComponent();
        }

        private void frmServidor_Load(object sender, EventArgs e)
        {
            lbl.Text = "Iniciando..."; ;
            TcpChannel ch = new TcpChannel(8085);
            ChannelServices.RegisterChannel(ch, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Gerenciador), "Gerenciador", WellKnownObjectMode.Singleton);
            lbl.Text = "Servidor em: tcp://192.168.6.151:8085/Gerenciador";
        }
    }
}