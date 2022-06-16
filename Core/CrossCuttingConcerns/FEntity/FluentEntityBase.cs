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
        protected T entity;
        public FluentEntityBase()
        {
            entity = new T();
        }
        public virtual FluentEntityBase<T> AddParameter<P>(Expression<Func<T, P>> exp, object value)
        {
            string propertyName = (exp.Body as MemberExpression).Member.Name;
            SetProperty(propertyName, value);
            return this;
        }
        public virtual FluentEntityBase<T> AddParameter(string propertyName, object value)
        {
            SetProperty(propertyName, value);
            return this;
        }
        public virtual FluentEntityBase<T> AddParameters<P>(object value)
        {
            PropertyInfo[] propertyInfos = entity.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
                if (propertyInfo.PropertyType == typeof(P))
                    propertyInfo.SetValue(entity, value);
            return this;
        }

        public T GetEntity() => entity;

        protected virtual void SetProperty(string propertyName, object value)
        {
            PropertyInfo propertyInfo = entity.GetType().GetProperty(propertyName);
            CheckExceptions(propertyInfo);
            propertyInfo.SetValue(entity, value);
        }
        protected virtual void CheckExceptions(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null) throw new PropertyNotFoundFluentEntityException();
            //if (propertyInfo.PropertyType != value.GetType())
            //    throw new ArgumentFluentEntityException($"propertyType: {propertyInfo.PropertyType} valueType: {value.GetType()} cannot ne converted");
        }
    }
}
