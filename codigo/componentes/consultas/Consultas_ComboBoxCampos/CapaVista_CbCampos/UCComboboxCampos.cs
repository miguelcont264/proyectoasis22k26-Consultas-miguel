using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador_CbCampos;

namespace CapaVista_CbCampos
{
    public partial class UCComboboxCampos : UserControl
    {
        ClsObtenerDatos _Controlador = new ClsObtenerDatos();
        string _TablaActual;
        public UCComboboxCampos()
        {
            InitializeComponent();
        }

        public void ConsultasMetCargarCampos(string tabla)
        {
            
            ConsultasCboCampo.Items.Clear();

            _Controlador.ConsultasMetPoblarComboCampos(
                tabla,
                 ConsultasCboCampo);
        }

    }
}
