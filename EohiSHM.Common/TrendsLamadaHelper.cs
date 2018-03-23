using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EohiSHM.Common
{
    /// <summary>
    /// linq多条件动态查询
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TrendsLamadaHelper<T> where T : class
    {
        public static Expression<Func<T, bool>> GetFilterExpression(List<FilterModel> filterConditionList)
        {
            Expression<Func<T, bool>> condition = null;
            try
            {
                if (filterConditionList != null && filterConditionList.Count > 0)
                {
                    foreach (FilterModel filterCondition in filterConditionList)
                    {
                        Expression<Func<T, bool>> tempCondition = CreateLambda<T>(filterCondition);
                        if (condition == null)
                        {
                            condition = tempCondition;
                        }
                        else
                        {
                            if ("AND".Equals(filterCondition.Logic))
                            {
                                condition = LinqBuilder.And(condition, tempCondition);
                            }
                            else
                            {
                                condition = LinqBuilder.Or(condition, tempCondition);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLogException("获取筛选条件异常:" + ex.Message);
            }
            return condition;
        }
        public static Expression<Func<T, bool>> CreateLambda<T>(FilterModel filterCondition)
        {
            var parameter = Expression.Parameter(typeof(T), "u");//创建参数i
            ConstantExpression constant = null;
            if (filterCondition.DataType == "int")
            {
                //int filevalue = 0;
                //int.TryParse(filterCondition.Value, out filevalue);
                //constant = Expression.Constant(filevalue);//创建常数
                constant = Expression.Constant(Convert.ToInt32(filterCondition.Value), typeof(int?));
            }
            else if (filterCondition.DataType == "DateTime")
            {
                constant = Expression.Constant(Convert.ToDateTime(filterCondition.Value), typeof(DateTime?));
            }
            else
            {
                constant = Expression.Constant(filterCondition.Value);//创建常数
            }


            MemberExpression member = Expression.PropertyOrField(parameter, filterCondition.Column);
            if ("=".Equals(filterCondition.Action) && constant != null)
            {
                return Expression.Lambda<Func<T, bool>>(Expression.Equal(member, constant), parameter);
            }
            else if ("!=".Equals(filterCondition.Action))
            {
                return Expression.Lambda<Func<T, bool>>(Expression.NotEqual(member, constant), parameter);
            }
            else if (">".Equals(filterCondition.Action))
            {
                return Expression.Lambda<Func<T, bool>>(Expression.GreaterThan(member, constant), parameter);
            }
            else if ("<".Equals(filterCondition.Action))
            {
                return Expression.Lambda<Func<T, bool>>(Expression.LessThan(member, constant), parameter);
            }
            else if (">=".Equals(filterCondition.Action))
            {
                return Expression.Lambda<Func<T, bool>>(Expression.GreaterThanOrEqual(member, constant), parameter);
            }
            else if ("<=".Equals(filterCondition.Action))
            {
                return Expression.Lambda<Func<T, bool>>(Expression.LessThanOrEqual(member, constant), parameter);
            }
            else if ("in".Equals(filterCondition.Action) && "1".Equals(filterCondition.DataType))
            {
                return GetExpressionWithMethod<T>("Contains", filterCondition);
            }
            else if ("out".Equals(filterCondition.Action) && "1".Equals(filterCondition.DataType))
            {
                return GetExpressionWithoutMethod<T>("Contains", filterCondition);
            }
            else
            {
                return null;
            }
        }
        public static Expression<Func<T, bool>> GetExpressionWithMethod<T>(string methodName, FilterModel filterCondition)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "u");
            MethodCallExpression methodExpression = GetMethodExpression(methodName, filterCondition.Column, filterCondition.Value, parameterExpression);
            return Expression.Lambda<Func<T, bool>>(methodExpression, parameterExpression);
        }

        public static Expression<Func<T, bool>> GetExpressionWithoutMethod<T>(string methodName, FilterModel filterCondition)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "u");
            MethodCallExpression methodExpression = GetMethodExpression(methodName, filterCondition.Column, filterCondition.Value, parameterExpression);
            var notMethodExpression = Expression.Not(methodExpression);
            return Expression.Lambda<Func<T, bool>>(notMethodExpression, parameterExpression);
        }

        /// <summary>
        /// 生成类似于p=>p.values.Contains("xxx");的lambda表达式
        /// parameterExpression标识p，propertyName表示values，propertyValue表示"xxx",methodName表示Contains
        /// 仅处理p的属性类型为string这种情况
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <param name="parameterExpression"></param>
        /// <returns></returns>
        private static MethodCallExpression GetMethodExpression(string methodName, string propertyName, string propertyValue, ParameterExpression parameterExpression)
        {
            var propertyExpression = Expression.Property(parameterExpression, propertyName);
            MethodInfo method = typeof(string).GetMethod(methodName, new[] { typeof(string) });
            var someValue = Expression.Constant(propertyValue, typeof(string));
            return Expression.Call(propertyExpression, method, someValue);
        }
    }
    /// <summary>
    ///             LinqBuilder类提供 Or()和And()来拼接关系是”且”和”或”的lambda表达式。
    /// </summary>
    public static class LinqBuilder
    {
        /// <summary>
        /// 默认True条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> True<T>() { return f => true; }

        /// <summary>
        /// 默认False条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        /// <summary>
        /// 拼接 OR 条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> exp, Expression<Func<T, bool>> condition)
        {
            var inv = Expression.Invoke(condition, exp.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.Or(exp.Body, inv), exp.Parameters);
        }

        /// <summary>
        /// 拼接And条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> exp, Expression<Func<T, bool>> condition)
        {
            var inv = Expression.Invoke(condition, exp.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.And(exp.Body, inv), exp.Parameters);
        }
    }
}


