using System;
using API.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class DBService<T> : IDBService<T> where T : class
    {
        private readonly IDbContextFactory<APIContext> _factory;

        public DBService(IDbContextFactory<APIContext> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Obtener cualquier entidad (Todos los registros)
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> Get()
        {
            using (var _context = await _factory.CreateDbContextAsync())
            {
                return await _context.Set<T>().ToListAsync();
            }
        }

        /// <summary>
        /// Insertar un registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Post(T entity)
        {
            using (var _context = await _factory.CreateDbContextAsync())
            {
                await _context.Set<T>().AddAsync(entity);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<int> Patch(T entity)
        {
            using (var _context = await _factory.CreateDbContextAsync())
            {
                //obtener el tipo de entidad
                var entityType = _context.Model.FindEntityType(typeof(T));

                //obtener las llaves primarias
                var keyProperties = entityType?.FindPrimaryKey()?.Properties;

                //obtener el conteo de llaves
                var primaryKeyValues = new object[keyProperties.Count];

                for (int i = 0; i < keyProperties.Count; i++)
                {
                    primaryKeyValues[i] = keyProperties[i].PropertyInfo.GetValue(entity);
                }

                //no tiene llaves primarias la entidad
                if (primaryKeyValues.Length < 1)
                {
                    return -99;
                }

                //buscar por medio de las llaves la entidad
                var existingEntity = await _context.Set<T>().FindAsync(primaryKeyValues);

                if (existingEntity == null)
                {
                    return -1;
                }

                //asignar los valores a las propiedades
                foreach (var prop in entityType.GetProperties())
                {
                    if (!keyProperties.Contains(prop))
                    {
                        prop.PropertyInfo.SetValue(existingEntity, prop.PropertyInfo.GetValue(entity));
                    }
                }

                return await _context.SaveChangesAsync();
            }
        }

    }
}

