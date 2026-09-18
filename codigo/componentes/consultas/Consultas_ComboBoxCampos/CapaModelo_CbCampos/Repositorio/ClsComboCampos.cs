using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaModelo_CbCampos.Repositorio
{
    public class ClsComboCampos
    {

        public string Tabla { get; set; }

        private ClsConexion _Conexion = new ClsConexion();
        public void ConsultasMetPopularComboBox(string Tabla, ComboBox CboDestino)
        {
            CboDestino.Items.Clear();

            string Query = @"
        SELECT COLUMN_NAME
        FROM INFORMATION_SCHEMA.COLUMNS
        WHERE TABLE_SCHEMA = DATABASE()
        AND TABLE_NAME = ?
        ORDER BY ORDINAL_POSITION";

            OdbcConnection Conn = _Conexion.ConsultasFuncConexion();

            try
            {
                using (OdbcCommand Cmd = new OdbcCommand(Query, Conn))
                {
                    Cmd.Parameters.AddWithValue("@tabla", Tabla);

                    using (OdbcDataReader Reader = Cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            CboDestino.Items.Add(
                                Reader["COLUMN_NAME"].ToString()
                            );
                        }
                    }
                }
            }
            finally
            {
                _Conexion.ConsultasProcDesconexion(Conn);
            }
        }

        public void ConsultasMetPopularComboBox(ComboBox CboDestino)
        {
            ConsultasMetPopularComboBox(this.Tabla, CboDestino);
        }




    }
}
