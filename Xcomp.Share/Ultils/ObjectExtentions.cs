﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Xcomp.Share.Ultils
{
    public static class ObjectExtentions
    {
        private static Random random = new Random();

        public static T As<T>(this object source)
        {
            if (source == null)
            {
                return default;
            }
            var result = Activator.CreateInstance<T>();
            foreach (var item in typeof(T).GetProperties())
            {
                if (source.GetType().GetProperty(item.Name) != null)
                    item.SetValue(result, source.GetType().GetProperty(item.Name).GetValue(source) ?? null);
            }
            return result;
        }

        public static void Update(this object targetObject, object sourceObject, Dictionary<string, string> propertyFields = null)
        {
            if (propertyFields == null)
            {
                foreach (var item in targetObject.GetType().GetProperties())
                {
                    var info2 = sourceObject.GetType().GetProperty(item.Name);
                    if (info2 != null && item.PropertyType == info2.PropertyType)
                    {
                        item.SetValue(targetObject, info2.GetValue(sourceObject) ?? null);
                    }
                }
            }
            else
            {
                Type targetType = targetObject.GetType();
                Type sourceType = sourceObject.GetType();
                foreach (var item in propertyFields)
                {
                    var targetProperty = targetType.GetProperty(item.Key);
                    if (targetProperty != null)
                    {
                        var sourceProperty = sourceType.GetProperty(item.Value);
                        if (sourceProperty != null && targetProperty.PropertyType == sourceProperty.PropertyType)
                        {
                            try
                            {
                                var value = sourceProperty.GetValue(sourceObject);
                                targetProperty.SetValue(targetObject, value);
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }
                    }
                }
            }
        }

        public static void Trim(this object targetObject)
        {
            try
            {
                foreach (var item in targetObject.GetType().GetProperties().Where(c => c.PropertyType == typeof(string)))
                {
                    var currentValue = item.GetValue(targetObject) as string;
                    if (currentValue.IsNotNullOrEmpty() && (currentValue[0] == ' ' || currentValue[currentValue.Length - 1] == ' '))
                    {
                        item.SetValue(targetObject, currentValue.Trim());
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// EncodeHtml object cho object
        /// </summary>
        /// <param name="targetObject"></param>
        public static T EncodeHtml<T>(T targetObject)
        {
            try
            {
                T tempObject = (T)Activator.CreateInstance(targetObject.GetType());
                tempObject.Update(targetObject);
                foreach (var item in tempObject.GetType().GetProperties().Where(c => c.PropertyType == typeof(string)))
                {
                    var currentValue = item.GetValue(tempObject) as string;
                    if (currentValue.IsNotNullOrEmpty())
                    {
                        item.SetValue(tempObject, HttpUtility.HtmlEncode(currentValue));
                    }
                }
                return tempObject;
            }
            catch (Exception)
            {
                return targetObject;
            }
        }

        /// <summary>
        /// EncodeHtml object cho List va object
        /// </summary>
        /// <param name="targetObject"></param>
        public static List<T> EncodeHtml<T>(List<T> targetObject)
        {
            try
            {
                List<T> tempObject = new List<T>();
                foreach (var item in targetObject as System.Collections.IList)
                {
                    tempObject.Add(EncodeHtml(item).As<T>());
                }
                return tempObject;
            }
            catch (Exception)
            {
                return targetObject;
            }
        }

        public static void SetValue<T>(this T obj, string nameProperty, object value)
        {
            try
            {
                var info = obj.GetType().GetProperty(nameProperty);
                CultureInfo culture1 = CultureInfo.CreateSpecificCulture("vi-VN");
                DateTime dateTime;
                if (value is DBNull)
                {
                    return;
                }
                if (info != null)
                {
                    if (info.PropertyType == typeof(int))
                    {
                        value = new Regex(@"[^\d]+").Replace(value.ToString(), "");
                        info.SetValue(obj, Convert.ToInt32(value));
                    }
                    else if (info.PropertyType == typeof(int?))
                    {
                        if (value == null || value?.ToString() == "null" || value?.ToString() == "")
                        {
                            info.SetValue(obj, null);
                        }
                        else
                        {
                            value = new Regex(@"[^\d]+").Replace(value.ToString(), "");
                            info.SetValue(obj, Convert.ToInt32(value));
                        }
                    }
                    else if (info.PropertyType == typeof(decimal))
                    {
                        info.SetValue(obj, Convert.ToDecimal(value));
                    }
                    else if (info.PropertyType == typeof(decimal?))
                    {
                        if (value.IsNullOrEmpty() || value?.ToString() == "null")
                        {
                            info.SetValue(obj, null);
                        }
                        else
                        {
                            info.SetValue(obj, Convert.ToDecimal(value));
                        }
                    }
                    //else if (info.PropertyType == typeof(DateTime))
                    //{
                    //    DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy", culture1, DateTimeStyles.None, out dateTime);
                    //    info.SetValue(obj, dateTime);
                    //}
                    else if (info.PropertyType == typeof(DateTime?))
                    {
                        if (value.IsNullOrEmpty() || value?.ToString() == "null")
                        {
                            info.SetValue(obj, null);
                        }
                        else
                        {
                            DateTime.TryParse(value.ToString(), culture1, DateTimeStyles.None, out dateTime);
                            info.SetValue(obj, dateTime);
                        }
                    }
                    else if (info.PropertyType == typeof(bool))
                    {
                        info.SetValue(obj, Convert.ToBoolean(value));
                    }
                    else
                    {
                        info.SetValue(obj, value);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static object GetValue<T>(this T obj, string nameProperty)
        {
            var info = obj.GetType().GetProperty(nameProperty);
            if (info == null)
            {
                return null;
            }
            return info.GetValue(obj);
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static void Add<T>(this IList<PropertyInfo> propertyInfos, Expression<Func<T, bool>> property)
        {
            propertyInfos.Add<T, bool>(property);
        }
        public static void Add<T>(this IList<PropertyInfo> propertyInfos, Expression<Func<T, string>> property)
        {
            propertyInfos.Add<T, string>(property);
        }
        public static void Add<T>(this IList<PropertyInfo> propertyInfos, Expression<Func<T, int>> property)
        {
            propertyInfos.Add<T, int>(property);
        }
        public static void Add<T>(this IList<PropertyInfo> propertyInfos, Expression<Func<T, decimal>> property)
        {
            propertyInfos.Add<T, decimal>(property);
        }
        public static void Add<T>(this IList<PropertyInfo> propertyInfos, Expression<Func<T, decimal?>> property)
        {
            propertyInfos.Add<T, decimal?>(property);
        }
        public static void Add<T>(this IList<PropertyInfo> propertyInfos, Expression<Func<T, DateTime?>> property)
        {
            propertyInfos.Add<T, DateTime?>(property);
        }
        public static void Add<T>(this IList<PropertyInfo> propertyInfos, Expression<Func<T, int?>> property)
        {
            propertyInfos.Add<T, int?>(property);
        }

        public static void Add<T, TR>(this IList<PropertyInfo> propertyInfos, Expression<Func<T, TR>> property)
        {
            MemberExpression memberExpression = property.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("'property' không có body");
            PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null || propertyInfo.ReflectedType == null)
                throw new ArgumentException(string.Format("Expression '{0}' can't be cast to an Operand.", property));
            propertyInfos.Add(propertyInfo);
        }

        public static bool Contains<T, TR>(this IList<PropertyInfo> propertyInfos, Expression<Func<T, TR>> property)
        {
            MemberExpression memberExpression = property.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("'property' không có body");
            PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null || propertyInfo.ReflectedType == null)
                return false;
            if (propertyInfos.Contains(propertyInfo))
            {
                return true;
            }
            return false;
        }

        public static string GenerateGuid() => Guid.NewGuid().ToString("N");

        public static void AddRangeWithCheckExist(this HashSet<string> source, IEnumerable<string> addItems)
        {
            foreach (var item in addItems)
            {
                if (!source.Contains(item))
                {
                    source.Add(item);
                }
            }
        }

        public static bool IsNullOrEmpty(this object input)
        {
            if (input == null || input.ToString().Length == 0 || input.ToString().Trim().Length == 0)
            {
                return true;
            }
            return false;
        }
        public static bool IsNotNullOrEmpty(this object input)
        {
            if (input == null || input.ToString().Length == 0 || input.ToString().Trim().Length == 0)
            {
                return false;
            }
            return true;
        }
        public static bool IsNotNullOrEmptyOrNotDBNull(this object input)
        {
            if (input == null || input == DBNull.Value || input.ToString().Length == 0 || input.ToString().Trim().Length == 0)
            {
                return false;
            }
            return true;
        }
        public static DateTime? ConvertCultureVN(this string input)
        {
            CultureInfo culture1 = CultureInfo.CreateSpecificCulture("vi-VN");
            DateTime dateTime;
            string[] font = { "dd/MM/yyyy", "dd-MM-yyyy", "d/M/yyyy", "d-M-yyyy" };
            if (string.IsNullOrEmpty(input))
                return null;
            DateTime.TryParseExact(input.Trim(), font, culture1, DateTimeStyles.None, out dateTime);
            if (dateTime == new DateTime())
                dateTime = DateTime.Now;
            return dateTime;
        }
        public static void Add(this List<KeyValuePair<int, int>> list, int i, int j)
        {
            list.Add(new KeyValuePair<int, int>(i, j));
        }

        /// <summary>
        /// Chuyển object về số nguyên. Nếu obj null hoặc empty hoặc không chuyển được trả về 0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt(this object obj)
        {
            if (obj == null || obj.IsNullOrEmpty())
            {
                return 0;
            }
            try
            {
                int value;
                int.TryParse(obj.ToString(), out value);
                return value;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Kiểm tra chuối ký tự có thể chuyển thành số hay không kiểu 0.000,0
        /// </summary>
        /// <param name="pText">Chuỗi ký tự</param>
        /// <returns>True nếu chuối ký tự là số. False nếu ngược lại</returns>
        public static bool IsNumberFormatVN(this string pText)
        {
            if (pText.IsNullOrEmpty())
            {
                return false;
            }
            Regex regex = new Regex(@"^[-+]?[0-9.]*\,?[0-9]+$");
            return regex.IsMatch(pText);
        }

        public static void SetValue<T>(this DataRow row, string key, List<T> list, T item, List<KeyValuePair<int, int>> errors, int i, int j)
        {
            if (list.Contains(item))
            {
                row[key] = item;
            }
            else
            {
                errors.Add(i, j);
            }
        }

        public static void SetRowValue<T>(this DataRow row, string key, ICollection<T> list, T item, List<KeyValuePair<int, int>> errors, int i, int j)
        {
            if (list.Contains(item))
            {
                row[key] = item;
            }
            else
            {
                errors.Add(i, j);
            }
        }

        public static bool EqualValues<T>(T a1, T a2)
        {
            return EqualityComparer<T>.Default.Equals(a1, a2);
        }


        public static Decimal ToDecimal(this object obj)
        {
            CultureInfo culture1 = CultureInfo.CreateSpecificCulture("vi-VN");
            if (obj == null || obj.IsNullOrEmpty())
            {
                return 0;
            }
            decimal value;
            Decimal.TryParse(obj.ToString(), NumberStyles.Number, culture1, out value);
            return value;
        }

        /// <summary>
        /// Hàm chuyển số x dạng decimal về chuỗi theo format 
        /// Ví dụ:
        ///     x >= 100: 1000 => 1.000
        ///     x < 100: 50 => 50,00
        ///              3,5 => 3,5
        ///              3,55 => 3,55
        /// </summary>
        /// <param name="d_value"></param>
        /// <returns></returns>
        public static string ToDecimalFormated(this decimal? d_value, int numberAfterComma = 2)
        {
            if (d_value.IsNullOrEmpty())
            {
                return string.Empty;
            }
            var valueAfterComma = Math.Pow(10, numberAfterComma).ToInt();
            if (d_value > 0m && d_value < 100m && ((int)d_value * valueAfterComma) % valueAfterComma == 0)
            {
                // Yêu cầu chỉ có 2 số 0 sau dấu phẩy
                return d_value?.ToString("N2");
            }
            else
            {
                var strValue = d_value?.ToString("N" + numberAfterComma);
                if (strValue != null && strValue.Contains(','))
                {
                    return strValue.TrimEnd('0').TrimEnd(',');
                }
                else
                {
                    return strValue;
                }
            }
        }
        public static string ToDecimalFormated(this decimal d_value, int numberAfterComma = 2)
        {
            if (d_value.IsNullOrEmpty())
            {
                return string.Empty;
            }
            var valueAfterComma = Math.Pow(10, numberAfterComma).ToInt();
            if (d_value > 0m && d_value < 100m && ((int)d_value * valueAfterComma) % valueAfterComma == 0)
            {
                // Yêu cầu chỉ có 2 số 0 sau dấu phẩy
                return d_value.ToString("N2");
            }
            else
            {
                var strValue = d_value.ToString("N" + numberAfterComma);
                if (strValue != null && strValue.Contains(','))
                {
                    return strValue.TrimEnd('0').TrimEnd(',');
                }
                else
                {
                    return strValue;
                }
            }
        }

        public static string ToDecimalFormated1(this decimal? d_value, int numberAfterComma = 1)
        {
            if (d_value.IsNullOrEmpty())
            {
                return string.Empty;
            }
            var valueAfterComma = Math.Pow(10, numberAfterComma).ToInt();
            if (d_value > 0m && d_value < 100m && ((int)d_value * valueAfterComma) % valueAfterComma == 0)
            {
                // Yêu cầu chỉ có 2 số 0 sau dấu phẩy
                return d_value?.ToString("N1");
            }
            else
            {
                var strValue = d_value?.ToString("N" + numberAfterComma);
                if (strValue != null && strValue.Contains(','))
                {
                    return strValue.TrimEnd('0').TrimEnd(',');
                }
                else
                {
                    return strValue;
                }
            }
        }
        public static string ToDecimalFormated3(this decimal? d_value, int numberAfterComma = 3)
        {
            if (d_value.IsNullOrEmpty())
            {
                return string.Empty;
            }
            var valueAfterComma = Math.Pow(10, numberAfterComma).ToInt();
            if (d_value > 0m && d_value < 100m && ((int)d_value * valueAfterComma) % valueAfterComma == 0)
            {
                // Yêu cầu chỉ có 3 số 0 sau dấu phẩy
                return d_value?.ToString("N3");
            }
            else
            {
                var strValue = d_value?.ToString("N" + numberAfterComma);
                if (strValue != null && strValue.Contains(','))
                {
                    return strValue.TrimEnd('0').TrimEnd(',');
                }
                else
                {
                    return strValue;
                }
            }
        }

        public static string ToDecimalUnFormat(this decimal? d_value)
        {
            if (d_value.IsNullOrEmpty())
            {
                return string.Empty;
            }
            string value = d_value.ToString();
            if (value.Contains(","))
            {
                return value.TrimEnd('0').TrimEnd(',');
            }
            else
            {
                return value;
            }
        }

        public static string ToDecimalUnFormat(this decimal d_value)
        {
            if (d_value.IsNullOrEmpty())
            {
                return string.Empty;
            }
            string value = d_value.ToString();
            if (value.Contains(","))
            {
                return value.TrimEnd('0').TrimEnd(',');
            }
            else
            {
                return value;
            }
        }

        public static string ToDecimalUnFormatDot(this decimal? d_value)
        {
            var value = d_value.ToDecimalUnFormat();
            if (value.Contains(","))
            {
                return value.Replace(",", ".");
            }
            return value;
        }

        public static void AddExist(this Dictionary<string, List<string>> dictionary, string key, string value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key].Add(value);
            }
            else
            {
                dictionary.Add(key, new List<string> { value });
            }
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}
