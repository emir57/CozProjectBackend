using FluentEntity_ConsoleApp.FEntity.FluentExceptions;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Core.CrossCuttingConcerns.FEntity;

public abstract class FluentEntityBase<T>
    where T : class, new()
{
    protected T TEntity { get; set; }

    protected FluentEntityBase()
    {
        TEntity = new T();
    }

    protected FluentEntityBase(T entity)
    {
        TEntity = entity;
    }

    /// <summary>
    /// assigns a value to the selected property
    /// </summary>
    /// <typeparam name="P">Property Type</typeparam>
    /// <param name="exp">Expression</param>
    /// <param name="value">Value</param>
    /// <returns></returns>
    public virtual FluentEntityBase<T> AddParameter<TProperty>(Expression<Func<T, TProperty>> exp, object value)
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
    public virtual FluentEntityBase<T> AddParameters<TProperty>(object value)
    {
        PropertyInfo[] propertyInfos = TEntity.GetType().GetProperties();
        foreach (PropertyInfo propertyInfo in propertyInfos)
            if (propertyInfo.PropertyType == typeof(TProperty))
                propertyInfo.SetValue(TEntity, value);
        return this;
    }

    /// <summary>
    /// returns the entity with values
    /// </summary>
    /// <returns></returns>
    public T Entity => TEntity;

    /// <summary>
    /// assigns value to property
    /// </summary>
    /// <param name="propertyName">Property Name</param>
    /// <param name="value">Value</param>
    protected virtual void SetProperty(string propertyName, object value)
    {
        PropertyInfo propertyInfo = TEntity.GetType().GetProperty(propertyName);
        CheckExceptions(propertyInfo);
        propertyInfo.SetValue(TEntity, value);
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
