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
      
        public UCComboboxCampos()
        {
            InitializeComponent();
        }

        public void llenarCombo(string _tabla)
        {
           var dtTabla = _Controlador.enviarDatos(_tabla);

            ConsultasCboCampo.Items.Clear();

           foreach (DataColumn columna in dtTabla.Columns)
            {
                ConsultasCboCampo.Items.Add(columna.ColumnName);
            }

            ConsultasCboCampo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ConsultasCboCampo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

    }
}
