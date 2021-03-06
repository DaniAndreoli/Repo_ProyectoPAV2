﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using ProyectoPAV2.Entidades;

namespace ProyectoPAV2.DAL
{
    class MedidaDAL : BaseDAL 
    {

        /// <summary>
        /// Permite obtener una coleccion con todos los objetos de la clase Medida
        /// </summary>
        /// <returns></returns>
        public MedidasCollection getMedidas()
        {
            SqlCommand cmd = new SqlCommand("PACK_MEDIDAS.PR_MEDIDAS_C", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                MedidasCollection lsMedidas = new MedidasCollection();
                Medida objMedida = null;

                while (dr.Read())
                {
                    objMedida = new Medida(
                        dr.GetInt16(0),
                        dr.GetString(1));

                    lsMedidas.Add(objMedida);
                }

                cmd.Connection.Close();

                return lsMedidas;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
        }

        /// <summary>
        /// Metodo que permite obtener el objeto Medida especificado en el parametro de Entrada
        /// </summary>
        /// <param name="idMedida"></param>
        /// <returns></returns>
        public Medida getMedidaPorID(int idMedida)
        {
            SqlCommand cmd = new SqlCommand("PACK_MEDIDAS.PR_MEDIDAS_POR_ID", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@p_id_medida", idMedida);

            SqlDataReader dr = cmd.ExecuteReader();

            Medida objMedida = null;

            if(dr.Read())
            {
                objMedida = new Medida(
                    dr.GetInt16(0),
                    dr.GetString(1));
            }

            cmd.Connection.Close();

            return objMedida;
        }

    }
}
