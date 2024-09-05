﻿using Firebase.Database;
using Firebase.Database.Query;
using home_pisos_vinilicos.Data.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace home_pisos_vinilicos.Data.Repositories
{
    public class FirebaseRepository<T> : IRepository<T> where T : class
    {
        private readonly FirebaseClient _firebaseClient;

        public FirebaseRepository()
        {
            _firebaseClient = new FirebaseClient("https://home-pisos-vinilicos-default-rtdb.firebaseio.com/");
        }

        public virtual async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            var firebaseResult = await _firebaseClient
                .Child(typeof(T).Name)
                .OnceAsync<T>();

            var entities = firebaseResult.Select(x => x.Object).ToList();

            if (filter != null)
            {
                var filtered = entities.AsQueryable().Where(filter).ToList();
                return filtered;
            }

            return entities;
        }

        public async Task<T> GetById(string id, bool tracked = true)
        {
            try
            {
                var firebaseResult = await _firebaseClient
                    .Child(typeof(T).Name)
                    .Child(id)
                    .OnceSingleAsync<T>();

                return firebaseResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el registro en Firebase: {ex.Message}");
                return null;
            }
        }

        public virtual async Task<bool> Insert(T entity)
        {
            try
            {
                var firebaseResponse = await _firebaseClient
                    .Child(typeof(T).Name)
                    .PostAsync(entity);

                return firebaseResponse != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar en Firebase: {ex.Message}");
                return false;
            }
        }

        public virtual async Task<bool> Update(T entity)
        {
            try
            {
                var entityId = GetEntityId(entity);

                if (string.IsNullOrEmpty(entityId))
                {
                    throw new InvalidOperationException("El valor de la clave primaria no puede ser nulo o vacío.");
                }

                await _firebaseClient
                    .Child(typeof(T).Name)
                    .Child(entityId)
                    .PutAsync(entity);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar en Firebase: {ex.Message}");
                return false;
            }
        }

        public virtual async Task<bool> Delete(string id)
        {
            try
            {
                await _firebaseClient
                    .Child(typeof(T).Name)
                    .Child(id)
                    .DeleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar en Firebase: {ex.Message}");
                return false;
            }
        }

        private string GetEntityId(T entity)
        {
            var keyProperty = GetKeyProperty();
            var entityId = keyProperty.GetValue(entity)?.ToString();
            return entityId;
        }

        private PropertyInfo GetKeyProperty()
        {
            var keyProperty = typeof(T).GetProperties()
                .FirstOrDefault(prop => prop.IsDefined(typeof(KeyAttribute), false));

            if (keyProperty == null)
            {
                throw new InvalidOperationException($"La entidad {typeof(T).Name} no tiene una propiedad marcada con [Key].");
            }

            return keyProperty;
        }
    }
}
