using DALC;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class EmpresaLogic : LogicBase<Empresa, EmpresaDalc>
    {
        /// <summary>
        /// Agrega una empresa
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override long Add(Empresa entity)
        {
            return base.Add(entity);
        }

        /// <summary>
        /// Actualiza una empresa
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(Empresa entity)
        {
            // -- Recupero cursos actuales
            var empresaActual = Dalc.GetByID(entity.EntityID);
            // -- Asigno cursos
            entity.EmpresaCursos = empresaActual.EmpresaCursos;
            base.Update(entity);
        }

        /// <summary>
        /// Borra una empresa
        /// </summary>
        /// <param name="ID"></param>
        public override void Delete(long ID)
        {
            base.Delete(ID);
        }

        /// <summary>
        /// Borra logicamente una empresa
        /// </summary>
        /// <param name="ID"></param>
        public override void LogicDelete(long ID)
        {
            base.LogicDelete(ID);
        }

        /// <summary>
        /// Recupera empresas activas
        /// </summary>
        /// <returns></returns>
        public override List<Empresa> GetAllActivos()
        {
            return base.GetAllActivos();
        }

        /// <summary>
        /// Recupera empresa por id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public override Empresa GetByID(long ID)
        {
            return base.GetByID(ID);
        }

        /// <summary>
        /// Asigna cursos a empresa
        /// </summary>
        /// <param name="empresa"></param>
        public void AsignarCursos(Empresa empresa)
        {
            // -- Recupero empresa existente
            var empresaActual = Dalc.GetByID(empresa.EntityID);
            // -- Lista de ids de los cursos seleccionados para la empresa
            List<long> idsCursosEmpresa = empresa.EmpresaCursos.Select(x=>x.Curso.EntityID).ToList(); 
            // -- Lista de ids de cursos que tenia la empresa guardada
            List<long> idsCursosEmpresaEnActual = empresaActual.EmpresaCursos.Select(x => x.Curso.EntityID).ToList(); 
            // -- Borro cursos sacados
            for (int i = empresaActual.EmpresaCursos.Count - 1; i >= 0; i--)
            {
                // -- Si el curso no esta contenido
                if(!idsCursosEmpresa.Contains(empresaActual.EmpresaCursos[i].Curso.EntityID))
                {
                    // -- Quito el curso
                    empresaActual.EmpresaCursos.RemoveAt(i);
                }
            }
            // -- Agrego cursos nuevos
            foreach(EmpresaCurso empCur in empresa.EmpresaCursos)
            {
                // -- Si la empresa no tenia el curso 
                if(!idsCursosEmpresaEnActual.Contains(empCur.Curso.EntityID))
                {
                    // Lo agrego
                    empresaActual.EmpresaCursos.Add(empCur);
                }
            }            
            // -- Actualizo
            Dalc.Update(empresaActual);
        }

        public void CargarImagen(Empresa empresa, Stream fileStream, string path, string extension)
        {
            path += "logoEmpresa" + empresa.EntityID + extension;
            var length = Convert.ToInt32(fileStream.Length);

            byte[] data = null;

            using (var reader = new BinaryReader(fileStream))
            {
                data = reader.ReadBytes(length);
            }
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // -- Creo imagen
            var file = new FileStream(path, FileMode.Create, FileAccess.Write);

            file.Write(data, 0, length);

            file.Close();

            // -- Obtengo empresa
            var empresaActual = Dalc.GetByID(empresa.EntityID);
            // -- Actualizo imagen
            empresaActual.Imagen = "logoEmpresa" + empresa.EntityID + extension;
            // -- Actualizo
            Dalc.Update(empresaActual);
        }
    }
}
