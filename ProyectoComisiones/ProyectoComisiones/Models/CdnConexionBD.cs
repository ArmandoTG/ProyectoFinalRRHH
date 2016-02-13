using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace ProyectoComisiones.Models
{
    public class CdnConexionBD
    {
        //string strKey = "D40D15-66E40553-8C219F14-1AB2-B1C097";
        string strKey = "A12345-B12345T1-F12345D2-G1AT-G4C093";
        string vStrError = "";
        public CdnConexionBD()
        { }

        public string Retorna_Error()
        {
            return vStrError;
        }

        public SqlConnection IniCnx()
        {
            SqlConnection icnx = new SqlConnection();
            string dStr_Cadena = null;
            dStr_Cadena = cadena_cnx();
            icnx = new SqlConnection();
            icnx.ConnectionString = dStr_Cadena;
            icnx.Open();
            return icnx;
        }

        public SqlTransaction BeginTrans(SqlConnection pcnx)
        {
            SqlTransaction pObj_Tran = default(SqlTransaction);
            pObj_Tran = pcnx.BeginTransaction();
            return pObj_Tran;
        }

        public void CommitTrans(SqlTransaction pTran)
        {
            pTran.Commit();
        }

        public void RollBackTrans(SqlTransaction pTran)
        {
            pTran.Rollback();
        }

        public void FinCnx(SqlConnection pcnx)
        {
            pcnx.Close();
            pcnx.Dispose();
        }

        public DataTable Selecciona_Tabla(string pSP)
        {
            SqlConnection vCon = new SqlConnection();
            DataTable dt = new DataTable();
            string dStr_Cadena = "";
            dStr_Cadena = cadena_cnx();
            try
            {
                vCon.ConnectionString = dStr_Cadena;
                vCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(pSP, vCon);
                da.SelectCommand.CommandTimeout = 2000;
                da.Fill(dt);
            }
            catch (SqlException sqlex)
            {
                vStrError = sqlex.Message;
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
            }
            vCon.Close();
            vCon.Dispose();
            return (dt);
        }

        public DataTable Selecciona_Tabla(string pSP, DataTable pTblPar)
        {
            SqlConnection vCon = new SqlConnection();
            string dStr_Cadena = null;
            DataTable tbl = new DataTable();
            dStr_Cadena = cadena_cnx();
            SqlParameter Par = new SqlParameter();
            int regs;
            try
            {
                regs = pTblPar.Rows.Count;
                vCon.ConnectionString = dStr_Cadena;
                vCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(pSP, vCon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandTimeout = 2000;
                CrearParametros_da(ref da, pTblPar);
                da.Fill(tbl);
            }
            catch (SqlException Oex)
            {
                vStrError = Oex.Message;
                tbl = null;
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
                tbl = null;
            }
            vCon.Close();
            vCon.Dispose();
            return (tbl);
        }



        public DataSet Selecciona_Dataset(string pSP)
        {
            SqlConnection vCon = new SqlConnection();
            string dStr_Cadena = null;
            DataSet dst = new DataSet();
            dStr_Cadena = cadena_cnx();
            SqlParameter Par = new SqlParameter();
            try
            {
                vCon.ConnectionString = dStr_Cadena;
                vCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(pSP, vCon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandTimeout = 2000;
                da.Fill(dst);
            }
            catch (SqlException Oex)
            {
                vStrError = Oex.Message;
                dst = null;
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
                dst = null;
            }
            vCon.Close();
            vCon.Dispose();
            return (dst);
        }

        public DataSet Selecciona_Dataset(string pSP, DataTable pTblPar)
        {
            SqlConnection vCon = new SqlConnection();
            string dStr_Cadena = null;
            DataSet dst = new DataSet();
            dStr_Cadena = cadena_cnx();
            SqlParameter Par = new SqlParameter();
            int regs;
            try
            {
                regs = pTblPar.Rows.Count;
                vCon.ConnectionString = dStr_Cadena;
                vCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(pSP, vCon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandTimeout = 2000;
                CrearParametros_da(ref da, pTblPar);
                da.Fill(dst);
            }
            catch (SqlException Oex)
            {
                vStrError = Oex.Message;
                dst = null;
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
                dst = null;
            }
            vCon.Close();
            vCon.Dispose();
            return (dst);
        }

        public SqlDataReader Selecciona_Datareader(SqlConnection pCon, string pSP)
        {
            SqlCommand cmd = new SqlCommand(pSP, pCon);
            SqlDataReader drd = default(SqlDataReader);
            try
            {
                cmd.CommandTimeout = 2000;
                cmd.Prepare();
                cmd.CommandType = CommandType.StoredProcedure;
                drd = cmd.ExecuteReader();
            }
            catch (SqlException Sqlex)
            {
                vStrError = Sqlex.Message;
                drd = null;
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
                drd = null;
            }
            return (drd);
        }

        public SqlDataReader Selecciona_Datareader(SqlConnection pCon, string pSP, DataTable pTblPar)
        {
            SqlCommand cmd = new SqlCommand(pSP, pCon);
            SqlDataReader drd = default(SqlDataReader);
            int regs;
            try
            {
                regs = pTblPar.Rows.Count;
                cmd.CommandTimeout = 2000;
                cmd.Prepare();
                cmd.CommandType = CommandType.StoredProcedure;
                CrearParametros_cmd(ref cmd, pTblPar);
                drd = cmd.ExecuteReader();
            }
            catch (SqlException Sqlex)
            {
                vStrError = Sqlex.Message;
                drd = null;
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
                drd = null;
            }
            return (drd);
        }

        public int Actualiza_Data(string pSP)
        {
            SqlConnection dCon = new SqlConnection();
            string dStr_Cadena = null;
            int n;
            int intRet;
            DataTable pTblPar = new DataTable();
            try
            {
                dStr_Cadena = cadena_cnx();
                dCon.ConnectionString = dStr_Cadena;
                dCon.Open();
                SqlCommand cmd = new SqlCommand(pSP, dCon);
                pTblPar.Columns.Add("Dato");
                pTblPar.Rows.Add(0);
                cmd.CommandType = CommandType.StoredProcedure;
                CrearParametros_cmd(ref cmd, pTblPar);
                n = cmd.ExecuteNonQuery();
                intRet = int.Parse(cmd.Parameters["@ID_RETURN"].Value.ToString());
                if (intRet < 0)
                {
                    vStrError = "Error al ejecutar el procedimiento";
                }
                cmd.Dispose();
            }
            catch (SqlException Sqlex)
            {
                vStrError = Sqlex.Message;
                intRet = -1;
            }
            catch (Exception Ex)
            {
                vStrError = Ex.Message;
                intRet = -1;
            }
            finally
            {
                dCon.Close();
                dCon.Dispose();
            }
            return intRet;
        }

        public int Actualiza_Data(SqlConnection pCon, string pSP)
        {
            SqlCommand cmd = new SqlCommand(pSP, pCon);
            int n;
            int intRet;
            DataTable pTblPar = new DataTable();
            try
            {
                pTblPar.Columns.Add("Dato");
                pTblPar.Rows.Add(0);
                cmd.CommandType = CommandType.StoredProcedure;
                CrearParametros_cmd(ref cmd, pTblPar);
                n = cmd.ExecuteNonQuery();
                intRet = int.Parse(cmd.Parameters["@ID_RETURN"].Value.ToString());
                if (intRet < 0)
                {
                    vStrError = "Error al ejecutar el procedimiento";
                }
            }
            catch (SqlException Sqlex)
            {
                vStrError = Sqlex.Message;
                intRet = -1;
            }

            catch (Exception Ex)
            {
                vStrError = Ex.Message;
                intRet = -1;
            }
            finally
            {
                cmd.Dispose();
            }
            return intRet;
        }

        public int Actualiza_Data(string pSP, DataTable pTblPar)
        {
            SqlConnection dCon = new SqlConnection();
            string dStr_Cadena = "";

            int n;
            int intRet;
            try
            {
                dStr_Cadena = cadena_cnx();
                dCon.ConnectionString = dStr_Cadena;
                dCon.Open();

                SqlCommand cmd = new SqlCommand(pSP, dCon);
                cmd.CommandType = CommandType.StoredProcedure;
                CrearParametros_cmd(ref cmd, pTblPar);
                n = cmd.ExecuteNonQuery();
                intRet = int.Parse(cmd.Parameters["@ID_RETURN"].Value.ToString());
                if (intRet < 0)
                {
                    vStrError = "Error al ejecutar el procedimiento";
                }
                cmd.Dispose();
            }
            catch (SqlException Sqlex)
            {
                vStrError = Sqlex.Message;
                intRet = -1;
            }

            catch (Exception Ex)
            {
                vStrError = Ex.Message;
                intRet = -1;
            }
            finally
            {
                dCon.Close();
                dCon.Dispose();
            }
            return intRet;
        }

        public int Actualiza_Data(SqlConnection pCon, SqlTransaction pTrn, string pSP, DataTable pTblPar)
        {
            SqlCommand cmd = new SqlCommand(pSP, pCon, pTrn);
            int n;
            int intRet;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                CrearParametros_cmd(ref cmd, pTblPar);
                n = cmd.ExecuteNonQuery();
                intRet = int.Parse(cmd.Parameters["@ID_RETURN"].Value.ToString());
                if (intRet < 0)
                {
                    vStrError = "Error al ejecutar el procedimiento";
                }
            }
            catch (SqlException Sqlex)
            {
                vStrError = Sqlex.Message;
                intRet = -1;
            }

            catch (Exception Ex)
            {
                vStrError = Ex.Message;
                intRet = -1;
            }
            finally
            {
                cmd.Dispose();
            }
            return intRet;
        }


        //Public Function Actualiza_Data(ByVal vCon As OracleConnection, ByVal vSP As String, ByVal vTblPar As DataTable) As Integer
        //    Using cmd As New OracleCommand(vSP, vCon)
        //        Dim n As Integer = 0
        //        Try
        //            cmd.CommandType = CommandType.StoredProcedure
        //            CrearParametros(cmd, vTblPar)
        //            cmd.ExecuteNonQuery()
        //            Return (cmd.Parameters("ID_RETURN_").Value)
        //        Catch Oex As OracleException
        //            vStrError = Oex.Message
        //            Return (-1)
        //        Catch ex As Exception
        //            vStrError = ex.Message
        //            Return (-1)
        //        End Try
        //    End Using
        //End Function


        //Public Function Devuelve_Valor(ByVal vSP As String) As Object
        //    Dim vCon As New OracleConnection
        //    Dim dStr_Cadena As String
        //    Dim val As Object
        //    Try
        //        dStr_Cadena = MD5.Desencriptar_CN(vStrEsquema, KEY)
        //        vCon.ConnectionString = dStr_Cadena
        //        vCon.Open()
        //        Dim cmd As New OracleCommand(vSP, vCon)
        //        CrearParametros(cmd)
        //        val = cmd.ExecuteScalar
        //        vCon.Close()
        //        vCon = Nothing
        //        Return (val)
        //    Catch Oex As OracleException
        //        vStrError = Oex.Message
        //        Return (Nothing)
        //    Catch ex As Exception
        //        vStrError = ex.Message
        //        Return (Nothing)
        //    End Try
        //End Function

        //Public Function Devuelve_Valor(ByVal vSP As String, ByVal vTblPar As DataTable) As Object
        //    Dim vCon As New OracleConnection
        //    Dim dStr_Cadena As String
        //    Dim val As Object
        //    Try
        //        dStr_Cadena = MD5.Desencriptar_CN(vStrEsquema, KEY)
        //        vCon.ConnectionString = dStr_Cadena
        //        vCon.Open()
        //        Dim cmd As New OracleCommand(vSP, vCon)
        //        cmd.CommandType = CommandType.StoredProcedure
        //        CrearParametros(cmd, vTblPar)
        //        val = cmd.ExecuteScalar
        //        vCon.Close()
        //        vCon = Nothing
        //        Return (val)
        //    Catch Oex As OracleException
        //        vStrError = Oex.Message
        //        Return (Nothing)
        //    Catch ex As Exception
        //        vStrError = ex.Message
        //        Return (Nothing)
        //    End Try
        //End Function

        //Public Function Devuelve_Entero(ByVal vSP As String) As Integer
        //    Dim vCon As New OracleConnection
        //    Dim dStr_Cadena As String
        //    Dim val As Integer
        //    Try
        //        dStr_Cadena = MD5.Desencriptar_CN(vStrEsquema, KEY)
        //        vCon.ConnectionString = dStr_Cadena
        //        Dim cmd As New OracleCommand
        //        cmd.Connection = vCon
        //        cmd.CommandText = vSP
        //        cmd.CommandType = CommandType.StoredProcedure
        //        cmd.Parameters.Add("ID_RETURN_", OracleDbType.Int32, ParameterDirection.ReturnValue)
        //        vCon.Open()
        //        cmd.ExecuteNonQuery()
        //        val = CInt(cmd.Parameters("ID_RETURN_").Value.ToString)
        //        vCon.Close()
        //        vCon = Nothing
        //        Return (val)
        //    Catch Oex As OracleException
        //        vStrError = Oex.Message
        //        Return (-1)
        //    Catch ex As Exception
        //        vStrError = ex.Message
        //        Return (-1)
        //    End Try
        //End Function

        //Public Function Devuelve_Entero(ByVal vSP As String, ByVal vTblPar As DataTable) As Integer
        //    Dim vCon As New OracleConnection
        //    Dim dStr_Cadena As String
        //    Dim val As Integer
        //    Try
        //        dStr_Cadena = MD5.Desencriptar_CN(vStrEsquema, KEY)
        //        vCon.ConnectionString = dStr_Cadena
        //        Dim cmd As New OracleCommand
        //        cmd.Connection = vCon
        //        cmd.CommandText = vSP
        //        cmd.CommandType = CommandType.StoredProcedure
        //        vCon.Open()
        //        CrearParametros(cmd, vTblPar, True)
        //        cmd.ExecuteNonQuery()
        //        val = CInt(cmd.Parameters("ID_RETURN_").Value.ToString)
        //        vCon.Close()
        //        vCon = Nothing
        //        Return (val)
        //    Catch Oex As OracleException
        //        vStrError = Oex.Message
        //        Return (-1)
        //    Catch ex As Exception
        //        vStrError = ex.Message
        //        Return (-1)
        //    End Try
        //End Function


        private void CrearParametros_da(ref SqlDataAdapter vDa, DataTable vTblPar)
        {
            object dObj_Tmp = null;

            try
            {
                SqlCommandBuilder.DeriveParameters(vDa.SelectCommand);
                int I = 0;
                int C = 0;
                int J = 1;
                C = vDa.SelectCommand.Parameters.Count - 1;
                for (I = 0; I < C; I++)
                {
                    if (vDa.SelectCommand.Parameters[J].Direction == ParameterDirection.Output)
                    {
                        vDa.SelectCommand.Parameters[J].Value = DBNull.Value;
                    }
                    else
                    {
                        if (vTblPar.Rows[I][0].ToString().ToUpper() == "NULL")
                        {
                            vDa.SelectCommand.Parameters[J].Value = DBNull.Value;
                        }
                        else
                        {
                            if (vDa.SelectCommand.Parameters[J].SqlDbType == SqlDbType.Date)
                            {
                                dObj_Tmp = Convert.ToDateTime(vTblPar.Rows[I][0]);
                                vDa.SelectCommand.Parameters[J].Value = dObj_Tmp;
                            }
                            else if (vDa.SelectCommand.Parameters[J].SqlDbType == SqlDbType.DateTime)
                            {
                                dObj_Tmp = Convert.ToDateTime(vTblPar.Rows[I][0]);
                                vDa.SelectCommand.Parameters[J].Value = dObj_Tmp;
                            }
                            else if (vDa.SelectCommand.Parameters[J].SqlDbType == SqlDbType.Decimal)
                            {
                                dObj_Tmp = Convert.ToDecimal(vTblPar.Rows[I][0]);
                                vDa.SelectCommand.Parameters[J].Value = dObj_Tmp;
                            }
                            else if (vDa.SelectCommand.Parameters[J].SqlDbType == SqlDbType.Image)
                            {
                                dObj_Tmp = vTblPar.Rows[I][0];
                                vDa.SelectCommand.Parameters[J].Value = dObj_Tmp;
                            }
                            else
                            {
                                vDa.SelectCommand.Parameters[J].Value = vTblPar.Rows[I][0];
                            }
                        }

                    }

                    J = J + 1;
                }
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
            }
        }

        private void CrearParametros_cmd(ref SqlCommand vCmd, DataTable vTblPar)
        {
            object dObj_Tmp = null;
            try
            {
                SqlCommandBuilder.DeriveParameters(vCmd);
                int I = 0;
                int C = 0;
                int J = 1;
                C = vCmd.Parameters.Count - 1;
                for (I = 0; I < C; I++)
                {

                    dObj_Tmp = vTblPar.Rows[I][0];
                    if (vCmd.Parameters[J].Direction == ParameterDirection.Output)
                    {
                        vCmd.Parameters[J].Value = DBNull.Value;
                    }
                    else
                    {
                        if (vTblPar.Rows[I][0].ToString().ToUpper() == "NULL")
                        {
                            vCmd.Parameters[J].Value = DBNull.Value;
                        }
                        else
                        {
                            if (vCmd.Parameters[J].SqlDbType == SqlDbType.Date)
                            {
                                dObj_Tmp = Convert.ToDateTime(vTblPar.Rows[I][0]);
                                vCmd.Parameters[J].Value = dObj_Tmp;
                            }
                            else if (vCmd.Parameters[J].SqlDbType == SqlDbType.DateTime)
                            {
                                dObj_Tmp = Convert.ToDateTime(vTblPar.Rows[I][0]);
                                vCmd.Parameters[J].Value = dObj_Tmp;
                            }
                            else if (vCmd.Parameters[J].SqlDbType == SqlDbType.Decimal)
                            {
                                dObj_Tmp = Convert.ToDecimal(vTblPar.Rows[I][0]);
                                vCmd.Parameters[J].Value = dObj_Tmp;
                            }
                            else if (vCmd.Parameters[J].SqlDbType == SqlDbType.Image)
                            {
                                dObj_Tmp = vTblPar.Rows[I][0];
                                vCmd.Parameters[J].Value = dObj_Tmp;
                            }
                            else
                            {
                                vCmd.Parameters[J].Value = vTblPar.Rows[I][0];
                            }
                        }

                    }
                    J = J + 1;
                }
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
            }
        }


        private string cadena_cnx()
        {
            string dCadena;
            //Prueba
            dCadena = "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=RRHHWEB1";
            //dCadena = "database=SIGOP;server=192.168.1.5;user id=sa;password=Cangrej0";
            //Produccion
            //dCadena = "database=RHAsistencia;server=128.1.4.68;user id=sa;password=$cdata123";
            return dCadena;
        }


        private string Desencriptar_CN(string strCadena)
        {
            string tx_conexion = "";
            try
            {
                if (strCadena != "")
                {
                    tx_conexion = Desencriptar(strCadena);
                }
                else
                {
                    tx_conexion = "";
                }
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
            }
            return tx_conexion;
        }

        public string Desencriptar(string sDato)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(strKey));
            DES.Mode = CipherMode.ECB;
            ICryptoTransform DESDecrypt = DES.CreateDecryptor();
            byte[] Buffer = Convert.FromBase64String(sDato);
            string dStr;
            dStr = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            return dStr;
        }

        public string Encriptar(string sDato)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(strKey));
            DES.Mode = CipherMode.ECB;
            ICryptoTransform DESEncrypt = DES.CreateEncryptor();
            byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(sDato);
            string dStr;
            dStr = Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            return dStr;
        }



    }
}