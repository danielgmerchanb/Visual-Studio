using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using KatarrContractError.Properties;

namespace KatarrContractError
{
    public class Program
    {
        private const string INSTRUCCIÓN_INSERCION = @"INSERT INTO [Temporal].[dbo].[LogKatarrContractError]
           ([Fecha]
           ,[Objeto]
           ,[Envio]
           ,[Movimiento]
           ,[ValorObjeto]
           ,[Mensaje]
           ,[CodMensaje]
           ,[StackError])
     VALUES
           (@Fecha
           ,@Objeto
           ,@Envio
           ,@Movimiento
           ,@ValorObjeto
           ,@Mensaje
           ,@CodMensaje
           ,@StackError)";

        private static string LeerDato(StreamReader flujoArchivoContractError, StreamWriter flujoArchivoLog, int numeroFila)
        {
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                if (flujoArchivoContractError.Peek() != -1)
                {
                    char caracter = Convert.ToChar(flujoArchivoContractError.Read());

                    while (caracter != '¬' && caracter != '|')
                    {
                        stringBuilder.Append(caracter);

                        caracter = Convert.ToChar(flujoArchivoContractError.Read());
                    }
                }
            }
            catch (Exception excepcion)
            {
                RegistrarLog(flujoArchivoLog, excepcion, numeroFila);
            }

            return stringBuilder.ToString();
        }

        private static void RegistrarLog(StreamWriter flujoArchivoLog, Exception excepcion, int numeroFila)
        {
            flujoArchivoLog.Write("Número Fila: {0} ¬ Fecha: {1} ¬ Error: {2} ¬ Mensaje: {3} ¬ Stack Trace: {4}|", numeroFila, DateTime.Now, excepcion.GetType().Name, excepcion.Message, excepcion.StackTrace);
        }

        private static void CargarTabla(SqlConnection sqlConnection, Dictionary<string, string> parametros, StreamWriter flujoArchivoLog, int numeroFila)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(INSTRUCCIÓN_INSERCION, sqlConnection);

                sqlCommand.CommandType = CommandType.Text;

                foreach (KeyValuePair<string, string> parametro in parametros)
                {
                    sqlCommand.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception excepcion)
            {
                RegistrarLog(flujoArchivoLog, excepcion, numeroFila);
            }
        }

        public static void Main(string[] args)
        {
            DateTime horaInicio = DateTime.Now;
            TimeSpan duracion = new TimeSpan();

            StreamReader flujoArchivoContractError = null;
            StreamWriter flujoArchivoLog = null;
            SqlConnection sqlConnection = null;

            int numeroFila = 1;

            try
            {
                flujoArchivoContractError = new StreamReader(Settings.Default.RutaArchivoContractError, Encoding.UTF8);
                flujoArchivoLog = new StreamWriter(Settings.Default.RutaArchivoLog, true, Encoding.UTF8);
                sqlConnection = new SqlConnection(Settings.Default.CadenaBaseDatos);

                sqlConnection.Open();

                while (!flujoArchivoContractError.EndOfStream)
                {
                    Dictionary<string, string> filaDatos = new Dictionary<string, string>();

                    filaDatos.Add("@Fecha", LeerDato(flujoArchivoContractError, flujoArchivoLog, numeroFila));
                    filaDatos.Add("@Objeto", LeerDato(flujoArchivoContractError, flujoArchivoLog, numeroFila));
                    filaDatos.Add("@Envio", LeerDato(flujoArchivoContractError, flujoArchivoLog, numeroFila));
                    filaDatos.Add("@Movimiento", LeerDato(flujoArchivoContractError, flujoArchivoLog, numeroFila));
                    filaDatos.Add("@ValorObjeto", LeerDato(flujoArchivoContractError, flujoArchivoLog, numeroFila));

                    string mensaje = LeerDato(flujoArchivoContractError, flujoArchivoLog, numeroFila);
                    filaDatos.Add("@Mensaje", mensaje.Substring(0, mensaje.Length >= 2000 ? 2000 : mensaje.Length));

                    filaDatos.Add("@CodMensaje", LeerDato(flujoArchivoContractError, flujoArchivoLog, numeroFila));
                    filaDatos.Add("@StackError", LeerDato(flujoArchivoContractError, flujoArchivoLog, numeroFila));

                    CargarTabla(sqlConnection, filaDatos, flujoArchivoLog, numeroFila);

                    duracion = new TimeSpan(DateTime.Now.Ticks - horaInicio.Ticks);

                    Console.WriteLine("Número Fila: {0}", numeroFila++);
                    Console.WriteLine("Duración: {0} Horas, {1} Minutos, {2} Segundos.", duracion.Hours, duracion.Minutes, duracion.Seconds);
                    Console.WriteLine();
                }

                flujoArchivoContractError.Close();

                duracion = new TimeSpan(DateTime.Now.Ticks - horaInicio.Ticks);

            }
            catch (Exception excepcion)
            {
                RegistrarLog(flujoArchivoLog, excepcion, numeroFila);
            }
            finally
            {
                if (flujoArchivoContractError != null) flujoArchivoContractError.Close();
                if (flujoArchivoLog != null) flujoArchivoLog.Close();
                if (sqlConnection != null) sqlConnection.Close();

                Console.WriteLine("Duración: {0} Horas, {1} Minutos, {2} Segundos.", duracion.Hours, duracion.Minutes, duracion.Seconds);
                Console.WriteLine("Finalizó");
                Console.Read();
            }
        }
    }
}
