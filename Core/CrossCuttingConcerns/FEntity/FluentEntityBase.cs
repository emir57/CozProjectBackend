using FluentEntity_ConsoleApp.FEntity.FluentExceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace FluentEntity_ConsoleApp.FEntity
{
    public abstract class FluentEntityBase<T>
        where T : class, new()
    {
        protected T _entity;
        public FluentEntityBase()
        {
            _entity = new T();
        }
        public FluentEntityBase(T entity)
        {
            _entity = entity;
        }

        /// <summary>
        /// assigns a value to the selected property
        /// </summary>
        /// <typeparam name="P">Property Type</typeparam>
        /// <param name="exp">Expression</param>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public virtual FluentEntityBase<T> AddParameter<P>(Expression<Func<T, P>> exp, object value)
        {
            string propertyName = (exp.Body as MemberExpression).Member.Name;
            SetProperty(propertyName, value);
            return this;
        }

        /// <summary>
        /// assigns value by property name
        /// </summary>
        /// <param name="propertyName">Property Name</param>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public virtual FluentEntityBase<T> AddParameter(string propertyName, object value)
        {
            SetProperty(propertyName, value);
            return this;
        }

        /// <summary>
        /// assigns values to all properties of the selected type
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual FluentEntityBase<T> AddParameters<P>(object value)
        {
            PropertyInfo[] propertyInfos = _entity.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
                if (propertyInfo.PropertyType == typeof(P))
                    propertyInfo.SetValue(_entity, value);
            return this;
        }

        /// <summary>
        /// returns the entity with values
        /// </summary>
        /// <returns></returns>
        public T Entity => _entity;

        /// <summary>
        /// assigns value to property
        /// </summary>
        /// <param name="propertyName">Property Name</param>
        /// <param name="value">Value</param>
        protected virtual void SetProperty(string propertyName, object value)
        {
            PropertyInfo propertyInfo = _entity.GetType().GetProperty(propertyName);
            CheckExceptions(propertyInfo);
            propertyInfo.SetValue(_entity, value);
        }
        /// <summary>
        /// checks for errors while assigning value to property
        /// </summary>
        /// <param name="propertyInfo">Property Info</param>
        /// <exception cref="PropertyNotFoundFluentEntityException"></exception>
        protected virtual void CheckExceptions(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null) throw new PropertyNotFoundFluentEntityException();
            //if (propertyInfo.PropertyType != value.GetType())
            //    throw new ArgumentFluentEntityException($"propertyType: {propertyInfo.PropertyType} valueType: {value.GetType()} cannot ne converted");
        }
    }
}
