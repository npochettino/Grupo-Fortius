using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DALC.NHibernate
{
    /// <summary>
    /// Accesor a metodos NHibernate.
    /// </summary>
    public static class NHibernateAccesor
    {

        #region Constantes

        private const string ACTIVO = "ACTIVO";
        private const string ACTIVA = "ACTIVA";
        private const string ACTIVE = "ACTIVE";

        #endregion

        /// <summary>
        /// Obtiene una entidad por ID.
        /// </summary>
        /// <typeparam name="T">Entidad</typeparam>
        /// <param name="ID">ID</param>
        /// <returns>T</returns>
        public static T GetById<T>(long ID)
        where T : class
        {
            try
            {
                NHibernateManager.GetInstance().Session.Clear();
                return NHibernateManager.GetInstance().Session.Get<T>(ID);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Obtiene una lista de una entidad con todos sus registros.
        /// </summary>
        /// <typeparam name="T">Entidad</typeparam>
        /// <returns>Lista</returns>
        public static List<T> GetAll<T>()
        where T : class
        {
            try
            {
                NHibernateManager.GetInstance().Session.Clear();
                return NHibernateManager.GetInstance().Session.QueryOver<T>().List<T>().ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        /// <summary>
        /// Obtiene una cantidad de lista en base a un filtro
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public static List<T> GetByText<T>(List<Expression<Func<T, object>>> criterias, string text, int count)
        where T : class
        {
            try
            {
                NHibernateManager.GetInstance().Session.Clear();
                var disjunction = new Disjunction();
                foreach (var criteria in criterias)
                {
                    disjunction.Add(Restrictions.On(criteria).IsInsensitiveLike("%" + text + "%"));
                }
                return NHibernateManager.GetInstance().Session.QueryOver<T>().Where(disjunction).Take(count).List<T>().ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Filtra por like con text y por condiciones booleanas
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="likeCriterias">criterias a los que aplicar el like</param>
        /// <param name="criteriaConditions">condicion booleana</param>
        /// <param name="text">texto para aplicar el like</param>
        /// <param name="count">cantidad de objetos a devolver</param>
        /// <returns></returns>
        public static List<T> GetByLikeAndConjunction<T>(List<Expression<Func<T, object>>> likeCriterias, Expression<Func<T, bool>> criteriaConditions, string text, int count)
        where T : class
        {
            try
            {
                NHibernateManager.GetInstance().Session.Clear();
                var disjunction = new Disjunction();
                var conjunction = new Conjunction();
                //Filtros para Likes
                foreach (var criteria in likeCriterias)
                {
                    disjunction.Add(Restrictions.On(criteria).IsInsensitiveLike("%" + text + "%"));
                }
                //Se agrega otro criterio a la conjuncion
                conjunction.Add(criteriaConditions);
                conjunction.Add(disjunction);
                return NHibernateManager.GetInstance().Session.QueryOver<T>().Where(conjunction).Take(count).List<T>().ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Recupera entidades por like(varios campos), id y otros criterios
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="likeCriterias">campos para aplicar el like</param>
        /// <param name="idCondition">condicion de comparacion del id que se agrega a la disjuncion</param>
        /// <param name="criteriaConditions">otros filtros para el AND</param>
        /// <param name="text">texto para el like</param>
        /// <param name="count">cantidad de registros a devolver</param>
        /// <returns></returns>
        public static List<T> GetByLikeConjunctionAndID<T>(List<Expression<Func<T, object>>> likeCriterias, Expression<Func<T, bool>> idCondition, Expression<Func<T, bool>> criteriaConditions, string text, int count)
        where T : class
        {
            try
            {
                NHibernateManager.GetInstance().Session.Clear();
                var disjunction = new Disjunction();
                var conjunction = new Conjunction();
                //Filtros para Likes
                foreach (var criteria in likeCriterias)
                {
                    disjunction.Add(Restrictions.On(criteria).IsInsensitiveLike("%" + text + "%"));
                }
                //Filtros para Likes
                disjunction.Add(idCondition);
                conjunction.Add(criteriaConditions);
                conjunction.Add(disjunction);
                return NHibernateManager.GetInstance().Session.QueryOver<T>().Where(conjunction).Take(count).List<T>().ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Obtiene una lista de una entidad en base a un filtro.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Lista</returns>
        public static List<T> GetByCriteria<T>(Expression<Func<T, bool>> criteria)
        where T : class
        {
            try
            {
                NHibernateManager.GetInstance().Session.Clear();
                return NHibernateManager.GetInstance().Session.QueryOver<T>().Where(criteria).List<T>().ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Obtiene un objeto de entidad en base a un filtro.
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="criteria">criteria</param>
        /// <returns>T</returns>
        public static T GetOneByCriteria<T>(Expression<Func<T, bool>> criteria)
        where T : class
        {
            try
            {
                NHibernateManager.GetInstance().Session.Clear();
                return NHibernateManager.GetInstance().Session.QueryOver<T>().Where(criteria).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Inserta una entidad.
        /// </summary>
        /// <typeparam name="T">Entidad</typeparam>
        /// <param name="entity">Instancia</param>
        public static void PerformInsertOrUpdate<T>(T entity)
        {
            using (ITransaction transaction = NHibernateManager.GetInstance().Session.BeginTransaction())
            {
                try
                {
                    NHibernateManager.GetInstance().Session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // -- Log Here.
                    transaction.Rollback();
                    throw (ex);
                }
            }
        }

        /// <summary>
        /// Para agregar masivamente una lista de entidades, retorna los ids insertados en base de datos
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <param name="entites">lista de entidades</param>
        /// <returns></returns>
        public static List<long> BatchInsert<T>(List<T> entites)
        {
            var ids = new List<long>();
            var session = NHibernateManager.GetInstance().Session;

            using (IStatelessSession stateLess = session.SessionFactory.OpenStatelessSession())
            using (ITransaction transaction = stateLess.BeginTransaction())
            {
                foreach (var entity in entites)
                {
                    session.Clear();
                    var field = stateLess.Insert(entity);
                    ids.Add((long)field);
                }
                transaction.Commit();
            }
            return ids;
        }

        /// <summary>
        /// Actualiza una entidad.
        /// </summary>
        /// <typeparam name="T">Entidad</typeparam>
        /// <param name="entity">Instancia</param>
        public static void PerformUpdate<T>(T entity) where T : class
        {
            using (ITransaction transaction = NHibernateManager.GetInstance().Session.BeginTransaction())
            {
                try
                {
                    NHibernateManager.GetInstance().Session.Merge(entity);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // -- Log Here.
                    transaction.Rollback();
                    throw (ex);
                }
            }
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <typeparam name="T">Entidad</typeparam>
        /// <param name="ID">ID de la Entidad a eliminar</param>
        public static void Delete<T>(long ID)
        {
            try
            {
                NHibernateManager.GetInstance().Session.Delete(ID);
                NHibernateManager.GetInstance().Session.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Delete logico: pone el campo active en false.
        /// </summary>
        /// <typeparam name="T">Entidad</typeparam>
        /// <param name="ID">ID de la Entidad</param>
        public static void LogicDelete<T>(long ID)
        {
            try
            {
                var entity = NHibernateManager.GetInstance().Session.Load<T>(ID);

                foreach (PropertyInfo p in entity.GetType().GetProperties())
                {
                    if (p.Name.ToUpper() == ACTIVO || p.Name.ToUpper() == ACTIVA || p.Name.ToUpper() == ACTIVE)
                    {
                        p.SetValue(entity, false);
                    }
                }

                NHibernateManager.GetInstance().Session.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Ejecuta una query y retorna un unico resultado (T = decimal, int, etc).
        /// </summary>
        /// <typeparam name="T">Tipo de dato que retorna, ejemplo Decimal, Int, Etc.</typeparam>
        /// <param name="Query">Query a ejecutar</param>
        /// <returns>T</returns>
        public static T ExecuteQueryWithReturnOneValue<T>(string Query)
        where T : struct
        {
            IQuery query = NHibernateManager.GetInstance().Session.CreateSQLQuery(Query);
            var result = query.UniqueResult();
            return (T)result;
        }

    }
}
