using CNRInnovaV1.Api.Comun.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CNRInnovaV1.Api.Comun
{
    public class ToolDataComm : IToolDataComm
    {
        public List<T> DataTableToList<T>(DataTable dt)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var objectProperties = typeof(T).GetProperties(flags);
            var targetList = dt.AsEnumerable().Select(dataRow =>
            {
                var instanceOfT = Activator.CreateInstance<T>();

                foreach (var properties in objectProperties.Where(properties => columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
                {
                    properties.SetValue(instanceOfT, dataRow[properties.Name], null);
                }
                return instanceOfT;
            }).ToList();

            return targetList;
        }
    }
}
