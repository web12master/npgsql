﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Npgsql.Messages;
using NpgsqlTypes;
using System.Data;

namespace Npgsql.TypeHandlers.NumericHandlers
{
    /// <remarks>
    /// http://www.postgresql.org/docs/9.3/static/datatype-numeric.html
    /// </remarks>
    [TypeMapping("float8", NpgsqlDbType.Double, DbType.Double, typeof(double))]
    internal class DoubleHandler : TypeHandler<double>,
        ISimpleTypeReader<double>, ISimpleTypeWriter
    {
        public double Read(NpgsqlBuffer buf, FieldDescription fieldDescription, int len)
        {
            return buf.ReadDouble();
        }

        public int GetLength(object value)
        {
            return 8;
        }

        public void Write(object value, NpgsqlBuffer buf)
        {
            var d = GetIConvertibleValue<double>(value);
            buf.WriteDouble(d);
        }
    }
}
